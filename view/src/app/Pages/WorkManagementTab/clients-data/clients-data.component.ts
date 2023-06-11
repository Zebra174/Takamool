import { HttpClient } from '@angular/common/http';
import { Component, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-clients-data',
  templateUrl: './clients-data.component.html',
  styleUrls: ['./clients-data.component.css']
})
export class ClientsDataComponent {
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
    this.http.get('https://localhost:5001/api/customer/GetCustomers').subscribe({
      next: response => this.customers = response,
      error : error => console.log(error),
      complete: () => this.TotalCustomers
     })
   }

   
   deleteCustomer(id:number) {
    this.http.delete('https://localhost:5001/api/customer/DeleteCustomer/'+id).subscribe({
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
