import { GenericResponse } from './../model/genericResponse';
import { Injectable } from '@angular/core';
import { Observable, catchError, firstValueFrom, throwError } from 'rxjs';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { CrudService } from './crud.service';
import { SharedFunctions } from 'src/app/shared/shared.functions';
import { LoginRequest } from '../model/securityRequests';

@Injectable({
  providedIn: 'root'
})
export class SeguridadService extends CrudService<any, number, any, any> { 

  constructor(protected override _http: HttpClient, public override sharedFunctions: SharedFunctions) {
    super(_http,'Seguridad', sharedFunctions);
  }
  
  async login(p: LoginRequest) {
    try {
      const datos = await firstValueFrom(
        this._http.post<any>(this._serviceUrl + '/Login', p, this.httpOptions).pipe(
          catchError((error: HttpErrorResponse) => {
            return throwError(() => error);
          })
        )
      );
      return datos;
    } catch (error) {
      console.error('Error en la petición GET:', error);
    }
  }

  register(p: any): Observable<any> {
    return this._http.post<any>(this._serviceUrl + '/register', p, this.httpOptions);
  }

  forgotUser(p: any): Observable<any> {
    return this._http.post<any>(this._serviceUrl + '/forgot-user', p, this.httpOptions);
  }

  forgotPassword(p: any): Observable<any> {
    return this._http.post<any>(this._serviceUrl + '/reset-password-app', p, this.httpOptions);
  }

  saveResetPassword(p: any): Observable<any> {
    return this._http.post<any>(this._serviceUrl + '/save-reset-password', p, this.httpOptions);
  } 

  forgotPasswordConfirmation(p: any): Observable<any> {
    return this._http.post<any>(this._serviceUrl + '/forgot-password-app/confirmation', p, this.httpOptions);
  }

  checkUsuarioPermiso(funcion:string): Observable<boolean> {
    return this._http.get<boolean>(this._serviceUrl + '/check-usuario-permiso/' + funcion, this.httpOptions);
  }

  confirmUser(p : string): Observable<GenericResponse<boolean>>{
    return this._http.post<any>(this._serviceUrl + '/confirm-user'+p, null, this.httpOptions);
  }
}