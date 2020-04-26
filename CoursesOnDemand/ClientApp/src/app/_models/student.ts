import { CreditCard } from './creditcard';
import { Course } from './course';

export class Student {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  phone: string;
  //User data attributes
  password: string;
  token: string;
  Course: Course;
  CreditCard: CreditCard
}
