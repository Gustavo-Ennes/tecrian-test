import { Component, ViewChild } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { PasswordInputComponent } from '../../components/password-input/password-input.component';
import { SubmitButtonComponent } from '../../components/submit-button/submit-button.component';
import { TextInputComponent } from '../../components/text-input/text-input.component';
import { LoginService } from '../login.service';
import { Router } from '@angular/router';
import { ToastComponent } from '../../components/toast/toast.component';
import { CommonModule } from '@angular/common';
import { ToastService } from '../../components/toast/toast.service';

@Component({
  selector: 'app-login-form',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    PasswordInputComponent,
    TextInputComponent,
    SubmitButtonComponent,
    ToastComponent,
    CommonModule,
  ],
  templateUrl: './login-form.component.html',
  styleUrl: './login-form.component.scss',
})
export class LoginFormComponent {
  loginForm: FormGroup;
  errorMessage: string = '';

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private loginService: LoginService,
    private toastService: ToastService
  ) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });
  }

  submitForm() {
    // Chamar o serviço de signup
    this.loginService
      .login({
        email: this.loginForm.get('email')?.value,
        password: this.loginForm.get('password')?.value,
      })
      .subscribe({
        next: (response) => {    
          localStorage.setItem('user', JSON.stringify(response.token));
          this.router.navigate(['/home']);
        },
        error: (error) => {
          this.errorMessage = error.message;
          this.toastService.showToast(`Login error: ${error.message}`);
        },
      });
  }
}
