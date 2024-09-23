import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ToastService {
  private toastSubject = new BehaviorSubject<{
    message: string;
    isVisible: boolean;
  }>({
    message: '',
    isVisible: false,
  });

  toastState$ = this.toastSubject.asObservable();

  showToast(message: string) {
    this.toastSubject.next({ message, isVisible: true });
    setTimeout(() => {
      this.toastSubject.next({ message: '', isVisible: false });
    }, 3000); // 3 segundos
  }
}
