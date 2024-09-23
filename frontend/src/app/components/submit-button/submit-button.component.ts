import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-submit-button',
  templateUrl: './submit-button.component.html',
  styleUrls: ['./submit-button.component.scss'],
  standalone: true,
})
export class SubmitButtonComponent {
  label:string = ""
  @Input() isDisabled: boolean = true;
}
