import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

import { LocalStorageKeys } from 'src/app/shared/model';
import { SharedFunctions } from 'src/app/shared/shared.functions';

@Injectable()
export class AuthGuard implements CanActivate {

  constructor(
    private router: Router,
    private sharedFunctions: SharedFunctions
  ) {
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) : Observable<boolean|UrlTree>|Promise<boolean|UrlTree>|boolean|UrlTree{
    if(state.url != undefined) {
      if(state.url.includes('register')) {
        return true;
      }
    }
    
    if (this.sharedFunctions.getLocalStorageValue(LocalStorageKeys.Token) == null) {
      return this.router.parseUrl("/auth/login");
    }

    return true;
  }
}
