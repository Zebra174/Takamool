import { HttpClient } from '@angular/common/http';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-khadamat-kanonyia',
  templateUrl: './khadamat-kanonyia.component.html',
  styleUrls: ['./khadamat-kanonyia.component.css']
})
export class KhadamatKanonyiaComponent implements OnInit{
  baseUrl =  environment.apiUrl;
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
    this.http.get(this.baseUrl+'issuesTab/IssueTable').subscribe({
      next: response => this.issues = response,
      error : error => console.log(error),
      complete: () => this.TotalIssues
     })
  }
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-md'});
   }
   deleteAgency(id:number) {
    this.http.delete(this.baseUrl+'issuesTab/DeleteAgency/'+id).subscribe({
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
