import { Component } from '@angular/core';
import { SignupFormComponent } from './signup-form/signup-form.component';

@Component({
  standalone: true,
  selector: 'app-signup-page',
  templateUrl: './signup-page.component.html',
  imports: [SignupFormComponent],
})
export class SignupPageComponent {}
