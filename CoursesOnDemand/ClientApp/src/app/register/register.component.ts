import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

import { UserService } from '../_services/user.service';
import { Student } from '../_models/student';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent implements OnInit {

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private userService: UserService,
    private toastr: ToastrService    
  ) { }

  registerForm: FormGroup;
  loading = false;
  submitted = false;
  currentUser: Student;  

  ngOnInit() {
    this.currentUser = localStorage.getItem('currentUser') ? JSON.parse(localStorage.getItem('currentUser')) : '';
    this.registerForm = this.formBuilder.group({
      firstName: [this.currentUser.firstName, Validators.required],
      lastName: [this.currentUser.lastName, Validators.required],
      phone: [this.currentUser.phone, Validators.required],
      email: [this.currentUser.email, [Validators.required, Validators.email]],
      password: [this.currentUser.password, [Validators.required, Validators.minLength(6)]],      
  });
  }

  get fval() { return this.registerForm.controls; }

  onFormSubmit(){
    this.submitted = true;
    // return for here if form is invalid
    if (this.registerForm.invalid) {
      return;
    }
    this.loading = true;

    if (this.currentUser.token) {
      this.userService.update(this.currentUser.id, this.registerForm.value).subscribe(
        (data) => {
          alert('User Profile Updated successfully!');
          this.router.navigate(['/home']);
        },
        (error) => {
          this.toastr.error(error.error, 'Error');
          this.loading = false;
        }
      )
    } else {
      this.userService.register(this.registerForm.value).subscribe(
        (data) => {
          alert('User Registered successfully!');
          this.router.navigate(['/login']);
        },
        (error) => {
          this.toastr.error(error.error, 'Error');
          this.loading = false;
        }
      )
    }

  }

}
