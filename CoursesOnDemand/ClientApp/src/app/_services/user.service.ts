import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Student } from '../_models/student';
import { CreditCard } from '../_models/creditcard';

@Injectable({ providedIn: 'root' })
export class UserService {
  constructor(private http: HttpClient) { }

  register(user: Student) {
    return this.http.post('student', user);
  }

  update(id:number, user: Student) {
    return this.http.put('student/'+id, user);
  }

  setcard(id: number, card: CreditCard) {
    return this.http.post('student/setcard/'+id, card);
  }

  setcourse(idstudent: number, idcourse: number) {
    return this.http.post(`student/setcourse`, { idstudent, idcourse });
  }

}
