import { Injectable } from '@angular/core';
import { Router, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ServerService } from '../services/server.service';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard {

  constructor(private service: ServerService, private router: Router) {}

  canMatch(): Observable<boolean | UrlTree> | boolean | UrlTree {
    return this.service.activeUser$.pipe(
      map(user => {
        if (user && user.userName === 'Admin') {
          return true;  // Allow access if the user is 'Admin'
        } else {
          return this.router.parseUrl('/not-authorized');  // Redirect if not 'Admin'
        }
      })
    );
  }
}
