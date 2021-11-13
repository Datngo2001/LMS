import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CourseCard } from '../_model/CourseCard';

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
    return this.http.get<CourseCard[]>(this.baseUrl + "course/cards", httpOptions);
  }
}

