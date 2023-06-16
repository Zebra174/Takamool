import { HttpClient } from '@angular/common/http';
import { Component, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-user-auth',
  templateUrl: './user-auth.component.html',
  styleUrls: ['./user-auth.component.css']
})
export class UserAuthComponent {
  baseUrl = environment.apiUrl;
   modalRef!: BsModalRef ;
   message: string = "";
   searchText:string ="";
   users: any;
   agencyStatus:any;
   agenceType:any;
   data:any;

  constructor(private http: HttpClient,private modalService: BsModalService,private toastr:ToastrService) {}

  ngOnInit(): void {
    this.getUsers();
  }
  
   get TotalUsers():number {
    return this.users.length;
   }
   
   
   openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-md'});
   }


  
   getUsers(){
    this.http.get(this.baseUrl+'user/GetUsers').subscribe({
      next: response => this.users = response,
      error : error => console.log(error),
      complete: () => this.TotalUsers
     })
   }

   

  getAgenceType(){
    this.http.get(this.baseUrl+'issuesTab/GetAgenceType').subscribe({
      next: response => this.agenceType=response,
      error: error => console.log(error),
      complete: () => console.log("Request Done")
    })
  }

   
   deleteUser(id:number) {
    this.http.delete(this.baseUrl+'user/DeleteUser/'+id).subscribe({
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
