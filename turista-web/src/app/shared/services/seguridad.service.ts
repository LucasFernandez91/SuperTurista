import { GenericResponse } from './../model/genericResponse';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CrudService } from './crud.service';
import { SharedFunctions } from 'src/app/shared/shared.functions';
import { DialogPinRequestDto} from '../model';

@Injectable({
  providedIn: 'root'
})
export class SeguridadService extends CrudService<any, number, any, any> { 

  constructor(protected override _http: HttpClient, protected override sharedFunctions: SharedFunctions) {
    super(_http,'seguridad', sharedFunctions);
  }

  login(p: any): Observable<any> {
    return this._http.post<any>(this._serviceUrl + '/app/login', p, this.httpOptions);
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

  validatePin(p : DialogPinRequestDto): Observable<GenericResponse<boolean>>{
    return this._http.post<any>(this._serviceUrl + '/validate-pin', p, this.httpOptions);
  }

  confirmUser(p : string): Observable<GenericResponse<boolean>>{
    return this._http.post<any>(this._serviceUrl + '/confirm-user'+p, null, this.httpOptions);
  }
}