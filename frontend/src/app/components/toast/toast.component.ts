import { CommonModule } from '@angular/common';
import { Component, OnInit, Input, Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ToastService } from './toast.service';

@Injectable({
  providedIn: 'root',
})
@Component({
  selector: 'app-toast',
  standalone: true,
  templateUrl: './toast.component.html',
  imports: [CommonModule],
  styleUrls: ['./toast.component.scss'],
})
export class ToastComponent {
  @Input() duration: number = 3000;
  toastState: { message: string; isVisible: boolean; } | null =
    null;

  constructor(private toastService: ToastService) {
    this.toastService.toastState$.subscribe((state) => {
      this.toastState = state;
    });
  }

  closeToast() {
    this.toastState = null; // Ou faça isso através do serviço, se preferir
  }
}
