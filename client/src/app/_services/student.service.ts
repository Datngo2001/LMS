import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Student } from '../_model/student';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  private baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }
  createStudent(model: any) {

    return this.http.post(this.baseUrl + "student/create", model).pipe(
      map((student: Student) => {
        if (student) {
          localStorage.setItem('student', JSON.stringify(student));
        }
      })
    )
  }
}
