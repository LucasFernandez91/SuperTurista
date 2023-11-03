import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

import { LocalStorageKeys } from '../shared/model/constants';
import { SharedFunctions } from '../shared/shared.functions';

@Injectable()
export class AuthGuard implements CanActivate {

  constructor(
    private router: Router,
    private sharedFunctions: SharedFunctions
  ) {
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) : Observable<boolean|UrlTree>|Promise<boolean|UrlTree>|boolean|UrlTree{
  
    if(state.url != undefined) {
      if(state.url.includes('register')  || state.url.includes('confirm-user')) {
        return true;
      }
    }

    if (!this.sharedFunctions.getLocalStorageValue(LocalStorageKeys.Token)) {
      return this.router.parseUrl("/auth/login");
    }
    
    return true;
  }
}
