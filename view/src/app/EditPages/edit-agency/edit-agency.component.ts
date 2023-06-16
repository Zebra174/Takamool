import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { Agency } from 'src/app/_models/Agencies';
import { UpdateService } from 'src/app/_services/update.service';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-edit-agency',
  templateUrl: './edit-agency.component.html',
  styleUrls: ['./edit-agency.component.css']
})
export class EditAgencyComponent implements OnInit {
  baseUrl =  environment.apiUrl;
  agent:any;
  at: any;
  issues: any;
   agentDetails: Agency =  {
     lokupValue : '',
    agenceNo : 0,
     agenceName: '',
     agenceTo: new Date(),
     agenceId : 0,
     agencePic:'',
     at:''
   };
 
  constructor(private route:ActivatedRoute,private http:HttpClient, private updateService:UpdateService, private toastr: ToastrService,private router:Router){}
  
  ngOnInit(): void {
   this.route.paramMap.subscribe({
    next: (params) => {
      const id = params.get('id');

      if(id) {
          this.getAgent(id).subscribe({
            next: response => this.agent = response,
            error: error => console.log(error),
            complete: () => console.log(this.agent)
          })
      }
    }
   })
   this.getAgenceType();
   this.getIssues();
  }

  updateAgent(id:string){
     this.updateService.UpdateAgent(id,this.agent).subscribe({
      next: () => {
         this.router.navigateByUrl('/Agents')
       },
      error: error => {
        if(error.error == "رقم الوكالة موجود مسبقا") {
          this.toastr.error(error.error)
        }
        else{
          this.toastr.error("برجاء ادخال القيم المطلوبة")
        }
      },
      complete: () =>{
        this.toastr.success("تم تعديل الوكالة بنجاح") ;
      }
    });
  }

  getAgent(id:string){
    return this.http.get(this.baseUrl+'issuesTab/GetAgent/'+id);
  }

  getIssues() {
    this.http.get(this.baseUrl+'issuesTab/GetIssues').subscribe({
      next: response => this.issues = response,
      error: error => console.log(error),
      complete: () => console.log("Request has completed")
    })
  }

  getAgenceType(){
    this.http.get(this.baseUrl+'issuesTab/GetLokupAgenceTypes').subscribe({
      next: response => this.at=response,
      error: error => console.log(error),
      complete: () => console.log(this.at)
    })
  }

}
