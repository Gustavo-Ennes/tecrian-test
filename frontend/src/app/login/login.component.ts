import { Component } from '@angular/core';
import { LoginFormComponent } from './login-form/login-form.component';

@Component({
  standalone: true,
  selector: 'app-login-page',
  templateUrl: './login.component.html',
  imports: [LoginFormComponent],
})
export class LoginPageComponent {}
