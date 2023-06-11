import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
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
import { ConsultingComponent } from './Pages/WorkManagementTab/consulting/consulting.component';
import { ClientsDataComponent } from './Pages/WorkManagementTab/clients-data/clients-data.component';
import { AddClientDataComponent } from './Pages/WorkManagementTab/add-client-data/add-client-data.component';
import { AddAgentsComponent } from './SubPages/StudiesTab/add-agents/add-agents.component';
import { AddLegalServicesComponent } from './SubPages/StudiesTab/add-legal-services/add-legal-services.component';
import { AddSessionComponent } from './SubPages/StudiesTab/add-session/add-session.component';

const routes: Routes = [
  {path:'',component:HomeComponent},
  {path:'Studies',component:DerasatComponent},
  {path:'Services',component:KhadamatKanonyiaComponent},
  {path:'Agents',component:AgentsComponent},
  {path:'Sessions',component:SessionsComponent},

  {path:'AddClientData',component:AddClientDataComponent},
  {path:'ClientsData',component:ClientsDataComponent},
  {path:'Consulting',component:ConsultingComponent},

  {path:'AddTask',component:AddTasksComponent},
  {path:'ManageTask',component:TaskManageComponent},
  {path:'TaskSummary',component:TaskSummaryComponent},

  {path:'AddUsers',component:AddUsersComponent},
  {path:'MetaFiles',component:MetaFilesComponent},
  {path:'UserAuth',component:UserAuthComponent},

  {path:'AddAgent',component:AddAgentsComponent},
  {path:'AddLegalServices',component:AddLegalServicesComponent},
  {path:'AddSession',component:AddSessionComponent},

  {path:'**',component:AppComponent,pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
