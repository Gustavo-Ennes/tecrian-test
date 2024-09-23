import { Component, ViewChild } from '@angular/core';
import { PasswordInputComponent } from '../../components/password-input/password-input.component';
import { TextInputComponent } from '../../components/text-input/text-input.component';
import { SubmitButtonComponent } from '../../components/submit-button/submit-button.component';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { SignupService } from '../signup-page.service';

@Component({
  selector: 'app-signup-form',
  templateUrl: './signup-form.component.html',
  styleUrls: ['./signup-form.component.scss'],
  imports: [
    ReactiveFormsModule,
    PasswordInputComponent,
    TextInputComponent,
    SubmitButtonComponent,
  ],
  standalone: true,
})
export class SignupFormComponent {
  signupForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private signupService: SignupService
  ) {
    this.signupForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      confirmPassword: ['', Validators.required],
    });
  }

  submitForm() {
    if (
      this.signupForm.get('password')?.value ===
      this.signupForm.get('confirmPassword')?.value
    ) {
      // Chamar o serviço de signup
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
            console.error('Erro ao criar o usuário:', error);
            alert('Erro ao criar o usuário. Tente novamente.');
          },
        });
    } else {
      alert('As senhas não conferem!');
    }
  }
}
