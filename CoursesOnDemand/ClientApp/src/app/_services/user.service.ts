import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { BehaviorSubject, Observable } from 'rxjs';
import { Student } from '../_models/student';
import { CreditCard } from '../_models/creditcard';

@Injectable({ providedIn: 'root' })
export class UserService {
  constructor(private http: HttpClient) { }
  private currentUserSubject: BehaviorSubject<Student>;
  public currentUser: Observable<Student>;

  register(user: Student) {
    return this.http.post<Student>('user', user)
      .pipe(map(user => {
      if (user) {
        // store user details in local storage to keep user logged in
        localStorage.setItem('currentUser', JSON.stringify(user));        
      }
      return user;
    }));
  }

  update(id:number, user: Student) {
    return this.http.put<Student>('user/' + id, user)
      .pipe(map(user => {
        if (user) {
          // store user details in local storage to keep user logged in
          localStorage.setItem('currentUser', JSON.stringify(user));          
        }
        return user;
      }));
  }

  setcard(id: number, card: CreditCard) {
    return this.http.post<Student>('student/setcard/' + id, card)
      .pipe(map(user => {
        if (user) {
          // store user details in local storage to keep user logged in
          localStorage.setItem('currentUser', JSON.stringify(user));          
        }
        return user;
      }));
  }

  setcourse(idstudent: number, idcourse: number) {
    return this.http.post<Student>(`student/setcourse`, { idstudent, idcourse })
    .pipe(map(user => {
      if (user) {
        // store user details in local storage to keep user logged in
        localStorage.setItem('currentUser', JSON.stringify(user));        
      }
      return user;
    }));
  }

}
