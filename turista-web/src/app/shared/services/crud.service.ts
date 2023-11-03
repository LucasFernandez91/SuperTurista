import { GenericResponse, GenericSearchResponse } from './../model/genericResponse';
import { Observable, throwError } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CrudOperations } from './crud-operations.interface';
import { retry, catchError } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { LocalStorageKeys } from '../model/constants';
import { SharedFunctions } from 'src/app/shared/shared.functions';

export abstract class CrudService<T, ID, saveModel, searchModel> implements CrudOperations<T, ID, saveModel, searchModel> {
  protected _base: string = environment.apiUrl;
  protected _serviceUrl: string = "";

  httpOptions = {};
  httpCsvOptions = {};
  httpFormDataOptions = {};

  constructor(
    protected _http: HttpClient, 
    protected resource: string,
    protected sharedFunctions: SharedFunctions
  ) {

    this._serviceUrl = this._base + resource;

    this.httpOptions = {
      headers: new HttpHeaders(
        { 'Content-Type': 'application/json' }
      )};

    this.httpCsvOptions = 
    {
      headers: new HttpHeaders(
        { 'Content-type': 'text/csv' }
      ), responseType: 'blob'
    };

    this.httpFormDataOptions = {
      headers: new HttpHeaders(
      )};
  }

  getAuthorizationHeader() { 
    return { 'Authorization' : 'Bearer ' + this.sharedFunctions.getLocalStorageValue(LocalStorageKeys.Token) };
  }

  getAuthorizationHeaderParameterName(): string { 
    return 'Authorization';
  }

  getAuthorizationHeaderParameterValue(): string { 
    return 'Bearer ' + this.sharedFunctions.getLocalStorageValue(LocalStorageKeys.Token);
  }

  getResourceName() { 
    return this.resource;
  }

 

  getServiceUrl() { 
    return this._serviceUrl;
  }

  getSearchUrl() {
    return this._serviceUrl + '/search';
  }

  save(t: saveModel): Observable<GenericResponse<T>> {
    return this._http.post<GenericResponse<T>>(this._serviceUrl + "/save", t, this.httpOptions);
  }

  update(id: ID, t: T): Observable<GenericResponse<T>> {
    return this._http.put<GenericResponse<T>>(this._serviceUrl + "/save", t, this.httpOptions);
  }

  get(id: ID): Observable<GenericResponse<T>> {
    return this._http.get<GenericResponse<T>>(this._serviceUrl + "/" + id, this.httpOptions);
    // .pipe
    // (
    //   retry(1),
    //   catchError(this.handleError)
    // )
  }

  search(value: searchModel): Observable<GenericSearchResponse<any>> {    
    return this._http.post<GenericSearchResponse<any>>(this._serviceUrl + '/search' , this.httpOptions);
  }

  exportSearch(value: searchModel): Observable<any> {
    return this._http.post<any>(this._serviceUrl + '/export-search', this.httpCsvOptions);
  }

  delete(id: ID): Observable<GenericResponse<T>> {
    return this._http.delete<GenericResponse<T>>(this._serviceUrl + "/" + id, this.httpOptions);
  }

  
}
