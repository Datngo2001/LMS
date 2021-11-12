import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Course } from '../_model/Course';


@Injectable({
  providedIn: 'root'
})
export class CourseService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) {
  }
  LoadCourseContent(gid: string) {
    return this.http.get<Course>(this.baseUrl + "course/course?gid=" + gid);
  }
}
