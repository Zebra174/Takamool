import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CreateService } from 'src/app/_services/create.service';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-add-consulting',
  templateUrl: './add-consulting.component.html',
  styleUrls: ['./add-consulting.component.css']
})
export class AddConsultingComponent {
  baseUrl =  environment.apiUrl;
  addConsultForm: FormGroup = new FormGroup({});
  choose1: string = 'اختر العميل';
  choose2: string = 'اختر نوع الاستشارة';
  customers: any;
  constTypes:any;
  validationErrors:string[]  | undefined;
 

  constructor(private http: HttpClient, private createService: CreateService, private toastr: ToastrService, private router: Router,
    private fb:FormBuilder) { }
  ngOnInit(): void {
    this.getConstType();
    this.getCustomers();
    this.IntializForm();
  }

  IntializForm() {
    this.addConsultForm = this.fb.group({
      customerID:['اختر العميل', [Validators.required, this.checkNull(this.choose1)]],
      constSubject: [null, Validators.required],
      result:[],
      constType:['اختر نوع الاستشارة', [Validators.required, this.checkNull(this.choose2)]],
    })
  }

  checkNull(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {

      return control.value == matchTo ? { empty: true } : null;
    }


  }

  AddConsulting() {
    // console.log(this.addAgentForm?.value);
    this.createService.AddConsulting(this.addConsultForm.value).subscribe({
      next: () => {
         this.router.navigateByUrl('/Consulting')
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

  
  getConstType(){
    this.http.get(this.baseUrl+'user/GetServiceType').subscribe({
      next: response => this.constTypes= response,
      error: error => console.log(error),
      complete: () => console.log(this.constTypes)
    })
  }

  getCustomers(){
    this.http.get(this.baseUrl+'customer/GetCustomers').subscribe({
      next: response => this.customers= response,
      error: error => console.log(error),
      complete: () => console.log(this.customers)
    })
  }

}
