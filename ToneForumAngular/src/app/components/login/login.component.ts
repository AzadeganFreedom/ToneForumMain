import { Component } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from '../../../models/User';
import { ServerService } from '../../services/server.service'; 

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [HttpClientModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

  users: User[] = [];
  searchUsername: string = '';
  password: string = '';
  activeUser: { [key: string]: any } = {};

  constructor(private service: ServerService, private router: Router) {}

  searchUser() {
    this.service.getUser<User>( this.searchUsername, this.password).subscribe(
      user => {
        if (user) {
          console.log(user);
          this.service.setActiveUser(user);
          this.router.navigate(['/Start']);
        } else {
          console.error('User not found');
        }
    }, 
    error => {
      console.error('Error fetching user: ', error);
    }
  );
  }

  onSignUp() {
    if (this.searchUsername && this.password) {
      this.searchUser();
      //this.router.navigate(['/Start'])
    }
  }
}
