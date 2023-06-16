import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UpdateService } from 'src/app/_services/update.service';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-edit-issue',
  templateUrl: './edit-issue.component.html',
  styleUrls: ['./edit-issue.component.css']
})
export class EditIssueComponent {
  baseUrl =  environment.apiUrl;
  issue:any;
  customerType: any;
  contractTypes: any;
  issueType:any;
  customer:any;
  //  agentDetails: Agency =  {
  //    lokupValue : '',
  //   agenceNo : 0,
  //    agenceName: '',
  //    agenceTo: new Date(),
  //    agenceId : 0,
  //    agencePic:'',
  //    at:''
  //  };
 
  constructor(private route:ActivatedRoute,private http:HttpClient, private updateService:UpdateService, 
    private toastr: ToastrService,private router:Router){}
  
  ngOnInit(): void {
   this.route.paramMap.subscribe({
    next: (params) => {
      const id = params.get('id');

      if(id) {
          this.getIssue(id).subscribe({
            next: response => this.issue = response,
            error: error => console.log(error),
            complete: () => console.log(this.issue)
          })
      }
    }
   })
   this.getIssueType();
   this.getCustomers();
   this.getcontractTypes();
   this.getCustomerType();
  }

  getIssue(id:string){
    return this.http.get(this.baseUrl+'issuesTab/GetIssue/'+id);
  }

   updateIssue(id:string){
      this.updateService.UpdateIssue(id,this.issue).subscribe({
       next: () => {
          this.router.navigateByUrl('/Services')
        },
       error: error => {
         if(error.error == "رقم القضية موجود مسبقا") {
           this.toastr.error(error.error)
         }
         else{
           this.toastr.error("برجاء ادخال القيم المطلوبة")
        }
       },
       complete: () =>{
         this.toastr.success("تم تعديل القضية بنجاح") ;
       }
     });
   }

 

  getcontractTypes() {
    this.http.get(this.baseUrl+'issuesTab/ContractType').subscribe({
      next: response => this.contractTypes = response,
      error: error => console.log(error),
      complete: () => console.log("Request has completed")
    })
  }

  getIssueType() {
    this.http.get(this.baseUrl+'issuesTab/IssueType').subscribe({
      next: response => this.issueType = response,
      error: error => console.log(error),
      complete: () => console.log("Request has completed")
    })
  }

  getCustomers() {
    this.http.get(this.baseUrl+'customer/GetCustomers').subscribe({
      next: response => this.customer = response,
      error: error => console.log(error),
      complete: () => console.log("Request has completed")
    })
  }

  getCustomerType() {
    this.http.get(this.baseUrl+'issuesTab/CustomerType').subscribe({
      next: response => this.customerType = response,
      error: error => console.log(error),
      complete: () => console.log("Request has completed")
    })
  }
}
