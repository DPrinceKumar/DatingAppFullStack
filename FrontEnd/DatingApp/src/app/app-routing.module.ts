import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './components/errors/not-found/not-found.component';
import { ServerErrorComponent } from './components/errors/server-error/server-error.component';
import { TestErrorComponent } from './components/errors/test-error/test-error.component';
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
    runGuardsAndResolvers: 'always',
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
    ],
  },
  { path: 'error', component: TestErrorComponent },

  { path: 'not-found', component: NotFoundComponent },

  { path: 'server-error', component: ServerErrorComponent },

  { path: '**', component: NotFoundComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
