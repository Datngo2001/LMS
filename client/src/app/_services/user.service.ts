import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {
  }

  Enroll(cId: number){
    return this.http.get(this.baseUrl + "user/enroll/" + cId);
  }
}
