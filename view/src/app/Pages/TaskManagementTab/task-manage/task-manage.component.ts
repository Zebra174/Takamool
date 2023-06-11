import { HttpClient } from '@angular/common/http';
import { Component, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-task-manage',
  templateUrl: './task-manage.component.html',
  styleUrls: ['./task-manage.component.css']
})
export class TaskManageComponent {
  title : string = 'القسم الخاص بالوكلات'
  tasks : any;
   modalRef!: BsModalRef ;
   message: string = "";
   searchText:string ="";
   issuesStatuses: any;
   agencyStatus:any;
   agenceType:any;
   data:any;

  constructor(private http: HttpClient,private modalService: BsModalService,private toastr:ToastrService) {}

  ngOnInit(): void {
    this.getTasks();
    this.getIssuesStatuses(); 
    this.getAgenceType();
  }
  
   get TotalTasks():number {
    return this.tasks.length;
   }
   
   
   openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-md'});
   }


  
   getTasks(){
    this.http.get('https://localhost:5001/api/task/GetTasks').subscribe({
      next: response => this.tasks = response,
      error : error => console.log(error),
      complete: () => this.TotalTasks
     })
   }

   getIssuesStatuses(){
    this.http.get('https://localhost:5001/api/issuesTab/GetIssueStatus').subscribe({
      next: response => this.issuesStatuses= response,
      error: error => console.log(error),
      complete: () => console.log(this.tasks)
    })
  }

  getAgenceType(){
    this.http.get('https://localhost:5001/api/issuesTab/GetAgenceType').subscribe({
      next: response => this.agenceType=response,
      error: error => console.log(error),
      complete: () => console.log("Request Done")
    })
  }

   
   deleteAgency(id:number) {
    this.http.delete('https://localhost:5001/api/issuesTab/DeleteAgency/'+id).subscribe({
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
