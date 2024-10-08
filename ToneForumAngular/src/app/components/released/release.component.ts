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
  selector: 'app-band',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './release.component.html',
  styleUrl: './release.component.scss'
})
export class ReleaseComponent implements OnInit {

  band: Band | null = null;
  release: Release | null = null;
  activeUser: any;
  types: any;
  genres: any;

  

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
      const releaseId = params['id']; // Get releaseId from the route
      
      if (releaseId) {
      this.getReleaseById(releaseId);
      this.getAllTypes();
      }

    });
    this.getAllGenres();
  };

  // Get Release By Id
  getReleaseById(releaseId: number) {
    this.service.getById<Release>('https://localhost:7131/api/Release/', +releaseId).subscribe(data => {
      this.release = data;

      if (this.release) {
        this.getBandById(this.release.band_Id);
      }
    });
  };

  // Get Band By Id
  getBandById(bandId: number) {
    this.service.getById<Band>('https://localhost:7131/api/Band/', +bandId).subscribe(data => {
      this.band = data;
    });
  };

  // Get Genre By Id
  getGenreById(genreId: number): string {
    const genre = this.genres.find((g: Genre) => g.genre_Id === genreId);
    return genre ? genre.genreName : 'Unknown Genre'; // Return 'Unknown Genre' if no match is found
  }

  // Get All Types
  getAllTypes() {
    this.service.getAll<Type>('https://localhost:7131/api/Type/GetAllTypes').subscribe(data => 
      {
        this.types = data
      }
    );
  }

  // Get All Genres
  getAllGenres(): void {
    this.service.getAll<Genre>('https://localhost:7131/api/Genre/GetAllGenres').subscribe(data => 
      {
        this.genres = data
      }
    );
  };

  // Get Type name based off of release
  getTypeName(type_Id: number): string {
    const matchedType = this.types.find((type: Type) => type.type_Id === type_Id);
    return matchedType ? matchedType.typeName : 'Unknown';
  };

  // Edit Artist
  onEditRelease(releaseId: number) {
    this.router.navigate([`/EditRelease/${releaseId}`]);
  };

  // Select Release
  onBand(bandId: number) {
    this.router.navigate([`/Band/${bandId}`])
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
