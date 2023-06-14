import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import { ModalModule } from 'ngx-bootstrap/modal';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SidebarComponent } from './sidebar/sidebar.component';
import { CardComponent } from './card/card.component';
import { SearchBarComponent } from './search-bar/search-bar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DerasatComponent } from './Pages/StudiesTab/derasat/derasat.component';
import { HomeComponent } from './home/home.component';
import { AgentsComponent } from './Pages/StudiesTab/agents/agents.component';
import { KhadamatKanonyiaComponent } from './Pages/StudiesTab/khadamat-kanonyia/khadamat-kanonyia.component';
import { SessionsComponent } from './Pages/StudiesTab/sessions/sessions.component';
import { AddUsersComponent } from './Pages/Settings/add-users/add-users.component';
import { MetaFilesComponent } from './Pages/Settings/meta-files/meta-files.component';
import { UserAuthComponent } from './Pages/Settings/user-auth/user-auth.component';
import { AddTasksComponent } from './Pages/TaskManagementTab/add-tasks/add-tasks.component';
import { TaskManageComponent } from './Pages/TaskManagementTab/task-manage/task-manage.component';
import { TaskSummaryComponent } from './Pages/TaskManagementTab/task-summary/task-summary.component';
import { AddClientDataComponent } from './Pages/WorkManagementTab/add-client-data/add-client-data.component';
import { ClientsDataComponent } from './Pages/WorkManagementTab/clients-data/clients-data.component';
import { ConsultingComponent } from './Pages/WorkManagementTab/consulting/consulting.component';
import { ToastrModule } from 'ngx-toastr';
import { SearchTableComponent } from './search-table/search-table.component';
import { SearchFilterPipe } from './search-table/search-filter.pipe';
import { AddAgentsComponent } from './SubPages/StudiesTab/add-agents/add-agents.component';
import { TextInputComponent } from './_forms/text-input/text-input.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { LoadingInterceptor } from './_interceptors/loading.interceptor';
import { AddLegalServicesComponent } from './SubPages/StudiesTab/add-legal-services/add-legal-services.component';
import { AddSessionComponent } from './SubPages/StudiesTab/add-session/add-session.component';
import { SessionsReportComponent } from './Pages/Reports/sessions-report/sessions-report.component';
import { CustomersReportComponent } from './Pages/Reports/customers-report/customers-report.component';
import { ServicesReportComponent } from './Pages/Reports/services-report/services-report.component';




@NgModule({
  declarations: [
    AppComponent,
    SidebarComponent,
    CardComponent,
    SearchBarComponent,
    DerasatComponent,
    HomeComponent,
    AgentsComponent,
    KhadamatKanonyiaComponent,
    SessionsComponent,
    AddUsersComponent,
    MetaFilesComponent,
    UserAuthComponent,
    AddTasksComponent,
    TaskManageComponent,
    TaskSummaryComponent,
    AddClientDataComponent,
    ClientsDataComponent,
    ConsultingComponent,
    SearchTableComponent,
    SearchFilterPipe,
    AddAgentsComponent,
    TextInputComponent,
    AddLegalServicesComponent,
    AddSessionComponent,
    SessionsReportComponent,
    CustomersReportComponent,
    ServicesReportComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    NgxSpinnerModule.forRoot(
      {type: 'line-scale-pulse-out'}
    ),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',

    }),
  
   
  ],
  providers: [    {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
