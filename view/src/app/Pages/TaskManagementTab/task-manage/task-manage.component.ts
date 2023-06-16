import { HttpClient } from '@angular/common/http';
import { Component, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-task-manage',
  templateUrl: './task-manage.component.html',
  styleUrls: ['./task-manage.component.css']
})
export class TaskManageComponent {
  baseUrl =  environment.apiUrl;
  title : string = 'القسم الخاص بالوكلات'
  tasks : any;
   modalRef!: BsModalRef ;
   message: string = "";
   searchText:string ="";
   taskStatus:any;


  constructor(private http: HttpClient,private modalService: BsModalService,private toastr:ToastrService) {}

  ngOnInit(): void {
   this.getTaskValues()
  }
  
   get TotalTasks():number {
    return this.tasks.length;
   }
  
   getTaskValues(){
    this.http.get(this.baseUrl+'task/GetTaskTableValues').subscribe({
      next: response => this.tasks = response,
      error : error => console.log(error),
      complete: () => this.TotalTasks
     })
   }

   getStatusesClass(taskStatus:number){
        switch(taskStatus)
        {
          case 1 : {return 'bg-default-custom '; break;};
          case 2 : {return 'bg-primary-custom '; break;};
          case 3 : {return 'bg-danger-custom '; break;};
          case 4 : {return 'bg-success-custom '; break;};
          default: return 'bg-primary-custom ';
        }
   }

   

  getTaskStatus(){
    this.http.get(this.baseUrl+'task/GetTaskStatus').subscribe({
      next: response => this.taskStatus=response,
      error: error => console.log(error),
      complete: () => console.log("Request Done")
    })
  }

}
