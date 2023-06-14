import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CreateService } from 'src/app/_services/create.service';

@Component({
  selector: 'app-add-tasks',
  templateUrl: './add-tasks.component.html',
  styleUrls: ['./add-tasks.component.css']
})
export class AddTasksComponent {
  addTaskForm: FormGroup = new FormGroup({});
  choose1: string = 'اختر نوع الحالة';
  choose3: string = 'الوظيفة';
  choose2: string = 'اختر اسم الموظف';
  validationErrors:string[]  | undefined;
  taskStatus:any
  users:any;
  roles:any;

  constructor(private http: HttpClient, private createService: CreateService, private toastr: ToastrService, private router: Router,
    private fb:FormBuilder) { }
  ngOnInit(): void {
    this.IntializForm();
    this.getStatuses();
    this.getUser();
    this.getUserRoles();
  }

  IntializForm() {
    this.addTaskForm = this.fb.group({
      taskStatus:['اختر نوع الحالة', [Validators.required, this.checkNull(this.choose1)]],
      title: [null, Validators.required],
      projectedStart: [null, Validators.required],
      projectedEnd:[null, Validators.required],
      empName:['اختر اسم الموظف', [Validators.required, this.checkNull(this.choose2)]],
      projManger:['الوظيفة', [Validators.required, this.checkNull(this.choose3)]],
      description:[],
      actualEnd:[null],
      dueDate:[null],
      active:[false],
    })
  }

  checkNull(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {

      return control.value == matchTo ? { empty: true } : null;
    }


  }

  AddTask() {
    // console.log(this.addAgentForm?.value);
    this.createService.AddTask(this.addTaskForm.value).subscribe({
      next: () => {
         this.router.navigateByUrl('/ManageTask')
       },
      error: error => {
            this.toastr.error("برجاء ادخال القيم المطلوبة")
            console.log(error)
      },
      complete: () =>{
        this.toastr.success("تم اضافة المهمة بنجاح") ;
      }
    });

  }

  getStatuses(){
    this.http.get('https://localhost:5001/api/task/GetStatuses').subscribe({
      next: response => this.taskStatus= response,
      error: error => console.log(error),
      complete: () => console.log(this.taskStatus)
    })
  }

  getUser(){
    this.http.get('https://localhost:5001/api/user/GetUsers').subscribe({
      next: response => this.users= response,
      error: error => console.log(error),
   
    })
  }

  getUserRoles(){
    this.http.get('https://localhost:5001/api/user/GetUserRoles').subscribe({
      next: response => this.roles= response,
      error: error => console.log(error),
    
    })
  }

 


}
