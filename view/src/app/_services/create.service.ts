import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CreateService {

  baseUrl = 'https://localhost:5001/api/';

  constructor(private http : HttpClient) { }

  AddAgent(model:any){
    return this.http.post(this.baseUrl+'issuesTab/AddAgency',model);
  }

  AddService(model:any){
    return this.http.post(this.baseUrl+'issuesTab/AddService',model);
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
  
  
}



