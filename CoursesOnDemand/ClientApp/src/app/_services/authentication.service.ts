import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { Student } from '../_models/student';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
  private currentUserSubject: BehaviorSubject<Student>;
  public currentUser: Observable<Student>;

    constructor(private http: HttpClient) {
      this.currentUserSubject = new BehaviorSubject<Student>(JSON.parse(localStorage.getItem('currentUser')));
        this.currentUser = this.currentUserSubject.asObservable();
    }

  public get currentUserValue(): Student {
        return this.currentUserSubject.value;
    }

    login(email: string, password: string) {
      return this.http.post<Student>(`user/login`, { email, password })
            .pipe(map(user => {
              if (user && user.token) {
                // store user details in local storage to keep user logged in
                localStorage.setItem('currentUser', JSON.stringify(user));
                this.currentUserSubject.next(user);
              }
              return user;
            }));
    }

    logout() {
        // remove user data from local storage for log out
        localStorage.removeItem('currentUser');
        this.currentUserSubject.next(null);
    }
}
