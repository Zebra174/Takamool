import { HttpClient } from '@angular/common/http';
import { Component, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-clients-data',
  templateUrl: './clients-data.component.html',
  styleUrls: ['./clients-data.component.css']
})
export class ClientsDataComponent {
  baseUrl = environment.apiUrl;
  customers : any;
   modalRef!: BsModalRef ;
   message: string = "";
   searchText:string ="";

  constructor(private http: HttpClient,private modalService: BsModalService,private toastr:ToastrService) {}

  ngOnInit(): void {
    this.getCustomers();
    
  }
  
   get TotalCustomers():number {
    return this.customers.length;
   }
   
   
   openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-md'});
   }


  
   getCustomers(){
    this.http.get(this.baseUrl+'customer/GetCustomers').subscribe({
      next: response => this.customers = response,
      error : error => console.log(error),
      complete: () => this.TotalCustomers
     })
   }

   
   deleteCustomer(id:number) {
    this.http.delete(this.baseUrl+'customer/DeleteCustomer/'+id).subscribe({
      next: () =>this.modalRef.hide()  ,
      error : error => {
        this.toastr.error(error.error),
        console.log(error);
      },
      complete: () =>{
        this.ngOnInit();
        this.toastr.success("تم حذف العميل بنجاح") ;
      }
      
     })
  }

  decline(): void {
    this.message = 'Declined!';
    this.modalRef.hide();
  }

}
