import { Component, forwardRef, Input } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'app-password-input',
  templateUrl: './password-input.component.html',
  styleUrls: ['./password-input.component.scss'],
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
