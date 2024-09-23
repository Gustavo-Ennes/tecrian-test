import { CommonModule } from '@angular/common';
import { Component, Input, OnChanges } from '@angular/core';

@Component({
  selector: 'app-password-strength',
  templateUrl: './password-strength.component.html',
  styleUrls: ['./password-strength.component.scss'],
  imports: [CommonModule],
  standalone: true,
})
export class PasswordStrengthComponent implements OnChanges {
  @Input() password: string = '';
  strength: boolean[] = [false, false, false, false];
  passwordStrenghtLabel: string = '';

  ngOnChanges(): void {
    this.mesureStrength();
  }

  mesureStrength(): void {
    const strenght = this.evaluatePassword();
    this.strength = [
      strenght >= 25,
      strenght >= 50,
      strenght >= 75,
      strenght == 100,
    ];

    switch (strenght) {
      case 25:
        this.passwordStrenghtLabel = 'Very weak';
        break;
      case 50:
        this.passwordStrenghtLabel = 'Weak';
        break;
      case 75:
        this.passwordStrenghtLabel = 'Almost there';
        break;
      case 100:
        this.passwordStrenghtLabel = 'Perfect!';
        break;
      default:
        '';
        break;
    }
  }

  evaluatePassword() {
    let strenght = 0;

    if (this.password.length >= 8) strenght += 25;
    if (/\d/.test(this.password)) strenght += 25;
    if (/[A-Z]/.test(this.password)) strenght += 25;
    if (/[!@#$%^&*(),.?":{}|<>]/.test(this.password)) strenght += 25;

    return strenght;
  }
}
