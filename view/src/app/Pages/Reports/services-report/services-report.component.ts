import { HttpClient } from '@angular/common/http';
import { Component, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-services-report',
  templateUrl: './services-report.component.html',
  styleUrls: ['./services-report.component.css']
})
export class ServicesReportComponent {
  modalRef!: BsModalRef ;
  message: string = "";
  searchText:string ="";
  custSessions: any;
  agencyStatus:any;
  agenceType:any;
  data:any;

 constructor(private http: HttpClient,private modalService: BsModalService,private toastr:ToastrService) {}

 ngOnInit(): void {
   this.getCustSessions();
 }
 
  get TotalCustomers():number {
   return this.custSessions.length;
  }
  
  
  openModal(template: TemplateRef<any>) {
   this.modalRef = this.modalService.show(template, {class: 'modal-md'});
  }


 
  getCustSessions(){
   this.http.get('https://localhost:5001/api/Reports/GetCustSessions').subscribe({
     next: response => this.custSessions = response,
     error : error => console.log(error),
     complete: () => this.TotalCustomers
    })
  }

  


  
  deleteUser(id:number) {
   this.http.delete('https://localhost:5001/api/user/DeleteUser/'+id).subscribe({
     next: () =>this.modalRef.hide()  ,
     error : error => {
       this.toastr.error(error.error),
       console.log(error);
     },
     complete: () =>{
       this.ngOnInit();
       this.toastr.success("تم حذف المستخدم بنجاح") ;
     }
    })
 }

 decline(): void {
   this.message = 'Declined!';
   this.modalRef.hide();
 }
}
