import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Course } from '../_model/Course';

const httpOptions = {
  headers: new HttpHeaders({
    //Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user')).token
  })
}
@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }
  CourseCard() {
    return this.http.get<Course[]>(this.baseUrl + "course/mycourses/", httpOptions);
  }
  myClass() {
    return this.http.get(this.baseUrl + "teacher/myclass", httpOptions);
  }
  classDetail(id: number) {
    return this.http.get(this.baseUrl + "teacher/class/" + id, httpOptions);
  }
}

