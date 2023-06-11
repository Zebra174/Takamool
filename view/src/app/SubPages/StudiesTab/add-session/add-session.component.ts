import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CreateService } from 'src/app/_services/create.service';

@Component({
  selector: 'app-add-session',
  templateUrl: './add-session.component.html',
  styleUrls: ['./add-session.component.css']
})
export class AddSessionComponent implements OnInit{
  issues: any;
  addSessionForm: FormGroup = new FormGroup({});
  choose1: string = 'اختر القضية';
  validationErrors:string[]  | undefined;
  at:any;
  issueType:any;

  constructor(private http: HttpClient, private createService: CreateService, private toastr: ToastrService, private router: Router,
    private fb:FormBuilder) { }
  ngOnInit(): void {
    this.getIssues();
    this.IntializForm();
  }

  IntializForm() {
    this.addSessionForm = this.fb.group({
      aisuueNumber:['اختر القضية', [Validators.required, this.checkNull(this.choose1)]],
      sessionName: [null, Validators.required],
      sessionNextName: [null, Validators.required],
      sessionNote: [null, Validators.required],
      sessionDate:[null, Validators.required],
      sessionNextDate:[null, Validators.required],
      customerInv:[false, Validators.required],
    })
  }

  checkNull(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {

      return control.value == matchTo ? { empty: true } : null;
    }


  }

  AddSession() {
    // console.log(this.addAgentForm?.value);
    this.addSessionForm.value.customerInv == false ? this.addSessionForm.value.customerInv=0 : this.addSessionForm.value.customerInv=1
    console.log(this.addSessionForm.value.customerInv)
    this.createService.AddSession(this.addSessionForm.value).subscribe({
      next: () => {
         this.router.navigateByUrl('/Sessions')
       },
      error: error => {
        
          console.log(error),

            this.toastr.error("برجاء ادخال القيم المطلوبة")   
         
      },
      complete: () =>{
        this.toastr.success("تم اضافة الجلسة بنجاح") ;
      }
    });

  }

 

  getIssues() {
    this.http.get('https://localhost:5001/api/issuesTab/GetIssues').subscribe({
      next: response => this.issues = response,
      error: error => console.log(error),
      complete: () => console.log("Request has completed")
    })
  }

  getIssueType(){
    this.http.get('https://localhost:5001/api/issuesTab/IssueType').subscribe({
      next: response => this.issueType = response,
      error: error => console.log(error),
      complete: () => console.log("Request has completed")
    })
  }
}
