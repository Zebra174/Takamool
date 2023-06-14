import { HttpClient } from '@angular/common/http';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-khadamat-kanonyia',
  templateUrl: './khadamat-kanonyia.component.html',
  styleUrls: ['./khadamat-kanonyia.component.css']
})
export class KhadamatKanonyiaComponent implements OnInit{
  searchText:string ="";
  issues:any;
  modalRef!: BsModalRef ;


  constructor(private http: HttpClient,private modalService: BsModalService,private toastr:ToastrService) {}
  ngOnInit(): void {
    this.getIssues()
  }

  get TotalIssues():number {
    return this.issues.length;
   }
   
  getIssues(){
    this.http.get('https://localhost:5001/api/issuesTab/IssueTable').subscribe({
      next: response => this.issues = response,
      error : error => console.log(error),
      complete: () => this.TotalIssues
     })
  }
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-md'});
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

    this.modalRef.hide();
  }


}
