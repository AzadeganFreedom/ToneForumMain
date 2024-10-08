import { Component, OnInit } from '@angular/core';
import { Band } from '../../../models/Band';
import { Release } from '../../../models/Release';
import { ServerService } from '../../services/server.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-edit-artist',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './edit-artist.component.html',
  styleUrl: './edit-artist.component.scss'
})
export class EditArtistComponent implements OnInit {
  bandname: string = '';
  country: string = '';
  active: boolean = true;
  startyear: number = 0;
  endyear: number | null = null;

  band: any;
  activeUser: any;

  viewActive = true;

  constructor(private route: ActivatedRoute, private router: Router, private service: ServerService) {}

  ngOnInit(): void {
    // Gets active User
    this.service.activeUser$.subscribe(user => {
      this.activeUser = user;
      console.log(this.activeUser)
    });

    this.route.params.subscribe(params => {
      const bandId = params['id']; // Get bandId from the route
      
      this.getBandById(bandId);
    });
  };

  toggleView() {
    this.viewActive = !this.viewActive;
    console.log(this.viewActive)
  }

  updateBand(bandId: number) {
    const bandData = {
      bandname: this.bandname,
      country: this.country,
      active: this.active,
      startyear: this.startyear,
      endyear: this.endyear,
    };

    const url = 'https://localhost:7131/api/Band/';

    this.service.updateById(url, bandId, bandData).subscribe(
      response => {
        console.log('Band updated succesfully', response);
        this.router.navigate([`/Band/${this.band.band_Id}`])
      },
      error => {
        console.error('Error updating band', error);
      }
    );
  };

  // Get Band By Id
  getBandById(bandId: number) {
    this.service.getById<Band>('https://localhost:7131/api/Band/', +bandId).subscribe(data => {
      this.band = data;
      console.log(this.band)
    });
  };

  onCancel(bandId: number) {
    this.router.navigate([`/Band/${bandId}`])
  }
}
