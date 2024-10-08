import { Component } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from '../../../models/User';
import { ServerService } from '../../services/server.service'; 

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {
  firstname: string = '';
  lastname: string = '';
  email: string = '';
  username: string = '';
  password: string = '';
  accepttermsandpolicy: boolean = false;

  constructor(private service: ServerService, private router: Router) {}

  toggleAcceptTerms() {
    this.accepttermsandpolicy = !this.accepttermsandpolicy;  // Toggle the acceptterms boolean
  }
  
  createUser() {
    const newUser = {
      firstname: this.firstname,
      lastname: this.lastname,
      email: this.email,
      username: this.username,
      password: this.password,
      accepttermsandpolicy: this.accepttermsandpolicy,
    };

    const url = 'https://localhost:7131/api/User/CreateUser';

    this.service.create(url, newUser).subscribe(
      response => {
        console.log('User created succesfully', response);
        this.router.navigate(['/Login']);
        console.log(this.accepttermsandpolicy);
      },
      error => {
        console.error('Error creating user', error);
      }
    );
  }
}
