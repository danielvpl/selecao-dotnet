import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

import { UserService } from '../_services/user.service';
import { Student } from '../_models/student';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html'
})
export class PaymentComponent implements OnInit {

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private userService: UserService,
    private toastr: ToastrService    
  ) { }

  registerForm: FormGroup;
  currentUser: Student
  loading = false;
  submitted = false;

  ngOnInit() {
    this.currentUser = localStorage.getItem('currentUser') ? JSON.parse(localStorage.getItem('currentUser')) : '';
    this.registerForm = this.formBuilder.group({
      number: ['', Validators.required],
      validuntil: ['', Validators.required],
      nameoncard: ['', Validators.required],
      scode: ['', Validators.required]
    });
  }

  get fval() { return this.registerForm.controls; }

  onFormSubmit2(){
    this.submitted = true;
    // return for here if form is invalid
    if (this.registerForm.invalid) {
      return;
    }
    this.loading = true;
    this.currentUser = localStorage.getItem('currentUser') ? JSON.parse(localStorage.getItem('currentUser')) : '';
    this.userService.setcard(this.currentUser.id, this.registerForm.value).subscribe(
      (data)=>{
        alert('Credit Card Registered successfully. Payment in the amount of R$14,90 confirmed.');
        this.router.navigate(['/courses']);
     },
      (error)=>{
        this.toastr.error(error.error, 'Error');
        this.loading = false;
      }
    )

  }
}
