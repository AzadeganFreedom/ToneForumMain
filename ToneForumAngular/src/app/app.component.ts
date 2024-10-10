import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLinkActive, RouterOutlet } from '@angular/router';
import { Router, NavigationEnd } from '@angular/router';
import { provideRouter, Routes } from '@angular/router';
import { RouterLink } from '@angular/router';
import { BandComponent } from "./components/band/band.component";
import { UserComponent } from './components/user/user.component';
import { ProfileComponent } from './components/profile/profile.component';
import { Release } from '../models/Release';
import { User } from '../models/User';
import { Band } from '../models/Band';
import { Type } from '../models/Type';
import { Genre } from '../models/Genre';
import { RegisterComponent } from "./components/register/register.component";
import { LoginComponent } from './components/login/login.component';
import { StartComponent } from './components/start/start.component';
import { ServerService } from './services/server.service';
import { FormsModule } from '@angular/forms';

interface SearchResult {
  name: string;
  type: 'band' | 'release';
  id: number;
}

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [FormsModule, CommonModule, RouterLinkActive, RouterLink, RouterOutlet, StartComponent, RegisterComponent, LoginComponent, BandComponent, UserComponent, RegisterComponent, ProfileComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  isSpecificRoute = false;
  isLoginRoute = false;

  isDropdownOpen = false;

  searchTerm: string = '';
  filteredResults: SearchResult[] = [];

  // User
  users: User[] = [];
  activeUser: any;
  //searchUsername: string = '';
  //activeUser: { [key: string]: any } = {};

  // Band
  bands: Band[] = [];

  // Release
  releases: Release[] = []

  // Type
  types: Type[] = []

  // Genre
  genres: Genre[] = []

  toggleDropdown() {
    this.isDropdownOpen = !this.isDropdownOpen;
  }

   // For handling dropdown suggestions
   onSearch() {
    // Combine all data (bands, releases) for filtering
    const combinedData = [
      ...this.bands.map(band => ({name: band.bandName, type: 'band' as 'band', id: band.band_Id})),
      ...this.releases.map(release => ({name: release.releaseName, type: 'release' as 'release', id: release.release_Id}))
    ];

    if (this.searchTerm) {
      this.filteredResults = combinedData.filter(item =>
        item.name.toLowerCase().includes(this.searchTerm.toLowerCase())
      );
    } else {
      this.filteredResults = [];
    }
  }

  // When a suggestion is clicked
  selectResult(result: SearchResult) {
    this.searchTerm = result.name; // Set the input to the selected suggestion
    this.filteredResults = []; // Hide the suggestions

    // Navigate to the band or release page based on the type
    if (result.type === 'band') {
      this.router.navigate([`/Band/${result.id}`]); // Navigate to band page
    } else if (result.type === 'release') {
      this.router.navigate([`/Release/${result.id}`]); // Navigate to release page
    }
  }


  constructor(private router: Router, private service: ServerService) {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        // Adjust this logic based on your route paths
        this.isSpecificRoute = event.url === '/Register'; // hide if route is '/Register'
        this.isLoginRoute = event.url === '/Login';
      }
    });
  }

  ngOnInit(){
    // Get All Users
    this.service.getAll<User>('https://localhost:7131/api/User/GetAllUsers').subscribe(data => 
      {
        this.users = data
        console.log(this.users);
      }
    );

    // Get All Bands
    this.service.getAll<Band>('https://localhost:7131/api/Band/GetAllBands').subscribe(data => 
      {
        this.bands = data
        console.log(this.bands)
      }
    );

    // Get All Releases
    this.service.getAll<Release>('https://localhost:7131/api/Release/GetAllReleases').subscribe(data => 
      {
        this.releases = data
        console.log(this.releases)
      }
    );

    // Get All Types
    this.service.getAll<Type>('https://localhost:7131/api/Type/GetAllTypes').subscribe(data => 
      {
        this.types = data
        console.log(this.types)
      }
    );

    // Get All Genres
    this.service.getAll<Genre>('https://localhost:7131/api/Genre/GetAllGenres').subscribe(data => 
      {
        this.genres = data
        console.log(this.genres)
      }
    );

    // Gets active User
    this.service.activeUser$.subscribe(user => {
      this.activeUser = user;
      console.log(this.activeUser)
    });
  }
  
  // Clear active User
  clearUser() {
    this.service.clearActiveUser();
  }

  // When selecting Collection
  onCollection() {
    this.router.navigate([`/Collection/${this.activeUser.user_Id}`]);
    this.toggleDropdown();
  }

  // When selecting Wantlist
  onWantlist() {
    this.router.navigate([`/Wantlist/${this.activeUser.user_Id}`]);
    this.toggleDropdown();
  }

  /*searchUser() {
    this.service.getByName<User>('https://localhost:7131/api/User/GetUserByUserName?userName=', this.searchUsername).subscribe(user => {
      console.log(user);  // This will log the User object with name 'John'
      this.activeUser = user;
    });
  }*/
  
};
