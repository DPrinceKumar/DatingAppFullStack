import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ListComponent } from './components/list/list.component';
import { MemberDetailsComponent } from './components/members/member-details/member-details.component';
import { MemberListsComponent } from './components/members/member-lists/member-lists.component';
import { MessageComponent } from './components/message/message.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: '',
    runGuardsAndResolvers: "always",
    canActivate: [AuthGuard],
    children: [
      {
        path: 'members',
        component: MemberListsComponent,
      },
      {
        path: 'members/:id',
        component: MemberDetailsComponent,
      },
      {
        path: 'lists',
        component: ListComponent,
      },
      {
        path: 'messages',
        component: MessageComponent,
      },
    ]
  },

  {
    path: '**',
    component: HomeComponent,
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
