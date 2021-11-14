import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CreateLesson } from '../_model/CreateLesson';
import { UpdateLesson } from '../_model/UpdateLesson';

@Injectable({
  providedIn: 'root'
})
export class LessonService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }
  CreateLesson(createLesson: CreateLesson) {
    return this.http.post(this.baseUrl + "lesson/createlesson", createLesson);
  }
  UpdateLesson(updateLesson: UpdateLesson) {
    return this.http.post(this.baseUrl + "lesson/updatelesson", updateLesson);
  }
  DeleteLesson(cId: string) {
    return this.http.get(this.baseUrl + "lesson/deletelesson/" + cId);
  }
}
