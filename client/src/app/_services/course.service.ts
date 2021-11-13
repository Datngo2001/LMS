import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CourseCard } from '../_model/CourseCard';


@Injectable({
  providedIn: 'root'
})
export class CourseService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) {
  }
  CourseCard() {
    return this.http.get<CourseCard[]>(this.baseUrl + "course/cards");
  }
  CourseEnrolleCard() {
    return this.http.get<CourseCard[]>(this.baseUrl + "course/enrollecards");
  }
}
