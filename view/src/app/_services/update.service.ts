import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class UpdateService {
  baseUrl =  environment.apiUrl;

  constructor(private http : HttpClient) { }

  UpdateAgent(id:string,model:any){
    return this.http.put(this.baseUrl+'issuesTab/UpdateAgent/'+id,model);
  }

  UpdateIssue(id:string,model:any){
    return this.http.put(this.baseUrl+'issuesTab/UpdateIssue/'+id,model);
  }

  UpdateSession(id:string,model:any){
    return this.http.put(this.baseUrl+'issuesTab/UpdateSession/'+id,model);
  }

  UpdateConsulting(id:string,model:any){
    return this.http.put(this.baseUrl+'issuesTab/UpdateConsulting/'+id,model);
  }

  UpdateCustomer(id:string,model:any){
    return this.http.put(this.baseUrl+'customer/UpdateCustomer/'+id,model);
  }

  UpdateUser(id:string,model:any){
    return this.http.put(this.baseUrl+'user/UpdateUser/'+id,model);
  }


  UpdateIssueType(id:string,model:any){
    return this.http.put(this.baseUrl+'user/UpdateIssueType/'+id,model);
  }
  UpdateIssueStatus(id:string,model:any){
    return this.http.put(this.baseUrl+'user/UpdateIssueStatus/'+id,model);
  }
  UpdateContractTypes(id:string,model:any){
    return this.http.put(this.baseUrl+'user/UpdateContractType/'+id,model);
  }
  UpdateServiceTypes(id:string,model:any){
    return this.http.put(this.baseUrl+'user/UpdateServiceType/'+id,model);
  }
  UpdateUserRoles(id:string,model:any){
    return this.http.put(this.baseUrl+'user/UpdateUserRole/'+id,model);
  }
}
