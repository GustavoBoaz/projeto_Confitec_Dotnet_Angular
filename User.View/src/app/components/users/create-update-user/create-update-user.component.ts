import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-create-update-user',
  templateUrl: './create-update-user.component.html',
  styleUrls: ['./create-update-user.component.css']
})
export class CreateUpdateUserComponent implements OnInit, OnDestroy {

  subscribing = new Subscription();

  user = new User();

  form = new FormGroup({
    id: new FormControl(null),
    nome: new FormControl('', [Validators.required, Validators.minLength(3)]),
    sobrenome: new FormControl('', [Validators.required, Validators.minLength(3)]),
    email: new FormControl('', [Validators.required, Validators.email]),
    dataNascimento: new FormControl('', [Validators.required]),
    escolaridade: new FormControl('', [Validators.required])
  });

  constructor(private userServices: UserService, private toastr: ToastrService) {

  }

  ngOnInit(): void {
    this.subscribing = this.userServices.getUpdateForm().subscribe(data => {
      console.log(data);
      this.user = data;

      this.form.patchValue({
        nome: this.user.nome,
        sobrenome: this.user.sobrenome,
        email: this.user.email,
        dataNascimento: this.user.dataNascimento,
        escolaridade: this.user.escolaridade
      });

    });
  }

  ngOnDestroy() {
    this.subscribing.unsubscribe();
  }

  sendUser() {

    if (this.user.id === '') {

      this.create();

    } else {
      
      this.update();

    }
  }

  create(){
    const user: User = {
      id: this.form.value.id,
      nome: this.form.value.nome,
      sobrenome: this.form.value.sobrenome,
      email: this.form.value.email,
      dataNascimento: this.form.value.dataNascimento,
      escolaridade: this.form.value.escolaridade
    };

    this.userServices.create(user).subscribe(data =>{
      this.form.reset();
      this.userServices.readAll();
      this.toastr.success('Um novo usuário foi adicionado no Banco de Dados!', 'Usuário criado', {
        progressBar: true,
        progressAnimation: 'increasing',
        positionClass: 'toast-top-right'
      });
    }, (error: any) => {
      this.toastr.error('Valide os campos do formulario!', 'Erro ao criar usuário', {
        progressBar: true,
        progressAnimation: 'increasing',
        positionClass: 'toast-top-right'
      });
    });
  }

  update(){
  
    const user: User = {
      id: this.user.id,
      nome: this.form.value.nome,
      sobrenome: this.form.value.sobrenome,
      email: this.form.value.email,
      dataNascimento: this.form.value.dataNascimento,
      escolaridade: this.form.value.escolaridade
    };

    this.userServices.updateUser(user).subscribe(data =>{
      this.user.id = '';
      this.form.reset();
      this.userServices.readAll();
      this.toastr.info('Um usuário foi atualizado no Banco de Dados!', 'Usuário atualizado', {
        progressBar: true,
        progressAnimation: 'increasing',
        positionClass: 'toast-top-right'
      });
    }, (error: any) => {
      this.toastr.error('Valide os campos do formulario!', 'Erro ao criar usuário', {
        progressBar: true,
        progressAnimation: 'increasing',
        positionClass: 'toast-top-right'
      });
    });

  }

}
