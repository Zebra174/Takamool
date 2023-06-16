import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CreateService } from 'src/app/_services/create.service';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-add-legal-services',
  templateUrl: './add-legal-services.component.html',
  styleUrls: ['./add-legal-services.component.css']
})
export class AddLegalServicesComponent implements OnInit {
  baseUrl =  environment.apiUrl;
  issues: any;
  customers:any;
  contractType:any;
  customerType:any;
  addServiceForm: FormGroup = new FormGroup({});
  choose1: string = 'اختر نوع المعاملة';
  choose2: string = 'نوع العميل';
  choose3:string = 'اختر نوع القضية';
  choose4:string = 'اختر العميل';
  validationErrors:string[]  | undefined;
  issueType:any;


  constructor(private http: HttpClient, private createService: CreateService, private toastr: ToastrService, private router: Router,
    private fb:FormBuilder) { }

  ngOnInit(): void {
    this.getCustomers();
    this.getContractType();
    this.getCustomerType();
    this.getIssueType();
   
    this.IntializForm();
  }

  IntializForm() {
    this.addServiceForm = this.fb.group({
      isuueSubject: [null, Validators.required],
      isuuenumber:[null, Validators.required],
      isuueOpenDate: [null, Validators.required],
      contractType:['اختر نوع المعاملة',[Validators.required, this.checkNull(this.choose1)]],
      isuueType:['اختر نوع القضية',[Validators.required, this.checkNull(this.choose3)]],
      customerId:['اختر العميل',[Validators.required, this.checkNull(this.choose4)]],
      isseName:[null,Validators.required],
      customerType:['نوع العميل',[Validators.required, this.checkNull(this.choose2)]],
      isuueSummary:[],
      isuueDetail:[],
      contractNumber:[],
      lowerName:[null, Validators.required],
      agnName:[null, Validators.required],
      agnaddress:[],
      agnphone:[],
      isuueStatus:['2'],
      courtCity:[],
      courtCircle:[],
      // AgenceType:['اختر تصنيف الوكيل', [Validators.required, this.checkNull(this.choose2)]],
    })
  }

  
  checkNull(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {

      return control.value == matchTo ? { empty: true } : null;
    }
  }

  // getLockupTable(){
  //   this.http.get('https://localhost:5001/api/issuesTab/LokupTable').subscribe({
  //     next: response => this.test = response,
  //     error: error => console.log(error),
  //     complete: () => console.log(this.test)
  //   })
  // }

  getCustomers(){
    this.http.get(this.baseUrl+'customer/GetCustomers').subscribe({
      next: response => this.customers = response,
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
  getContractType(){
    this.http.get(this.baseUrl+'issuesTab/ContractType').subscribe({
      next: response => this.contractType = response,
      error: error => console.log(error),
      complete: () => console.log(this.contractType)
    })

  }
  getCustomerType(){
    this.http.get(this.baseUrl+'issuesTab/CustomerType').subscribe({
      next: response => this.customerType = response,
      error: error => console.log(error),
      complete: () => console.log(this.customerType)
    })

  }

  AddService() {
    // console.log(this.addAgentForm?.value);
    this.createService.AddService(this.addServiceForm.value).subscribe({
      next: () => {
      
         this.router.navigateByUrl('/Services')
       },
      error: error => {
        
          if(error.error == "رقم القضية موجود مسبقا") {
            this.toastr.error(error.error)
          }
          else{
            this.toastr.error("برجاء ادخال القيم المطلوبة")
          }
         
      },
      complete: () =>{
        this.toastr.success("تم اضافة القضية بنجاح") ;
      }
    });

  }



}
