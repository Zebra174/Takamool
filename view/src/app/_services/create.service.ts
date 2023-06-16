import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class CreateService {

  baseUrl =  environment.apiUrl;

  constructor(private http : HttpClient) { }

  AddAgent(model:any){
    return this.http.post(this.baseUrl+'issuesTab/AddAgency',model);
  }

  AddService(model:any){
    return this.http.post(this.baseUrl+'issuesTab/AddService',model);
  }

  AddConsulting(model:any){
    return this.http.post(this.baseUrl+'issuesTab/AddConsulting',model);
  }

  AddSession(model:any){
    return this.http.post(this.baseUrl+'issuesTab/AddSession',model);
  }

  // End Of Studies Tab

  
  // -> Beginning Of WorkManagementTab

  AddCustomer(model:any){
    return this.http.post(this.baseUrl+'customer/AddCustomer',model);
  }

  //end of WorkManagement Tab

  //Start of TaskManagementTab
  AddTask(model:any){
    return this.http.post(this.baseUrl+'task/AddTask',model);
  }


  //Settings Tab
  AddUser(model:any){
    return this.http.post(this.baseUrl+'user/AddUser',model);
  }

  //..............................


  //MetFiles
  AddIssueType(model:any){
    return this.http.post(this.baseUrl+'user/AddIssueType',model);
  }
  AddIssueStatus(model:any){
    return this.http.post(this.baseUrl+'user/AddIssueStatus',model);
  }
  AddContractType(model:any){
    return this.http.post(this.baseUrl+'user/AddContractType',model);
  }
  AddServiceType(model:any){
    return this.http.post(this.baseUrl+'user/AddServiceType',model);
  }
  AddUserRoles(model:any){
    return this.http.post(this.baseUrl+'user/AddUserRoles',model);
  }
  
  
}



