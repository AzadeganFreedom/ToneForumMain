import { Component } from '@angular/core';
import { User } from '../../../models/User';
import { ServerService } from '../../services/server.service';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './user.component.html',
  styleUrl: './user.component.scss'
})
export class UserComponent {

  users: User[] = [];
  //userid: number = 0;
  selectedUser: any;

  constructor(private service: ServerService, private router: Router) {

  }

  ngOnInit(){

    this.service.getAll<User>('https://localhost:7131/api/User/GetAllUsers').subscribe(data => 
      {
        this.users = data
        console.log(this.users);
      }
    );
  }

  deleteUser(userid: number){
    this.service.deleteById('https://localhost:7131/api/User/',userid).subscribe(user =>
      {
        this.selectedUser = user
        console.log(this.selectedUser);
        window.location.reload();
      },
      error => {
        console.error('Error deleting user', error);
      }
    );
  }
}
