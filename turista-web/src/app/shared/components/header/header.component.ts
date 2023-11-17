import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SharedFunctions } from '../../shared.functions';
import { LocalStorageKeys } from '../../model';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit{
  constructor(
    private router: Router,
    private sharedFunctions: SharedFunctions,
    ) { }

  ngOnInit(): void {
    
  }

  logout(){
    this.sharedFunctions.setLocalStorageValue(LocalStorageKeys.Token, null);
    this.router.navigate(["auth/login"]);
  }

  isAuthenticated(){
    var token = this.sharedFunctions.getLocalStorageValue(LocalStorageKeys.Token);
    return !token;
  }

  login(){
    this.router.navigate(["auth/login"]);
  }
}
