import { Routes } from '@angular/router';
import { LoginPageComponent } from './pages/login/login.component';
import { SignupPageComponent } from './pages/signup/signup-page.component';
import { LoggedPageComponent } from './pages/logged-page/logged-page.component';
import { NonVerifiedPageComponent } from './pages/non-verified-page/non-verified-page.component';
import { EmailConfirmationGuard, HomeGuard } from './guards/auth.guard';

export const routes: Routes = [
  { path: '', redirectTo: 'signup', pathMatch: 'full' },
  { path: 'login', component: LoginPageComponent },
  { path: 'signup', component: SignupPageComponent },
  { path: 'home', component: LoggedPageComponent, canActivate: [HomeGuard] },
  {
    path: 'non-verified',
    component: NonVerifiedPageComponent,
    canActivate: [EmailConfirmationGuard],
  },
];
