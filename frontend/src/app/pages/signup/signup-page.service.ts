import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { AuthService } from '../../guards/auth.service';

@Injectable({
  providedIn: 'root',
})
export class SignupService {
  private apiUrl = 'http://localhost:5000/api/user/signup';

  constructor(private http: HttpClient, private authService: AuthService) {}

  signup(userData: {
    name: string;
    email: string;
    password: string;
  }): Observable<{ token: string }> {
    return this.http.post<{ token: string }>(this.apiUrl, userData).pipe(
      tap((response) => {
        this.authService.saveToken(response.token);
      })
    );
  }
}
