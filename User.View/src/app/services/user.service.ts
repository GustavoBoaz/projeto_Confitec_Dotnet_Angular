import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  myAppURL = 'https://localhost:5001/';
  myAPIURL = 'api/Users/';
  list: User[] | undefined;

  private updateForm = new BehaviorSubject<User>({} as any);

  constructor(private http: HttpClient) { }

  create(user: User): Observable<User> {
    return this.http.post<User>(this.myAppURL + this.myAPIURL, user);
  }

  readAll(){
    this.http.get(this.myAppURL + this.myAPIURL + 'all').toPromise()
      .then(res => this.list = res as User[]);
  }

  updateUser(user: User): Observable<User> {
    return this.http.put(this.myAppURL + this.myAPIURL, user);
  }


  delete(id: any): Observable<User> {
    return this.http.delete<User>(this.myAppURL + this.myAPIURL + id);
  }

  update(user: User) {
    this.updateForm.next(user);
  }

  getUpdateForm(): Observable<User> {
    return this.updateForm.asObservable();
  }
}
