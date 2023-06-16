import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UpdateService } from 'src/app/_services/update.service';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-edit-session',
  templateUrl: './edit-session.component.html',
  styleUrls: ['./edit-session.component.css']
})
export class EditSessionComponent {
  baseUrl =  environment.apiUrl;
  session:any;
  issues: any;
  form: FormGroup = new FormGroup({});;
  
 
  constructor(private route:ActivatedRoute,private http:HttpClient, private updateService:UpdateService, 
    private toastr: ToastrService,private router:Router ,private fb:FormBuilder){}
  
  ngOnInit(): void {
    this.InitializeForm();
   this.route.paramMap.subscribe({
    next: (params) => {
      const id = params.get('id');

      if(id) {
          this.getSession(id).subscribe({
            next: response => this.session = response,
            error: error => console.log(error),
            complete: () => console.log(this.session.sessionDate)
          })
      }
    }
   })
   this.getIssues();
  }

  InitializeForm(){
    this.form = this.fb.group({
      aisuueNumber:[],
      sessionName: [],
      sessionNextName: [],
      sessionNote: [],
      sessionDate:[],
      sessionNextDate:[],
      customerInv:[],
    })
  }

  updateSession(id:string){
    this.session.customerInv == false ? this.session.customerInv=0 : this.session.customerInv=1
    
     this.updateService.UpdateSession(id,this.session).subscribe({
      next: () => {
         this.router.navigateByUrl('/Sessions')
       },
      error: error => {
          this.toastr.error(error.error);
          console.log(this.session.sessionDate)
      },
      complete: () =>{
        this.toastr.success("تم تعديل الجلسة بنجاح") ;
        console.log(this.session.sessionDate)
      }
    });
  }

  getSession(id:string){
    return this.http.get(this.baseUrl+'issuesTab/GetSession/'+id);
  }

  getIssues() {
    this.http.get(this.baseUrl+'issuesTab/GetIssues').subscribe({
      next: response => this.issues = response,
      error: error => console.log(error),
      complete: () => console.log("Request has completed")
    })
  }

}
