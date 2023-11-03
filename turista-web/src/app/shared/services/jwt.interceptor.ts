import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from "rxjs/operators";
import { throwError } from "rxjs";
import { Router } from '@angular/router';
import { DatePipe } from '@angular/common';
import { SharedFunctions } from 'src/app/shared/shared.functions';
import { LocalStorageKeys } from '../model/constants';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor(
        private sharedFunctions: SharedFunctions,
        private datePipe: DatePipe,
        private router: Router
    ) {}
    
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // add authorization header with jwt token if available
        try
        {
            if (this.sharedFunctions == null)
                this.sharedFunctions = new SharedFunctions(this.router, this.datePipe,null);

            let t = this.sharedFunctions.getLocalStorageValue(LocalStorageKeys.Token);

            if (t != null && t.length > 0) {
                request = request.clone({
                    setHeaders: {
                        Authorization: `Bearer ${t}`
                    }
                });
            }
        }
        catch (err) {
            console.error(err);
        }

        return next.handle(request).pipe(
            map(this.handleSuccess),
            catchError(this.handleError)
        );
    }

    handleSuccess(event) {
        

        if (this.sharedFunctions == null)
            this.sharedFunctions = new SharedFunctions(this.router, this.datePipe, null);

        if (event instanceof HttpResponse) {
          
            
            if (event != null)
            {
                if (event.status === 200 || event.status === 204)
                {
                    var tt = event?.body?.UpdatedToken;
                    if (tt != null && tt?.length > 0)
                    {
                        this.sharedFunctions.setLocalStorageValue(LocalStorageKeys.Token, tt);
                        
                    }
                }
            }
        }
        return event;
    }

    handleError(err: HttpErrorResponse) {


        if (this.sharedFunctions == null)
            this.sharedFunctions = new SharedFunctions(this.router, this.datePipe, null);

        if (err != null)
        {
            switch (err.status)
            {
                //Server caido
                case 0:
                    // return throwError("Ocurrió un error solicitando los datos al servidor");
                    break;

                //Usuario no logueado / Sesion expirada / Token vencido
                case 401:
                    this.sharedFunctions.clearLocalStorage();
                    // return throwError("Su sesión expiró. Por favor iniciela nuevamente");
                    break;
            
                default:
                    break;
            }
        }

        //Server sin respuesta conocida
        return throwError(err);
    }
}
