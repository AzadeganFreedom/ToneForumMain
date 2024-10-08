import { Component, OnInit } from '@angular/core';
import { Band } from '../../../models/Band';
import { Release } from '../../../models/Release';
import { Type } from '../../../models/Type';
import { ServerService } from '../../services/server.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-band',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './band.component.html',
  styleUrl: './band.component.scss'
})
export class BandComponent implements OnInit {

  band: Band | null = null;
  releases: Release[] = [];
  activeUser: any;
  types: any;

  private wantlistSet: Set<number> = new Set();
  private collectionSet: Set<number> = new Set();

  //isAddedToCollection = false;
  //isAddedToWantlist = false;

  constructor(private route: ActivatedRoute, private router: Router, private service: ServerService) {}

  ngOnInit(): void {
    // Gets active User
    this.service.activeUser$.subscribe(user => {
      this.activeUser = user;
    });

    // Handling of band changes dynamically
    this.route.params.subscribe(params => {
      const bandId = params['id']; // Get bandId from the route
      
      if (bandId) {
      this.getBandById(bandId);
      this.getReleasesByBandId(bandId);
      this.getAllTypes();
      }
    });
  };

  // Get Band By Id
  getBandById(bandId: number) {
    this.service.getById<Band>('https://localhost:7131/api/Band/', +bandId).subscribe(data => {
      this.band = data;
    });
  };

  // Get Releases By band_Id
  getReleasesByBandId(bandId: number) {
    this.service.getById<Release[]>('https://localhost:7131/api/Release/GetReleaseByBandId?bandId=', +bandId)
      .subscribe(data => {
        // Sort the releases by type_Id first, then by releaseYear in descending order
        this.releases = data.sort((a, b) => {
          if (a.type_Id === b.type_Id) {
            return a.releaseYear - b.releaseYear; // Descending order for years
          }
          return a.type_Id - b.type_Id; // Ascending order for type
        });
      }
    );
  };

  // Get All Types
  getAllTypes() {
    this.service.getAll<Type>('https://localhost:7131/api/Type/GetAllTypes').subscribe(data => 
      {
        this.types = data
      }
    );
  }

  // Get Type name based off of the releases
  getTypeName(type_Id: number): string {
    const matchedType = this.types.find((type: Type) => type.type_Id === type_Id);
    return matchedType ? matchedType.typeName : 'Unknown';
  };

  // Edit Artist
  onEditArtist(bandId: number) {
    this.router.navigate([`/EditArtist/${bandId}`]);
  };

  // Submit Release
  onSubmitRelease(bandId: number) {
    this.router.navigate([`/SubmitRelease/${bandId}`])
  }

  // Select Release
  onRelease(releaseId: number) {
    this.router.navigate([`/Release/${releaseId}`])
  }

  // Add to Collection
  addToCollection(listId: number, releaseId: number) {
    this.service.addToCollection(listId, releaseId).subscribe(
      response => {
        console.log('Release added to collection succesfully', response);
        this.collectionSet.add(releaseId);
        //window.location.reload();
      },
      error => {
        console.error('Error adding release to collection', error);
      }
    );
  }
  isAddedToCollection(releaseId: number): boolean {
    return this.collectionSet.has(releaseId);
  }

  // Add to Wantlist
  addToWantlist(listId: number, releaseId: number) {
    this.service.addToWantlist(listId, releaseId).subscribe(
      response => {
        console.log('Release added to wantlist succesfully', response);
        this.wantlistSet.add(releaseId);
      },
      error => {
        console.error('Error adding release to wantlist', error);
      }
    );
  }
  isAddedToWantlist(releaseId: number): boolean {
    return this.wantlistSet.has(releaseId);
  }
}
