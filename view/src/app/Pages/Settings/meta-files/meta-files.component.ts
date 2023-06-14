import { HttpClient } from '@angular/common/http';
import { Component, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-meta-files',
  templateUrl: './meta-files.component.html',
  styleUrls: ['./meta-files.component.css']
})
export class MetaFilesComponent {
  modalRef!: BsModalRef ;
  message: string = "";
  searchText:string ="";
 issueType:any;
 issueStatus:any;
 contractType:any;
 serviceType:any;
 userRoles:any;

 constructor(private http: HttpClient,private modalService: BsModalService,private toastr:ToastrService) {}

 ngOnInit(): void {
   this.getIssueTypes();
   this.getIssueStatus();
   this.getContractType();
   this.getServiceType();
   this.getUserRoles();
 }
 
  // get TotalUsers():number {
  //  return this.users.length;
  // }
  
  
  openModal(template: TemplateRef<any>) {
   this.modalRef = this.modalService.show(template, {class: 'modal-md'});
  }


 
  getIssueTypes(){
   this.http.get('https://localhost:5001/api/user/GetIssueTypes').subscribe({
     next: response => this.issueType = response,
     error : error => console.log(error),
    
    })
  }

  
  getIssueStatus(){
    this.http.get('https://localhost:5001/api/user/GetIssueStatus').subscribe({
      next: response => this.issueStatus = response,
      error : error => console.log(error),
     })
   }

   getContractType(){
    this.http.get('https://localhost:5001/api/user/GetContractType').subscribe({
      next: response => this.contractType = response,
      error : error => console.log(error),
     })
   }

   
   getServiceType(){
    this.http.get('https://localhost:5001/api/user/GetServiceType').subscribe({
      next: response => this.serviceType = response,
      error : error => console.log(error),
     })
   }

   
   getUserRoles(){
    this.http.get('https://localhost:5001/api/user/GetUserRoles').subscribe({
      next: response => this.userRoles = response,
      error : error => console.log(error),
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
