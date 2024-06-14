import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, catchError, of, tap } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private isLoggedInSubject = new BehaviorSubject<boolean>(false);
  isLoggedIn$ = this.isLoggedInSubject.asObservable();

  private token?: string;

  constructor(private http: HttpClient, private router: Router) { }

  isAuth(): boolean {
    return !!this.token;
  }

  getToken(): string | undefined {
    return this.token;
  }

  //login(login: Login): Observable<void> {
  //  return this.http
  //    .post<LoginResponse>('http://localhost:5245/login', login)
  //    .pipe(
  //      tap((response) => {
  //        this.token = response.accessToken;
  //        this.isLoggedInSubject.next(true);
  //      }),
  //      catchError((error) => {
  //        console.error('Error:', error);
  //        this.isLoggedInSubject.next(false);
  //        return of(null);
  //      })
  //    );
  //}
  logout(): void {
    this.token = undefined;
    this.isLoggedInSubject.next(false);
    this.router.navigate(['/login']);
  }


}

//export interface LoginResponse {
//  accessToken: string;
//  // Add other properties expected in the response (e.g., error message)
//}
//export interface Login {
//  username: string;
//  password: string;
//}
