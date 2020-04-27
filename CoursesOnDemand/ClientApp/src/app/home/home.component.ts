import { Component, OnInit } from '@angular/core';

import { Student } from '../_models/student';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  public currentUser: Student;

  constructor() {
    
   }

  ngOnInit() {
    this.currentUser = localStorage.getItem('currentUser') ? JSON.parse(localStorage.getItem('currentUser')) : '';    
  }

}
