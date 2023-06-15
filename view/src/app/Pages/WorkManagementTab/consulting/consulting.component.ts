import { HttpClient } from '@angular/common/http';
import { Component, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-consulting',
  templateUrl: './consulting.component.html',
  styleUrls: ['./consulting.component.css']
})
export class ConsultingComponent {
  consultings : any;
   modalRef!: BsModalRef ;
   message: string = "";
   searchText:string ="";

  constructor(private http: HttpClient,private modalService: BsModalService,private toastr:ToastrService) {}

  ngOnInit(): void {
    this.getConsultings();
  }
  
   get TotalConsutlings():number {
    return this.consultings.length;
   }
   
   
   openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-md'});
   }


  
   getConsultings(){
    this.http.get('https://localhost:5001/api/issuesTab/GetConsulting').subscribe({
      next: response => this.consultings = response,
      error : error => console.log(error),
      complete: () => this.TotalConsutlings
     })
   }


   
   deleteConsult(id:number) {
    this.http.delete('https://localhost:5001/api/issuesTab/DeleteConsulting/'+id).subscribe({
      next: () =>this.modalRef.hide()  ,
      error : error => {
        this.toastr.error(error.error),
        console.log(error);
      },
      complete: () =>{
        this.ngOnInit();
        this.toastr.success("تم حذف الاستشارة بنجاح") ;
      }
      
     })
  }

  decline(): void {
    this.message = 'Declined!';
    this.modalRef.hide();
  }
}
