import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BehaviorSubject } from 'rxjs';
import { Band } from '../../models/Band';
import { User } from '../../models/User';

@Injectable({
  providedIn: 'root'
})
export class ServerService {
  
  private activeUserSubject = new BehaviorSubject<any>(this.getActiveUserLocally());
  activeUser$ = this.activeUserSubject.asObservable();
  
  // Method to update the active user
  setActiveUser(user: any) {
    this.activeUserSubject.next(user);
    localStorage.setItem('activeUser', JSON.stringify(user));
  }
  
  // Method to retrieve the current active user value
  getActiveUser() {
    return this.activeUserSubject.getValue();
  }

  // Load active user from localStorage if available
  private getActiveUserLocally() {
    const user = localStorage.getItem('activeUser');
    return user ? JSON.parse(user) : null;
  }

  // Method to clear the active user
  clearActiveUser() {
    this.activeUserSubject.next(null);
    localStorage.removeItem('activeUser');
    window.location.reload();
  }


  constructor(private http:HttpClient) { }

  // GET methods
  getAll<T>(url: string):Observable<T[]>{
    return this.http.get<T[]>(url);
  }

  getByName<T>(url: string, name: string):Observable<T>{
    const apiUrl = `${url}${name}`;
    return this.http.get<T>(apiUrl);
  }

  getById<T>(url: string, id: number):Observable<T>{
    const apiUrl = `${url}${id}`;
    return this.http.get<T>(apiUrl);
  }

  // GET user specifically
  getUser<T>(name: string, password: string):Observable<T>{
    const apiUrl = `https://localhost:7131/api/User/GetUserByUserName?userName=${name}&password=${password}`;
    return this.http.get<T>(apiUrl);
  }

  // CREATE methods
  create<T>(url: string, userData: T): Observable<T> {
    return this.http.post<T>(url, userData);
  }

  // UPDATE methods
  updateById<T>(url: string, id: number, data: T): Observable<T> {
    const apiUrl = `${url}${id}`;
    return this.http.patch<T>(apiUrl, data);
  }
 
  // Add Release to Collection
  addToCollection<T>(listId: number, releaseId: number):Observable<T> {
    const apiUrl = `https://localhost:7131/api/CollectionList/${listId}?releaseId=${releaseId}`;
    return this.http.patch<T>(apiUrl, {}, { responseType: 'json' });
  }

  //Add Release to Wantlist
  addToWantlist<T>(listId: number, releaseId: number):Observable<T> {
    const apiUrl = `https://localhost:7131/api/WantList/${listId}?releaseId=${releaseId}`;
    return this.http.patch<T>(apiUrl, {}, { responseType: 'json' });
  }

  // DELETE methods
  deleteById<T>(url: string, id: number):Observable<T> {
    const apiUrl = `${url}${id}`;
    return this.http.delete<T>(apiUrl);
  }

}
