import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-task-summary',
  templateUrl: './task-summary.component.html',
  styleUrls: ['./task-summary.component.css']
})
export class TaskSummaryComponent {

  tasks : any;
  issues:any;
 doneTaskStatus:any;
 doneIssueStatus:any;
 pendingTaskStatus:number =0;
 pendingIssueStatus:number =0;

  constructor(private http: HttpClient,private modalService: BsModalService,private toastr:ToastrService) {}

  ngOnInit(): void {
   this.getTaskValues()
   this.getIssues()
   this.getDoneTask()
   this.getDoneIssues()
  }
  
   get TotalTasks():number {
    return this.tasks.length;
   }

   get TotalIssues():number {
    return this.issues.length
   }

   get PendingTasks():number {
    this.pendingTaskStatus = this.TotalTasks - this.doneTaskStatus;
    return this.pendingTaskStatus;
   }

   get PendingIssues():number {
    this.pendingIssueStatus = this.TotalIssues - this.doneIssueStatus;
    return this.pendingIssueStatus;
   }

  //  get TotalDoneIssues():number {
  //   return this.doneIssueStatus.length
  //  }

  //  get TotalDoneTask():number {
  //   return this.doneTaskStatus.length
  //  }
  
   getTaskValues(){
    this.http.get('https://localhost:5001/api/task/GetTaskTableValues').subscribe({
      next: response => this.tasks = response,
      error : error => console.log(error),
      complete: () => this.TotalTasks
     })
   }

   getIssues(){
    this.http.get('https://localhost:5001/api/issuesTab/GetIssuesTable').subscribe({
      next: response => this.issues = response,
      error : error => console.log(error),
      complete: () => this.TotalIssues
     })
   }

   getDoneTask(){
    this.http.get('https://localhost:5001/api/task/GetDoneTask').subscribe({
      next: response => this.doneTaskStatus = response,
      error : error => console.log(error),
      complete: () => this.PendingTasks
     })
   }

   
   getDoneIssues(){
    this.http.get('https://localhost:5001/api/issuesTab/GetDoneIssues').subscribe({
      next: response => this.doneIssueStatus = response,
      error : error => console.log(error),
      complete: () => this.PendingIssues
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

  // getTaskStatus(){
  //   this.http.get('https://localhost:5001/api/task/GetTaskStatus').subscribe({
  //     next: response => this.taskStatus=response,
  //     error: error => console.log(error),
  //     complete: () => console.log("Request Done")
  //   })
  // }
}
