import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { AuthService } from '../../guards/auth.service';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  private apiUrl = 'http://localhost:5000/api/user/login';

  constructor(private http: HttpClient, private authService: AuthService) {}

  login(userData: {
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
