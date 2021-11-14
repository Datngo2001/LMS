import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Course } from '../_model/Course';
import { CourseCard } from '../_model/CourseCard';
import { CreateCourse } from '../_model/CreateCourse';
import { UpdateCourse } from '../_model/UpdateCourse';


@Injectable({
  providedIn: 'root'
})
export class CourseService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) {
  }
  GetContent(cId: string) {
    return this.http.get<Course>(this.baseUrl + "course/" + cId);
  }
  CourseCard() {
    return this.http.get<CourseCard[]>(this.baseUrl + "course/cards");
  }
  CourseEnrolleCard() {
    return this.http.get<CourseCard[]>(this.baseUrl + "course/enrollecards");
  }
  CreateCrouse(createCourse: CreateCourse) {
    return this.http.post(this.baseUrl + "course/createcourse", createCourse);
  }
  UpdateCrouse(updateCourse: UpdateCourse) {
    return this.http.post(this.baseUrl + "course/updatecourse", updateCourse);
  }
  DeleteCrouse(cId: string) {
    return this.http.get(this.baseUrl + "course/deletecourse/" + cId);
  }
}
