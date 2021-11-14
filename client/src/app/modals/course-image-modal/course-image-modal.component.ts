import { Component, OnInit } from '@angular/core';
import { FileUploader } from 'ng2-file-upload';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { User } from 'src/app/_model/user';
import { AccountService } from 'src/app/_services/account.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-course-image-modal',
  templateUrl: './course-image-modal.component.html',
  styleUrls: ['./course-image-modal.component.css']
})
export class CourseImageModalComponent implements OnInit {

  cId: string;
  uploader: FileUploader;
  hasBaseDropZoneOver = false;
  baseUrl = environment.apiUrl;
  user: User;

  constructor(public bsModalRef: BsModalRef, private accontService: AccountService, private toast: ToastrService) {
    this.accontService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
  }

  ngOnInit(): void {
    this.innitializeUploader();
  }

  fileOverBase(e: any) {
    this.hasBaseDropZoneOver = e;
  }

  innitializeUploader() {
    // max 10MB
    this.uploader = new FileUploader({
      url: (this.baseUrl + 'course/updateimage/' + this.cId),
      authToken: 'Bearer ' + this.user.token,
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10000000,
      queueLimit: 1,
    })

    this.uploader.onAfterAddingFile = (file) => {
      file.withCredentials = false
    }

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      this.toast.success("Photo uppoaded")
    }
  }

  cancel() {
    this.bsModalRef.hide()
  }
}
