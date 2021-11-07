import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MyCourse } from '../_model/myCourse';
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
  myCourse(sid: number) {
    return this.http.get<MyCourse>(this.baseUrl + "course/mycourse/" + sid, httpOptions);
  }
  myClass() {
    return this.http.get(this.baseUrl + "teacher/myclass", httpOptions);
  }
  classDetail(id: number) {
    return this.http.get(this.baseUrl + "teacher/class/" + id, httpOptions);
  }
}

