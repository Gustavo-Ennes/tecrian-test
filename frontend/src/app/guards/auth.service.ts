import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private router: Router) {}

  // Retorna o token armazenado no localStorage
  getToken(): string | null {
    return this.isBrowser() ? localStorage.getItem('token') : null;
  }

  // Verificar se está no browser antes de acessar o localStorage
  private isBrowser(): boolean {
    return typeof window !== 'undefined' && typeof localStorage !== 'undefined';
  }

  // Decodifica o token e retorna as informações (claims)
  getDecodedToken(): any {
    const token = this.getToken();
    if (token) {
      return jwtDecode(token);
    }
    return null;
  }

  // Verifica se o token é válido
  isLoggedIn(): boolean {
    const token = this.getToken();
    if (token) {
      const decodedToken = this.getDecodedToken();
      const isExpired = Date.now() > decodedToken.exp * 1000;
      return !isExpired;
    }
    return false;
  }

  // Verifica se o usuário tem email verificado
  isEmailVerified(): boolean {
    const decodedToken = this.getDecodedToken();
    return decodedToken ? decodedToken.IsEmailVerified === 'True' : false;
  }

  // Remove o token do localStorage (logout)
  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }

  saveToken(token: any) {
    if (this.isBrowser()) localStorage.setItem('token', token);
  }
}
