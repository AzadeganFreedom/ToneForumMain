import { Component, OnInit } from '@angular/core';
import { Band } from '../../../models/Band';
import { Release } from '../../../models/Release';
import { Type } from '../../../models/Type';
import { Genre } from '../../../models/Genre';
import { ServerService } from '../../services/server.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-submit-release',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './submit-release.component.html',
  styleUrl: './submit-release.component.scss'
})
export class SubmitReleaseComponent implements OnInit {
  releasename: string = '';
  releaseyear: number = 0;
  band_id: number = 0;
  type_id: number = 0;
  genre_id: number[] = [];

  genres: any;
  types: any;
  band: any;
  activeUser: any;

  constructor(private route: ActivatedRoute, private router: Router, private service: ServerService) {}

  ngOnInit(): void {
    // Gets active User
    this.service.activeUser$.subscribe(user => {
      this.activeUser = user;
    });

    this.route.params.subscribe(params => {
      const bandId = params['id']; // Get bandId from the route
      this.getBandById(bandId);
    });

    this.loadGenres();
    this.loadTypes();
  };

  // Get All Genres
  private loadGenres(): void {
    this.service.getAll<Genre>('https://localhost:7131/api/Genre/GetAllGenres').subscribe(data => 
      {
        this.genres = data
        console.log(this.genres)
      }
    );
  };

  // Get All Types
  private loadTypes(): void {
    this.service.getAll<Type>('https://localhost:7131/api/Type/GetAllTypes').subscribe(data => 
      {
        this.types = data
        console.log(this.types)
      }
    );
  };

  submitRelease() {
    const releaseData = {
      releaseName: this.releasename,
      releaseYear: this.releaseyear,
      band_Id: this.band.band_Id,//this.band_id,
      type_Id: this.type_id,
      genre_Id: this.genre_id.filter(id => id !== undefined),
    };

    // Log the final payload to be sent to the API
    console.log("Payload:", releaseData);

    const url = 'https://localhost:7131/api/Release/CreateRelease';

    this.service.create(url, releaseData).subscribe(
      response => {
        console.log('Release submitted succesfully', response);
        this.router.navigate([`/Band/${this.band?.band_Id}`])
      },
      error => {
        if (error.status === 400) {
          console.error('Error submitting release:', error.error.errors); // Log the validation errors
        } else {
          console.error('An unexpected error occurred:', error);
        }
      }
    );
  };

  // Get Band By Id
  private getBandById(bandId: number) {
    this.service.getById<Band>('https://localhost:7131/api/Band/', +bandId).subscribe(data => {
      this.band = data;
      console.log(this.band)
    });
  };

  onCancel(bandId: number) {
    this.router.navigate([`/Band/${bandId}`])
  }
}
