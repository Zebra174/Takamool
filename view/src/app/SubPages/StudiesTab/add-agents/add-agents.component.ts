import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CreateService } from 'src/app/_services/create.service';
import { environment } from 'src/environments/environment.development';


@Component({
  selector: 'app-add-agents',
  templateUrl: './add-agents.component.html',
  styleUrls: ['./add-agents.component.css']
})
export class AddAgentsComponent implements OnInit {
  baseUrl = environment.apiUrl;
  issues: any;
  addAgentForm: FormGroup = new FormGroup({});
  choose1: string = 'اختر نوع القضية';
  choose2: string = 'اختر تصنيف الوكيل';
  validationErrors:string[]  | undefined;
  agentPic:string = "";
  at:any;
  issueType:any;

  constructor(private http: HttpClient, private createService: CreateService, private toastr: ToastrService, private router: Router,
    private fb:FormBuilder) { }
  ngOnInit(): void {
    this.getIssues();
    this.getAgenceType();
    this.IntializForm();
  }

  IntializForm() {
    this.addAgentForm = this.fb.group({
      IsuueNumber:['اختر نوع القضية', [Validators.required, this.checkNull(this.choose1)]],
      AgenceTo: [null, Validators.required],
      AgenceNo: [null, Validators.required],
      AgenceName:[null, Validators.required],
      AgenceNote:[],
      AgencePic:[''],
      AgenceType:['اختر تصنيف الوكيل', [Validators.required, this.checkNull(this.choose2)]],
    })
  }

  checkNull(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {

      return control.value == matchTo ? { empty: true } : null;
    }


  }

 AddPic(){
    // switch(this.addAgentForm.value.IsuueNumber)
    // {

    // }
 } 

  AddAgent() {
    // console.log(this.addAgentForm?.value);
    this.createService.AddAgent(this.addAgentForm.value).subscribe({
      next: () => {
        this.AddPic()
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
        this.toastr.success("تم اضافة الوكالة بنجاح") ;
      }
    });

  }

 

  getIssues() {
    this.http.get(this.baseUrl+'issuesTab/GetIssues').subscribe({
      next: response => this.issues = response,
      error: error => console.log(error),
      complete: () => console.log("Request has completed")
    })
  }

  getIssueType(){
    this.http.get(this.baseUrl+'issuesTab/IssueType').subscribe({
      next: response => this.issueType = response,
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
