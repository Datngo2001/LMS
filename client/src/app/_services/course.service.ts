import { Injectable } from '@angular/core';
import { Course } from '../_model/course';

@Injectable({
  providedIn: 'root'
})
export class CourseService {
  formData: Course;
  constructor() { }
}
