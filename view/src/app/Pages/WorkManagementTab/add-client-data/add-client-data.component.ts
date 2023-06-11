import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CreateService } from 'src/app/_services/create.service';

@Component({
  selector: 'app-add-client-data',
  templateUrl: './add-client-data.component.html',
  styleUrls: ['./add-client-data.component.css']
})
export class AddClientDataComponent implements OnInit{
  addCustomerForm: FormGroup = new FormGroup({});
  validationErrors:string[]  | undefined;


  constructor(private http: HttpClient, private createService: CreateService, private toastr: ToastrService, private router: Router,
    private fb:FormBuilder) { }
  ngOnInit(): void {
    this.IntializForm();
  }

  IntializForm() {
    this.addCustomerForm = this.fb.group({
   
      custName: [null, Validators.required],
      custIdNumber: [null, Validators.required],
      custEmail:[null, Validators.required],
      custMobile:[''],
      custAddress:[''],
      custCity:[''],
    })
  }

  checkNull(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {

      return control.value == matchTo ? { empty: true } : null;
    }


  }


  AddCustomer() {
    // console.log(this.addAgentForm?.value);
    this.createService.AddCustomer(this.addCustomerForm.value).subscribe({
      next: () => {
         this.router.navigateByUrl('/ClientsData')
       },
      error: error => {
        
          if(error.error == "رقم الهوية موجود مسبقا") {
            this.toastr.error(error.error)
          }
          else{
            this.toastr.error("برجاء ادخال القيم المطلوبة")
          }
         
      },
      complete: () =>{
        this.toastr.success("تم اضافة العميل بنجاح") ;
      }
    });

  }

 

}
