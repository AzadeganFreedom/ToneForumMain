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
  templateUrl: './submit-artist.component.html',
  styleUrl: './submit-artist.component.scss'
})

export class SubmitArtistComponent implements OnInit {
  bandname: string = '';
  country: string = '';
  active: boolean = true;
  startyear: number = 0;
  endyear: number | null = null;

  band: any;
  activeUser: any;

  constructor(private route: ActivatedRoute, private router: Router, private service: ServerService) {}

  ngOnInit(): void {
    // Gets active User
    this.service.activeUser$.subscribe(user => {
      this.activeUser = user;
      console.log(this.activeUser)
    });
  };

  submitBand() {
    const bandData = {
      bandname: this.bandname,
      country: this.country,
      active: this.active,
      startyear: this.startyear,
      endyear: this.endyear,
    };

    console.log("Payload:", bandData);

    const url = 'https://localhost:7131/api/Band/CreateBand';

    this.service.create(url, bandData).subscribe(
      response => {
        console.log('Band submitted succesfully', response);

        this.getBandByBandName(bandData.bandname);
      },
      error => {
        console.error('Error submitting band', error);
      }
    );
  };

  // Get Band By Id
  getBandById(bandId: number) {
    this.service.getById<Band>('https://localhost:7131/api/Band/', bandId).subscribe(data => {
      this.band = data;
      console.log(this.band)
    });
  };

  // Get Band By Band Name
  getBandByBandName(bandName: string) {
    this.service.getByName<Band>('https://localhost:7131/api/Band/GetBandByBandName?bandName=', bandName).subscribe(data => {
      this.band = data;
      console.log('Band retrieved', this.band)
      this.router.navigate([`/Band/${this.band.band_Id}`])
    })
  }

  onCancel(bandId: number) {
    this.router.navigate([`/Band/${bandId}`])
  }
}
