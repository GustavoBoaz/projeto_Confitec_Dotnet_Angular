import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public users?: User[];

  constructor(http: HttpClient) {
    http.get<User[]>('/api/Users/all').subscribe(result => {
      this.users = result;
    }, error => console.error(error));
  }

  title = 'User.View';
}

interface User {
  nome: string;
  sobrenome: number;
  email: number;
  dataNacimento: string;
  escolaridade: string;
  id: string;
}