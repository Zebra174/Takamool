import { HttpClient } from '@angular/common/http';
import { Component,TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { concat, filter, map, merge } from 'rxjs';
import { environment } from 'src/environments/environment.development';


@Component({
  selector: 'app-agents',
  templateUrl: './agents.component.html',
  styleUrls: ['./agents.component.css']
})
export class AgentsComponent {
  baseUrl =  environment.apiUrl;
  title:string = 'القسم الخاص بالوكلات'
  agencies : any;
   modalRef!: BsModalRef ;
   message: string = "";
   searchText:string ="";
   issuesStatuses: any;
   agencyStatus:any;
   agenceType:any;
   data:any;

  constructor(private http: HttpClient,private modalService: BsModalService,private toastr:ToastrService) {}

  ngOnInit(): void {
    this.getAgencies();
    this.getIssuesStatuses(); 
    this.getAgenceType();
  }
  
   get TotalAgencies():number {
    return this.agencies.length;
   }
   
   
   openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-md'});
   }


  
   getAgencies(){
    this.http.get(this.baseUrl+'issuesTab/GetAgencies').subscribe({
      next: response => this.agencies = response,
      error : error => console.log(error),
      complete: () => this.TotalAgencies
     })
   }

   getIssuesStatuses(){
    this.http.get(this.baseUrl+'issuesTab/GetIssueStatus').subscribe({
      next: response => this.issuesStatuses= response,
      error: error => console.log(error),
      complete: () => console.log(this.issuesStatuses)
    })
  }

  getAgenceType(){
    this.http.get(this.baseUrl+'issuesTab/GetAgenceType').subscribe({
      next: response => this.agenceType=response,
      error: error => console.log(error),
      complete: () => console.log("Request Done")
    })
  }


   
   deleteAgency(id:number) {
    this.http.delete(this.baseUrl+'issuesTab/DeleteAgency/'+id).subscribe({
      next: () =>this.modalRef.hide()  ,
      error : error => {
        this.toastr.error(error.error),
        console.log(error);
      },
      complete: () =>{
        this.ngOnInit();
        this.toastr.success("تم حذف الوكالة بنجاح") ;
      }
      
     })
  }

  decline(): void {
    this.message = 'Declined!';
    this.modalRef.hide();
  }

 



}
