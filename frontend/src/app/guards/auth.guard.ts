import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  Router,
} from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root',
})
export class HomeGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {
    const isEmailVerified = this.authService.isEmailVerified();

    if(!isEmailVerified)
      this.router.navigate(['/non-verified']);

    return isEmailVerified
  }
}

@Injectable({
  providedIn: 'root',
})
export class EmailConfirmationGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {
    const tokenExists = this.authService.getDecodedToken();

    if (!tokenExists) this.router.navigate(['signup']);

    return tokenExists;
  }
}