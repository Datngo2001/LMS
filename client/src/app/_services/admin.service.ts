import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Faculty } from '../_model/Faculty';
import { User } from '../_model/user';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getUserWithRoles() {
    return this.http.get<User[]>(this.baseUrl + 'admin/users-with-roles');
  }

  updateUserRoles(username, roles) {
    return this.http.post(this.baseUrl + 'admin/edit-roles/' + username + '?roles=' + roles, {});
  }

  createFaculty(faculty) {
    return this.http.post(this.baseUrl + 'admin/createfaculty', faculty);
  }

  addMajorToFaculty(fName, major) {
    return this.http.post(this.baseUrl + 'admin/' + fName + '/addmajor', major);
  }

  createCourse(mName, course) {
    return this.http.post(this.baseUrl + 'admin/' + mName + '/createcourse', course);
  }

  getFaculies() {
    return this.http.get<Faculty[]>(this.baseUrl + 'admin/faculties');
  }
}
