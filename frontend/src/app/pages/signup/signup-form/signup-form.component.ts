import { Component, ViewChild } from '@angular/core';
import { PasswordInputComponent } from '../../../components/password-input/password-input.component';
import { TextInputComponent } from '../../../components/text-input/text-input.component';
import { SubmitButtonComponent } from '../../../components/submit-button/submit-button.component';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { SignupService } from '../signup-page.service';
import { ToastService } from '../../../components/toast/toast.service';
import { ToastComponent } from '../../../components/toast/toast.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-signup-form',
  templateUrl: './signup-form.component.html',
  styleUrls: ['./signup-form.component.scss'],
  imports: [
    ReactiveFormsModule,
    CommonModule,
    PasswordInputComponent,
    TextInputComponent,
    SubmitButtonComponent,
    ToastComponent,
  ],
  standalone: true,
})
export class SignupFormComponent {
  signupForm: FormGroup;
  errorMessage: string = '';

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private signupService: SignupService,
    private toastService: ToastService
  ) {
    this.signupForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      confirmPassword: ['', Validators.required],
    });
  }

  canSubmit() {
    return (
      this.signupForm.valid &&
      this.signupForm.get('password')?.value ===
        this.signupForm.get('confirmPassword')?.value
    );
  }

  submitForm() {
    if (
      this.signupForm.get('password')?.value ===
      this.signupForm.get('confirmPassword')?.value
    ) {
      this.signupService
        .signup({
          name: this.signupForm.get('name')?.value,
          email: this.signupForm.get('email')?.value,
          password: this.signupForm.get('password')?.value,
        })
        .subscribe({
          next: (response) => {
            console.log('Token recebido:', response.token);
            this.router.navigate(['/non-verified']);
          },
          error: (error) => {
            this.errorMessage = error.message;
            this.toastService.showToast(`Signup error: ${error.message}`);
          },
        });
    } else {
      alert('As senhas não conferem!');
    }
  }
}
