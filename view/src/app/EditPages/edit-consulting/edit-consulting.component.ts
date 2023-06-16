import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UpdateService } from 'src/app/_services/update.service';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-edit-consulting',
  templateUrl: './edit-consulting.component.html',
  styleUrls: ['./edit-consulting.component.css']
})
export class EditConsultingComponent {
  baseUrl =  environment.apiUrl;
  consulting:any;
  customers: any;
  constTypes:any;
 
  constructor(private route:ActivatedRoute,private http:HttpClient, private updateService:UpdateService,
     private toastr: ToastrService,private router:Router){}
  
  ngOnInit(): void {
   this.route.paramMap.subscribe({
    next: (params) => {
      const id = params.get('id');

      if(id) {
          this.getConsulting(id).subscribe({
            next: response => this.consulting = response,
            error: error => console.log(error),
            complete: () => console.log(this.consulting)
          })
      }
    }
   })
  
   this.getCustomers();
   this.getConstType();
  }

  updateConsulting(id:string){
     this.updateService.UpdateConsulting(id,this.consulting).subscribe({
      next: () => {
         this.router.navigateByUrl('/Consulting')
       },
      error: error => {
       
          this.toastr.error(error.error)
      },
      complete: () =>{
        this.toastr.success("تم تعديل الاستشارة بنجاح") ;
      }
    });
  }

  getConsulting(id:string){
    return this.http.get(this.baseUrl+'issuesTab/GetConsulting/'+id);
  }

  getCustomers() {
    this.http.get(this.baseUrl+'customer/GetCustomers').subscribe({
      next: response => this.customers = response,
      error: error => console.log(error),
     
    })
  }

  getConstType(){
    this.http.get(this.baseUrl+'user/GetServiceType').subscribe({
      next: response => this.constTypes= response,
      error: error => console.log(error),
      complete: () => console.log(this.constTypes)
    })
  }

  

}
