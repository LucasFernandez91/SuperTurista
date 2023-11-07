import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';

import { SharedFunctions } from 'src/app/shared/shared.functions';
import { LocalStorageKeys } from 'src/app/shared/model';
@Component({
  selector: 'workme-login',
  templateUrl: './login.component.html',
  styleUrls: ['login.component.css']
})

export class LoginComponent implements OnInit{
  formGroup: FormGroup;
  hide: boolean = true;
  buttonEnabled: boolean = true;
  allowUserRegistration: boolean = false;
  showLogo: boolean = false;
  logoUrl: string = "assets/Logo.PNG";

  constructor(
    private formBuilder: FormBuilder, 
    public dialog: MatDialog,
    private sharedFunctions: SharedFunctions,
    private router: Router,
    ) {
  }

  ngOnInit(): void {
    this.buildForm();
  }

  buildForm() {
    this.formGroup = this.formBuilder.group({
      'Clave': [null, Validators.required],
      'UserName': [null, Validators.required]
    });
  }

  getErrorUsername() {
    return this.formGroup.get('UserName').hasError('required') ? 'El campo es obligatorio' :'';
  }

  getErrorClave() {
    return this.formGroup.get('Clave').hasError('required') ? 'El campo es obligatorio' : '';
  }

  login() {
    if(this.formGroup.valid) {
      this.buttonEnabled = false;
      /* this.seguridadService.login(this.formGroup.value).subscribe(user => {
        this.buttonEnabled = true;
        if (user != null && user.Success && user.Result != null) {
          if (user.Result.DebeCambiarClave) {
            const dialogRef = this.dialog.open(DialogSetearClaveComponent, {
              data: { UsuarioId: user.Result.Usuario?.Id, Login: user.Result.Usuario?.Login },
              width: '500px'
            });
        
            dialogRef.afterClosed().subscribe((result: boolean) => {
              this.buildForm();
            });
          }
          else
            this.loginSuccessfull(user);
        }
        else {
          this.sharedFunctions.showMessage(user?.Message, "Error");
        }
      }, (err: HttpErrorResponse) => {
        this.buttonEnabled = true;
        this.sharedFunctions.handleError(err, true);
      }); */
    }
    else {
      this.buttonEnabled = true;
      this.sharedFunctions.showMessage("Debe completar todos los campos", "Error");
    }
  }

  loginSuccessfull(user) {
    this.sharedFunctions.setLocalStorageValue(LocalStorageKeys.Token, user.Result.Token.Token);
    this.sharedFunctions.setLocalStorageValue(LocalStorageKeys.Usuario, JSON.stringify(user.Result.Usuario));
    
    // No se guardan mas los menues aca porque no vienen mas en el Login, se cargan a demanda por Tenant
    // this.sharedFunctions.setLocalStorageValue(LocalStorageKeys.Menu, JSON.stringify(user.Result.Menues));

    this.router.navigate(['/']);
  }

  /* openRegisterModal() {
    if (!this.buttonEnabled || !this.allowUserRegistration)
      return;

    const dialogRef = this.dialog.open(DialogRegistroUsuarioComponent, {
      width: '600px'
    });

    dialogRef.afterClosed().subscribe((result: boolean) => {
    });
  } */

  /* openForgotPasswordModal() {
    if (!this.buttonEnabled)
      return;

    const dialogRef = this.dialog.open(DialogOlvidoClaveComponent, {
      width: '600px'
    });

    dialogRef.afterClosed().subscribe((result: boolean) => {
    });
  }; */

  /* openForgotUserModal() {
    if (!this.buttonEnabled)
      return;

    const dialogRef = this.dialog.open(DialogOlvidoUsuarioComponent, {
      width: '600px'
    });

    dialogRef.afterClosed().subscribe((result: boolean) => {
    });
  }; */

  openFaqModal() {
    this.router.navigate(['faqs-public']);
  }
}