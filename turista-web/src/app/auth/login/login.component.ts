import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { LocalStorageKeys } from 'src/app/shared/model/constants';
import { SeguridadService } from 'src/app/shared/services/seguridad.service';
import { SharedFunctions } from 'src/app/shared/shared.functions';
import { DialogSetearClaveComponent } from '../components/dialog-setear-clave.component';
import { DialogRegistroUsuarioComponent } from '../components/dialog-registro-usuario.component';
import { DialogOlvidoClaveComponent } from '../components/dialog-olvido-clave.component';
import { DialogOlvidoUsuarioComponent } from '../components/dialog-olvido-usuario.component';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  formGroup: FormGroup;
  hide: boolean = true;
  buttonEnabled: boolean = true;

  constructor(
    private formBuilder: FormBuilder, 
    public dialog: MatDialog,
    private sharedFunctions: SharedFunctions,
    private router: Router,
    private seguridadService: SeguridadService) {
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
      this.seguridadService.login(this.formGroup.value).subscribe(user => {
        this.buttonEnabled = true;
        if (user != null && user.Success && user.Result != null) {
          if (user.Result.CognitoChallenge == "NEW_PASSWORD_REQUIRED") {
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
      });
    }
    else {
      this.buttonEnabled = true;
      this.sharedFunctions.showMessage("Debe completar todos los campos", "Error");
    }
  }

  loginSuccessfull(user) {
    this.sharedFunctions.setLocalStorageValue(LocalStorageKeys.Token, user.Result.Token.Token);
    this.sharedFunctions.setLocalStorageValue(LocalStorageKeys.Menu, JSON.stringify(user.Result.Menues));
    this.sharedFunctions.setLocalStorageValue(LocalStorageKeys.Usuario, JSON.stringify(user.Result.Usuario));

    this.router.navigate(['/']);
  }

  openRegisterModal() {
    if (!this.buttonEnabled)
      return;

    const dialogRef = this.dialog.open(DialogRegistroUsuarioComponent, {
      width: '600px'
    });

    dialogRef.afterClosed().subscribe((result: boolean) => {
    });
  }

  openForgotPasswordModal() {
    if (!this.buttonEnabled)
      return;

    const dialogRef = this.dialog.open(DialogOlvidoClaveComponent, {
      width: '600px'
    });

    dialogRef.afterClosed().subscribe((result: boolean) => {
    });
  };

  openForgotUserModal() {
    if (!this.buttonEnabled)
      return;

    const dialogRef = this.dialog.open(DialogOlvidoUsuarioComponent, {
      width: '600px'
    });

    dialogRef.afterClosed().subscribe((result: boolean) => {
    });
  };

  openFaqModal() {
    this.router.navigate(['faqs-public']);
  }
}