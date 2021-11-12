import { Component, OnInit } from '@angular/core';
import { Faculty } from 'src/app/_model/Faculty';
import { AdminService } from 'src/app/_services/admin.service';

@Component({
  selector: 'app-faculty-management',
  templateUrl: './faculty-management.component.html',
  styleUrls: ['./faculty-management.component.css']
})
export class FacultyManagementComponent implements OnInit {

  faculties: Partial<Faculty[]>

  constructor(private adminService: AdminService) { }

  ngOnInit(): void {
    this.getAllFaculies()
  }

  getAllFaculies() {
    this.adminService.getFaculies().subscribe(faculties => {
      this.faculties = faculties
      console.log(this.faculties)
      console.log(this.faculties[0].majors.length)
    })
  }

  openFalculyModal(faculty = null) {

  }
}
