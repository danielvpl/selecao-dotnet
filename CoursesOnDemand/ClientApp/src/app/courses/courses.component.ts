import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HttpClient } from '@angular/common/http';

import { UserService } from '../_services/user.service';
import { Course } from '../_models/course';
import { Student } from '../_models';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html'
})

export class CoursesComponent {
  public courses: Course[];

  constructor(http: HttpClient,
    private formBuilder: FormBuilder,
    private router: Router,
    private userService: UserService,
    private toastr: ToastrService) {
    http.get<Course[]>('course').subscribe(result => {
      this.courses = result;
    }, error => console.error(error));
  }

  loading = false;
  submitted = false;
  currentUser: Student;
  registerForm: FormGroup;
  selectedCourse: number;

  ngOnInit() {
    this.currentUser = localStorage.getItem('currentUser') ? JSON.parse(localStorage.getItem('currentUser')) : '';
    if (this.currentUser.course) {
      this.selectedCourse = this.currentUser.course.id;
    } else {
      this.selectedCourse = 0;
    }
    this.registerForm = this.formBuilder.group({
      idcourse: ['', Validators.required]
    });
  }

  get fval() { return this.registerForm.controls; }
  
  onFormSubmit3() {
    this.currentUser = localStorage.getItem('currentUser') ? JSON.parse(localStorage.getItem('currentUser')) : '';

    this.submitted = true;
    // return for here if form is invalid
    if (this.registerForm.invalid) {
      return;
    }
    this.loading = true;

    if (this.currentUser.token) {      
      this.userService.setcourse(this.currentUser.id, parseInt(this.fval.idcourse.value)).subscribe(
        (data) => {
          alert('Course Registered Successfully! An email was sent to [' + this.currentUser.email+']');
          this.router.navigate(['/home']);
        },
        (error) => {
          this.toastr.error(error.error, 'Error');
          this.loading = false;
        }
      )
    } 
  }

}
