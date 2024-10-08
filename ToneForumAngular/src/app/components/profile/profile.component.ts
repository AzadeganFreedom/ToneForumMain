import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ServerService } from '../../services/server.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss'
})
export class ProfileComponent {
  firstname: string = '';
  lastname: string = '';
  email: string = '';
  username: string = '';
  password: string = '';

  viewActive = true;

  constructor(private service: ServerService, private router: Router) {}
  activeUser: any;


  ngOnInit() {
    // Gets active User
    this.service.activeUser$.subscribe(user => {
      this.activeUser = user;
      console.log(this.activeUser)
    });
  }

  toggleView() {
    this.viewActive = !this.viewActive;
    console.log(this.viewActive)
  }

  updateUser() {
    const userData = {
      firstname: this.firstname,
      lastname: this.lastname,
      email: this.email,
      username: this.username,
      password: this.password,
    };

    const url = 'https://localhost:7131/api/User/';

    this.service.activeUser$.subscribe(user => {
      this.activeUser = user;
    });

    this.service.updateById(url, this.activeUser.user_Id, userData).subscribe(
      response => {
        console.log('User update succesfully', response);
        this.service.setActiveUser(response);
        window.location.reload();
      },
      error => {
        console.error('Error updating user', error);
      }
    );
  };

  onCancel() {
    this.router.navigate(['/Start'])
  }
}
