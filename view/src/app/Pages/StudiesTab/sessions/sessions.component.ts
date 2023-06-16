import { HttpClient } from '@angular/common/http';
import { Component, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-sessions',
  templateUrl: './sessions.component.html',
  styleUrls: ['./sessions.component.css']
})
export class SessionsComponent {

  baseUrl =  environment.apiUrl;;
  sessions : any;
   modalRef!: BsModalRef ;
   message: string = "";
   searchText:string ="";
   issuesStatuses: any;
   agencyStatus:any;
   agenceType:any;
   data:any;

  constructor(private http: HttpClient,private modalService: BsModalService,private toastr:ToastrService) {}

  ngOnInit(): void {
    this.getSessions();
    this.getIssuesStatuses(); 
    this.getAgenceType();
  }
  
   get TotalSessions():number {
    return this.sessions.length;
   }
   
   
   openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-md'});
   }


  
   getSessions(){
    this.http.get(this.baseUrl+'issuesTab/GetSessionsTable').subscribe({
      next: response => this.sessions = response,
      error : error => console.log(error),
      complete: () => this.TotalSessions
     })
   }

   getIssuesStatuses(){
    this.http.get(this.baseUrl+'issuesTab/GetIssueStatus').subscribe({
      next: response => this.issuesStatuses= response,
      error: error => console.log(error),
      
    })
  }

  getAgenceType(){
    this.http.get(this.baseUrl+'issuesTab/GetAgenceType').subscribe({
      next: response => this.agenceType=response,
      error: error => console.log(error),
      complete: () => console.log("Request Done")
    })
  }

   
   deleteSession(id:number) {
    this.http.delete(this.baseUrl+'issuesTab/DeleteSession/'+id).subscribe({
      next: () =>this.modalRef.hide()  ,
      error : error => {
        this.toastr.error(error.error),
        console.log(error);
      },
      complete: () =>{
        this.ngOnInit();
        this.toastr.success("تم حذف الجلسة بنجاح") ;
      }
      
     })
  }

  decline(): void {
    this.message = 'Declined!';
    this.modalRef.hide();
  }

 
}
