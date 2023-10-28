import { HttpErrorResponse } from '@angular/common/http';
import { DatePipe } from '@angular/common';
import { Router } from '@angular/router';
import { Injectable, HostListener } from '@angular/core';
import { environment } from '../../environments/environment';
import { LocalStorageKeys, Usuario } from 'src/app/shared/model';
import { map, catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})

export class SharedFunctions {
    constructor(
        private router: Router,
        private datePipe: DatePipe,
        protected _http: HttpClient
    ) {
    }

    public showMessage(mensaje: string, titulo: string) {
        
    }

    public showConfirm(mensaje: string, titulo: string) {
       
    }

    public handleError(err: HttpErrorResponse, showErrorMessage: boolean = false) {

        var errorMessage = "";
        
        if (err != null)
        {
            if( typeof err === 'object'){

            
            switch (err.status)
            {
                //Server caido
                case 0:
                    errorMessage = "Ocurrió un error comunicándose con el servidor";
                    break;

                //Usuario no logueado / Sesion expirada / Token vencido
                case 401:
                    errorMessage = "Su sesión expiró. Por favor iniciela nuevamente";

                    this.router.navigate(['auth/login']);
                    break;
            
                default:
                    errorMessage = err?.error?.Message ?? "Ocurrió un error solicitando los datos al servidor";
                    break;
            }
        }
        }
        else
             errorMessage =  "Ocurrió un error solicitando los datos al servidor";

        if (showErrorMessage)
            this.showMessage(errorMessage, "Error");

        return errorMessage;
    }

    public clearLocalStorage() {
        this.setLocalStorageValue(LocalStorageKeys.Token, null);
        this.setLocalStorageValue(LocalStorageKeys.Menu, null);
        this.setLocalStorageValue(LocalStorageKeys.Usuario, null);
        this.setLocalStorageValue(LocalStorageKeys.TenantId, null);
        this.setLocalStorageValue(LocalStorageKeys.NamesToReplace, null);

        localStorage.removeItem(LocalStorageKeys.Usuario);
        localStorage.removeItem(LocalStorageKeys.Menu);
        localStorage.removeItem(LocalStorageKeys.Token);
        localStorage.removeItem(LocalStorageKeys.TenantId);
        localStorage.removeItem(LocalStorageKeys.NamesToReplace);
    }

    public setLocalStorageValue(key: string, value: any) {
        try {
            return localStorage.setItem(key, value);
        }
        catch(e) {
            console.error(e);
        }

        return null;
    }

    public getLocalStorageValue(key: string): any {
        try {
            return localStorage.getItem(key);
        }
        catch(e) {
            console.error(e);
        }

        return null;
    }

    // public getLoggedUser(): Usuario {
    //     try {
    //         return JSON.parse(this.getLocalStorageValue(LocalStorageKeys.Usuario));
    //     }
    //     catch(e) {
    //         console.error(e);
    //     }

    //     return null;
    // }

    public getLoggedUserMenus() {
        try {
            return JSON.parse(this.getLocalStorageValue(LocalStorageKeys.Menu));
        }
        catch(e) {
            console.error(e);
        }
        
        return null;
    }

    public getRichTextToolbarItems(): object {
        return {
            items: ['Undo', 'Redo', '|',
                'Bold', 'Italic', 'Underline', 'StrikeThrough', '|',
                'FontName', 'FontSize', 'FontColor', 'BackgroundColor', '|',
                'SubScript', 'SuperScript', '|',
                'LowerCase', 'UpperCase', '|',
                'Formats', 'Alignments', '|', 'OrderedList', 'UnorderedList', '|',
                'Indent', 'Outdent', '|', 'CreateLink',
                'Image', '|', 'ClearFormat', 'Print', 'SourceCode' /*, '|', 'FullScreen'*/
            ]
        };
    }

  

    public convertToQueryString<T>(value: T) {
        var queryString = "";
        if (value != null)
            Object.keys(value)?.forEach(e => {

                if (value[e] != null && value[e].toString().length > 0) {
                    queryString += (queryString.length == 0 ? "?" : "&") + e + "=";

                    if ((typeof value[e]).toString() == "object") {
                        //Para verificar si se trata de una fecha
                        if (value[e].toString().includes("GMT"))
                            queryString += this.datePipe.transform(value[e],"yyyy-MM-dd");
                        else
                            queryString += value[e];
                    }
                    else
                        queryString += value[e];
                }
            });

        return queryString;
    }

    public reloadCurrentRoute() {
        let currentUrl = this.router.url;
        this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
            this.router.navigate([currentUrl]);
        });
    }

    public getMonthList() {
        return [
            { Id: 1, Nombre: "Enero" },
            { Id: 2, Nombre: "Febrero" },
            { Id: 3, Nombre: "Marzo" },
            { Id: 4, Nombre: "Abril" },
            { Id: 5, Nombre: "Mayo" },
            { Id: 6, Nombre: "Junio" },
            { Id: 7, Nombre: "Julio" },
            { Id: 8, Nombre: "Agosto" },
            { Id: 9, Nombre: "Septiembre" },
            { Id: 10, Nombre: "Octubre" },
            { Id: 11, Nombre: "Noviembre" },
            { Id: 12, Nombre: "Diciembre" }
        ];
    }

    public checkIfFileExists(url: string): Observable<boolean> {
        if (url != null && url.length > 0)
            return this._http.get(url).pipe(map(() => true), catchError(() => of(false)));
        return of(false);
    }

    // public formatPublicidadName(Publicidad: Publicidad): string{
    //     if((Publicidad?.Nombre != null && Publicidad?.Nombre?.length > 0) && (Publicidad?.Direccion != null && Publicidad?.Direccion?.length > 0)){
    //         return `${Publicidad.Nombre.toUpperCase()} (${Publicidad.Direccion})`;
    //     }else if(Publicidad?.Nombre != null && Publicidad?.Nombre?.length > 0){
    //         return `${Publicidad.Nombre.toUpperCase()}`;
    //     }
    //     return "";
    // }

    // public getNombreMenuTenant(nombre: string): string {
    //     try {
    //         var menuNameList = this.getLocalStorageValue(LocalStorageKeys.NamesToReplace);
    //         if (menuNameList != null && menuNameList.length > 0)
    //             return JSON.parse(menuNameList)[nombre] ?? nombre;
    //         return nombre;
    //     }
    //     catch {
    //         return nombre;
    //     }
    // }

    // @HostListener('window:resize', ['$event'])
    public sizeView() {
       return (window.screen.width < 500);
    }
}
