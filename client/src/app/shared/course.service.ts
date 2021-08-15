import { Injectable } from '@angular/core';
import { Course } from './course.model';

@Injectable({
  providedIn: 'root'
})
export class CourseService {
  formData: Course;
  constructor() { }
}
