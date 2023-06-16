import { HttpClient } from '@angular/common/http';
import { Component, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { CreateService } from 'src/app/_services/create.service';
import { UpdateService } from 'src/app/_services/update.service';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-meta-files',
  templateUrl: './meta-files.component.html',
  styleUrls: ['./meta-files.component.css']
})
export class MetaFilesComponent {
  baseUrl = environment.apiUrl;

  modalRef!: BsModalRef;

  message: string = "";

  searchText: string = "";

  issueType: any;
  issueStatus: any;
  contractType: any;
  serviceType: any;
  userRoles: any;

  its:any;

  addIssueTypeForm: FormGroup = new FormGroup({});

  EditIssueTypeForm: FormGroup = new FormGroup({});

  constructor(private http: HttpClient, private modalService: BsModalService, private toastr: ToastrService,
    private updateService: UpdateService, private createService: CreateService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.getIssueTypes();
    this.getIssueStatus();
    this.getContractType();
    this.getServiceType();
    this.getUserRoles();
    this.IntializForm();

  }

  // get TotalUsers():number {
  //  return this.users.length;
  // }


  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, { class: 'modal-lg w-100 h-100' });
  }

  IntializForm() {
    this.addIssueTypeForm = this.fb.group({
      lokupId: ['', Validators.required],
      lokupValue: ['', Validators.required],
    })

  }



  AddIssueType() {
    this.createService.AddIssueType(this.addIssueTypeForm.value).subscribe({
      next: () => {
        this.modalRef.hide()
      },
      error: error => {

        console.log(error),

          this.toastr.error("برجاء ادخال القيم المطلوبة")

      },
      complete: () => {
        this.ngOnInit();
        this.toastr.success("تم اضافة نوع المهمة بنجاح");
      }
    });

  }
  AddIssueStatus() {
    this.createService.AddIssueStatus(this.addIssueTypeForm.value).subscribe({
      next: () => {
        this.modalRef.hide()
      },
      error: error => {

        console.log(error),

          this.toastr.error("برجاء ادخال القيم المطلوبة")

      },
      complete: () => {
        this.ngOnInit();
        this.toastr.success("تم اضافة حالة المهمة بنجاح");
      }
    });

  }
  AddContractType() {
    this.createService.AddContractType(this.addIssueTypeForm.value).subscribe({
      next: () => {
        this.modalRef.hide()
      },
      error: error => {

        console.log(error),

          this.toastr.error("برجاء ادخال القيم المطلوبة")

      },
      complete: () => {
        this.ngOnInit();
        this.toastr.success("تم اضافة نوع العقد بنجاح");
      }
    });

  }
  AddServiceType() {
    this.createService.AddServiceType(this.addIssueTypeForm.value).subscribe({
      next: () => {
        this.modalRef.hide()
      },
      error: error => {

        console.log(error),

          this.toastr.error("برجاء ادخال القيم المطلوبة")

      },
      complete: () => {
        this.ngOnInit();
        this.toastr.success("تم اضافة نوع الخدمة بنجاح");
      }
    });

  }
  AddUserRoles() {
    this.createService.AddUserRoles(this.addIssueTypeForm.value).subscribe({
      next: () => {
        this.modalRef.hide()
      },
      error: error => {

        console.log(error),

          this.toastr.error("برجاء ادخال القيم المطلوبة")

      },
      complete: () => {
        this.ngOnInit();
        this.toastr.success("تم اضافة  صلحية المستخدم بنجاح");
      }
    });

  }

  getIT(id:string){
    this.http.get(this.baseUrl+'user/GetIssueType/'+id).subscribe({
      next: response => this.its = response,
      error:  error => {
        this.toastr.error(error.error),
          console.log(error);
      },
      complete : () => console.log(this.its)
    })
  }

  updateIssueType(id:string){
    this.updateService.UpdateIssueType(id,this.its).subscribe({
      next: () => this.modalRef.hide(),
      error: error => {
        this.toastr.error(error.error),
          console.log(error);
      },
      complete: () => {
        this.ngOnInit();
        this.toastr.success("تم نعديل نوع القضية بنجاح");
      }
   });
 }


 
 getIS(id:string){
  this.http.get(this.baseUrl+'user/GetIssueStatus/'+id).subscribe({
    next: response => this.its = response,
    error:  error => {
      this.toastr.error(error.error),
        console.log(error);
    },
    complete : () => console.log(this.its)
  })
}

updateIssueStatus(id:string){
  this.updateService.UpdateIssueStatus(id,this.its).subscribe({
    next: () => this.modalRef.hide(),
    error: error => {
      this.toastr.error(error.error),
        console.log(error);
    },
    complete: () => {
      this.ngOnInit();
      this.toastr.success("تم نعديل حالة القضية بنجاح");
    }
 });
}


getCT(id:string){
  this.http.get(this.baseUrl+'user/GetContractType/'+id).subscribe({
    next: response => this.its = response,
    error:  error => {
      this.toastr.error(error.error),
        console.log(error);
    },
    complete : () => console.log(this.its)
  })
}

updateContractType(id:string){
  this.updateService.UpdateContractTypes(id,this.its).subscribe({
    next: () => this.modalRef.hide(),
    error: error => {
      this.toastr.error(error.error),
        console.log(error);
    },
    complete: () => {
      this.ngOnInit();
      this.toastr.success("تم نعديل نوع العقد بنجاح");
    }
 });
}

getST(id:string){
  this.http.get(this.baseUrl+'user/GetServiceType/'+id).subscribe({
    next: response => this.its = response,
    error:  error => {
      this.toastr.error(error.error),
        console.log(error);
    },
    complete : () => console.log(this.its)
  })
}

updateServiceType(id:string){
  this.updateService.UpdateServiceTypes(id,this.its).subscribe({
    next: () => this.modalRef.hide(),
    error: error => {
      this.toastr.error(error.error),
        console.log(error);
    },
    complete: () => {
      this.ngOnInit();
      this.toastr.success("تم نعديل نوع الخدمة بنجاح");
    }
 });
}


getUR(id:string){
  this.http.get(this.baseUrl+'user/GetUserRole/'+id).subscribe({
    next: response => this.its = response,
    error:  error => {
      this.toastr.error(error.error),
        console.log(error);
    },
    complete : () => console.log(this.its)
  })
}

updateUserRole(id:string){
  this.updateService.UpdateUserRoles(id,this.its).subscribe({
    next: () => this.modalRef.hide(),
    error: error => {
      this.toastr.error(error.error),
        console.log(error);
    },
    complete: () => {
      this.ngOnInit();
      this.toastr.success("تم نعديل صلحية المستخدم بنجاح");
    }
 });
}



  getIssueTypes() {
    this.http.get(this.baseUrl + 'user/GetIssueTypes').subscribe({
      next: response => this.issueType = response,
      error: error => console.log(error),

    })
  }

  getIssueStatus() {
    this.http.get(this.baseUrl + 'user/GetIssueStatus').subscribe({
      next: response => this.issueStatus = response,
      error: error => console.log(error),
    })
  }



  getContractType() {
    this.http.get(this.baseUrl + 'user/GetContractType').subscribe({
      next: response => this.contractType = response,
      error: error => console.log(error),
    })
  }


  getServiceType() {
    this.http.get(this.baseUrl + 'user/GetServiceType').subscribe({
      next: response => this.serviceType = response,
      error: error => console.log(error),
    })
  }


  getUserRoles() {
    this.http.get(this.baseUrl + 'user/GetUserRoles').subscribe({
      next: response => this.userRoles = response,
      error: error => console.log(error),
    })
  }




  deleteIssueType(id: number) {
    this.http.delete(this.baseUrl + 'user/DeleteIssueType/' + id).subscribe({
      next: () => this.modalRef.hide(),
      error: error => {
        this.toastr.error(error.error),
          console.log(error);
      },
      complete: () => {
        this.ngOnInit();
        this.toastr.success("تم حذف نوع القضية بنجاح");
      }
    })
  }

  deleteIssueStatus(id: number) {
    this.http.delete(this.baseUrl + 'user/DeleteIssueStatus/' + id).subscribe({
      next: () => this.modalRef.hide(),
      error: error => {
        this.toastr.error(error.error),
          console.log(error);
      },
      complete: () => {
        this.ngOnInit();
        this.toastr.success("تم حذف حالة القضية بنجاح");
      }
    })
  }

  deleteContractType(id: number) {
    this.http.delete(this.baseUrl + 'user/DeleteContractType/' + id).subscribe({
      next: () => this.modalRef.hide(),
      error: error => {
        this.toastr.error(error.error),
          console.log(error);
      },
      complete: () => {
        this.ngOnInit();
        this.toastr.success("تم حذف نوع العقد بنجاح");
      }
    })
  }

  deleteServiceType(id: number) {
    this.http.delete(this.baseUrl + 'user/DeleteServiceType/' + id).subscribe({
      next: () => this.modalRef.hide(),
      error: error => {
        this.toastr.error(error.error),
          console.log(error);
      },
      complete: () => {
        this.ngOnInit();
        this.toastr.success("تم حذف نوع الخدمة بنجاح");
      }
    })
  }

  deleteUserRole(id: number) {
    this.http.delete(this.baseUrl + 'user/DeleteUserRole/' + id).subscribe({
      next: () => this.modalRef.hide(),
      error: error => {
        this.toastr.error(error.error),
          console.log(error);
      },
      complete: () => {
        this.ngOnInit();
        this.toastr.success("تم حذف صلحية الستخدم بنجاح");
      }
    })
  }

  decline(): void {
    this.message = 'Declined!';
    this.modalRef.hide();
  }
}
