import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CreateService } from 'src/app/_services/create.service';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-add-users',
  templateUrl: './add-users.component.html',
  styleUrls: ['./add-users.component.css']
})
export class AddUsersComponent implements OnInit {
  baseUrl =  environment.apiUrl;
  addUserForm: FormGroup = new FormGroup({});
  choose1: string = 'اختر صلحية المستخدم';
  validationErrors:string[]  | undefined;
  userTypes:any

  constructor(private http: HttpClient, private createService: CreateService, private toastr: ToastrService, private router: Router,
    private fb:FormBuilder) { }

  ngOnInit(): void {
    this.IntializForm();
    this.getRoles();
  }

  IntializForm() {
    this.addUserForm = this.fb.group({
      userType:['اختر صلحية المستخدم', [Validators.required, this.checkNull(this.choose1)]],
      name: [null, Validators.required],
      username:[null, Validators.required],
      dateOfBirth:[null,Validators.required],
      pass:[null,Validators.required],
      
    })
  }

  checkNull(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {

      return control.value == matchTo ? { empty: true } : null;
    }


  }

  AddUser() {
    // console.log(this.addAgentForm?.value);
    this.createService.AddUser(this.addUserForm.value).subscribe({
      next: () => {
         this.router.navigateByUrl('/UserAuth')
       },
      error: error => {
            
          if(error.error == "البريد الاكتروني موجود مسبقا") {
            this.toastr.error(error.error)
          }
          else{
            this.toastr.error("برجاء ادخال القيم المطلوبة")
          }
         
      },
      complete: () =>{
        this.toastr.success("تم اضافة المهمة بنجاح") ;
      }
    });

  }

  getRoles(){
    this.http.get(this.baseUrl+'user/GetUserRoles').subscribe({
      next: response => this.userTypes= response,
      error: error => console.log(error),
      complete: () => console.log(this.userTypes)
    })
  }

 
}
