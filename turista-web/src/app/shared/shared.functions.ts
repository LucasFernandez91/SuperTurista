import { DialogConfirmComponent } from './components/modals/dialog-confirm.component';
import { MatDialog } from '@angular/material/dialog';
import { DialogConfirmRequest2 } from './model/textoLibre';
import { HttpErrorResponse } from '@angular/common/http';
import { DatePipe } from '@angular/common';
import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import {  Usuario } from 'src/app/shared/model';
import { LocalStorageKeys } from './model/constants';

@Injectable({
    providedIn: 'root'
})

export class SharedFunctions {
    constructor(
        private router: Router,
        private datePipe: DatePipe,
        private dialog: MatDialog
    ) {
    }

    public showMessage(mensaje: string, titulo: string, mensaje2:string='' ) {
        const dialogRef = this.dialog.open(DialogConfirmComponent, {
            data: new DialogConfirmRequest2
            (
                titulo,
                mensaje,
                mensaje2,
                "Entendido",
            )
        });
        // DialogUtility.confirm({
        //     title: titulo,
        //     content: mensaje,
        //     okButton: { text: 'Aceptar' },
        //     cancelButton: { text: '' },
        //     showCloseIcon: true,
        //     position: { X: 'center', Y: 'center' },
        //     closeOnEscape: true,
        //     animationSettings: { effect: 'Zoom' }
        // });
    }
    
    public handleError(err: HttpErrorResponse, showErrorMessage: boolean = false) {

        var errorMessage = "";
        
        if (err != null)
        {
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
        else
            errorMessage = "Ocurrió un error solicitando los datos al servidor.";

        if (showErrorMessage)
            this.showMessage(errorMessage, "Error");

        return errorMessage;
    }

    public clearLocalStorage() {
        this.setLocalStorageValue(LocalStorageKeys.Token, null);
        this.setLocalStorageValue(LocalStorageKeys.Menu, null);
        this.setLocalStorageValue(LocalStorageKeys.Usuario, null);

        localStorage.removeItem(LocalStorageKeys.Usuario);
        localStorage.removeItem(LocalStorageKeys.Menu);
        localStorage.removeItem(LocalStorageKeys.Token);
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

    public getLoggedUser(): Usuario {
        try {
            return JSON.parse(this.getLocalStorageValue(LocalStorageKeys.Usuario));
        }
        catch(e) {
            console.error(e);
        }

        return new Usuario(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
    }

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

    public getRichTextImageSettings(resource: string, saveUrl: string, removeUrl: string = ''): object {
        var loggedUser = this.getLoggedUser();
        if (loggedUser == null || loggedUser.Login == null)
            return new Object();

        return {
            // saveFormat: 'Base64',
            path: (environment.uploadTempUrl + resource + "/" + loggedUser.Login + "/").toLowerCase(), //'https://localhost:44376/Temp/MensajeUsuario/admin/',
            saveUrl: saveUrl //'https://localhost:44376/api/mensajeUsuario/attach/temp'
            // removeUrl: removeUrl //'https://ej2.syncfusion.com/services/api/uploadbox/Remove'
        };
    }

    // public convertToQueryString<T>(value: T) {
    //     var queryString = "";
    //     if (value != null)
    //         Object.keys(value)?.forEach(e => {

    //             if (value[e] != null && value[e].toString().length > 0) {
    //                 queryString += (queryString.length == 0 ? "?" : "&") + e + "=";

    //                 if ((typeof value[e]).toString() == "object") {
    //                     //Para verificar si se trata de una fecha
    //                     if (value[e].toString().includes("GMT"))
    //                         queryString += this.datePipe.transform(value[e],"yyyy-MM-dd");
    //                     else
    //                         queryString += value[e];
    //                 }
    //                 else
    //                     queryString += value[e];
    //             }
    //         });

    //     return queryString;
    // }

    public reloadCurrentRoute() {
        let currentUrl = this.router.url;
        this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
            this.router.navigate([currentUrl]);
        });
    }

    public reloadHome() {
        this.router.routeReuseStrategy.shouldReuseRoute = () => false;
        this.router.onSameUrlNavigation = 'reload';
        this.router.navigate(['/home']);  
    }
}