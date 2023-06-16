import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UpdateService } from 'src/app/_services/update.service';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent {
  baseUrl =  environment.apiUrl;
  user: any;
  userRoles:any;
 
  constructor(private route:ActivatedRoute,private http:HttpClient, private updateService:UpdateService,
     private toastr: ToastrService,private router:Router){}
  
  ngOnInit(): void {
   this.route.paramMap.subscribe({
    next: (params) => {
      const id = params.get('id');

      if(id) {
          this.getUser(id).subscribe({
            next: response => this.user = response,
            error: error => console.log(error),
            complete: () => console.log(this.user)
          })
      }
    }
   })

  this.getUserRoles();
  
  }

  updateUser(id:string){
     this.updateService.UpdateUser(id,this.user).subscribe({
      next: () => {
         this.router.navigateByUrl('/UserAuth')
       },
      error: error => {
       
          this.toastr.error(error.error)
      },
      complete: () =>{
        this.toastr.success("تم تعديل المستخدم بنجاح") ;
      }
    });
  }

  getUser(id:string){
    return this.http.get(this.baseUrl+'user/GetUser/'+id);
  }

  getUserRoles(){
    this.http.get(this.baseUrl+'user/GetUserRoles').subscribe({
      next: response => this.userRoles=response,
      error: error => console.log(error),
      complete: () => console.log(this.userRoles)
    })
  }

}
