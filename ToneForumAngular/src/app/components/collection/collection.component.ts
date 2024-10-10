import { Component, OnInit } from '@angular/core';
import { Band } from '../../../models/Band';
import { Release } from '../../../models/Release';
import { Type } from '../../../models/Type';
import { Genre } from '../../../models/Genre';
import { CollectionList } from '../../../models/CollectionList';
import { ServerService } from '../../services/server.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-collection',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './collection.component.html',
  styleUrl: './collection.component.scss'
})
export class CollectionComponent implements OnInit{

  band: Band | null = null;
  releases: Release[] = [];
  activeUser: any;
  types: any;
  genres: any;
  collection: CollectionList | null = null;
  bandCache: { [key: number]: string } = {};

  constructor(private route: ActivatedRoute, private router: Router, private service: ServerService) {}

  ngOnInit(): void {
    // Gets active User
    this.service.activeUser$.subscribe(user => {
      this.activeUser = user;
    });

    this.route.params.subscribe(params => {
      const collectionId = params['id']; // Get releaseId from the route
      
      if (collectionId) {
      this.getCollectionById(collectionId)
      this.getAllTypes();
      }

    });
    this.getAllGenres();
  };

  // Get Band By Id
  getBandById(bandId: number) {
    this.service.getById<Band>('https://localhost:7131/api/Band/', +bandId).subscribe(data => {
      this.band = data;
    });
  };

  getBandName(bandId: number): string {
    // Check if the band name is already cached
    if (this.bandCache[bandId]) {
      return this.bandCache[bandId];
    }
  
    // If not cached, make the API call to get the band name
    this.service.getById<Band>('https://localhost:7131/api/Band/', bandId).subscribe(data => {
      if (data) {
        this.bandCache[bandId] = data.bandName; // Cache the band name for future use
      }
    });
  
    // Return a placeholder until the data is available
    return 'Loading...';
  }

  // Get Collection By Id
  getCollectionById(collectionId: number) {
    this.service.getById<CollectionList>('https://localhost:7131/api/CollectionList/', +collectionId).subscribe(data => {
      this.collection = data;
      this.releases = this.collection.releases
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

  // Select Band
  onBand(bandId: number) {
    this.router.navigate([`/Band/${bandId}`])
  }

  // Select Release
  onRelease(releaseId: number) {
    this.router.navigate([`/Release/${releaseId}`])
  }

  // Remove Release from collection
  onRemove(listId: number, releaseId: number) {
    this.service.removeFromCollection(listId, releaseId).subscribe(
      () => {
        // Remove the release from the releases array
        this.releases = this.releases.filter(release => release.release_Id !== releaseId);
        console.log('Release removed successfully');
      },
      error => {
        console.error('Error removing release', error);
      }
    );
  }  
}
