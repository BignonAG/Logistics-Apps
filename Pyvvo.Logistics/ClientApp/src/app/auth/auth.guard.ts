import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { JwtHelperService } from "@auth0/angular-jwt";

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  helper: JwtHelperService;

  constructor(private router: Router) {
    this.helper = new JwtHelperService();
  }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    var token = localStorage.getItem("token");
    if (token != null && token != "" && !this.helper.isTokenExpired(token)) 
      return true;
    else {
      localStorage.removeItem("token");
      this.router.navigateByUrl('auth/sign-in');
      return false;
    }
  }
}
