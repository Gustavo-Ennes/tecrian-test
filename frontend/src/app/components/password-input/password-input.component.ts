import { Component, forwardRef, Input } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { PasswordStrengthComponent } from '../password-strength/password-strength.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-password-input',
  templateUrl: './password-input.component.html',
  styleUrls: ['./password-input.component.scss'],
  imports: [CommonModule, PasswordStrengthComponent],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => PasswordInputComponent),
      multi: true,
    },
  ],
  standalone: true,
})
export class PasswordInputComponent implements ControlValueAccessor {
  @Input() label: string = 'Password';
  @Input() passwordStrenght: boolean = false;
  password: string = '';


  onChange = (value: string) => {};
  onTouched = () => {};

  writeValue(obj: any): void {
    this.password = obj;
  }
  registerOnChange(fn: any): void {
    this.onChange = fn;
  }
  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }
  setDisabledState?(isDisabled: boolean): void {}
  
  onInputChange(event: Event): void {
    const input = event.target as HTMLInputElement;
    this.password = input.value;
    this.onChange(this.password);
  }
}
