import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-list-users',
  templateUrl: './list-users.component.html',
  styleUrls: ['./list-users.component.css']
})
export class ListUsersComponent implements OnInit {

  constructor(public userService: UserService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.userService.readAll();
  }

  deleteUser(id: any) {
    
    if (confirm('Está seguro que quer eliminar este usuário?')) {
      this.userService.delete(id).subscribe(data => {
        this.userService.readAll();

        this.toastr.warning('O usuário não existe mais no sistema', 'Usuário deletado', {
          progressBar: true,
          progressAnimation: 'increasing',
          positionClass: 'toast-top-right'
        });
      });
    }
  }

  updateUser(user: any) {
    this.userService.update(user);
  }

}
