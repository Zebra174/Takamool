import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UpdateService } from 'src/app/_services/update.service';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-edit-customer',
  templateUrl: './edit-customer.component.html',
  styleUrls: ['./edit-customer.component.css']
})
export class EditCustomerComponent {
  baseUrl =  environment.apiUrl;

  customers: any;
 
  constructor(private route:ActivatedRoute,private http:HttpClient, private updateService:UpdateService,
     private toastr: ToastrService,private router:Router){}
  
  ngOnInit(): void {
   this.route.paramMap.subscribe({
    next: (params) => {
      const id = params.get('id');

      if(id) {
          this.getCustomer(id).subscribe({
            next: response => this.customers = response,
            error: error => console.log(error),
            complete: () => console.log(this.customers)
          })
      }
    }
   })
  
  
  }

  updateCustomer(id:string){
     this.updateService.UpdateCustomer(id,this.customers).subscribe({
      next: () => {
         this.router.navigateByUrl('/ClientsData')
       },
      error: error => {
       
          this.toastr.error(error.error)
      },
      complete: () =>{
        this.toastr.success("تم تعديل العميل بنجاح") ;
      }
    });
  }

  getCustomer(id:string){
    return this.http.get(this.baseUrl+'customer/GetCustomer/'+id);
  }
}
