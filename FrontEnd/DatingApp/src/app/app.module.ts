import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './components/nav/nav.component';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './components/home/home.component';
import { RegisterComponent } from './components/register/register.component';
import { ListComponent } from './components/list/list.component';
import { MemberDetailsComponent } from './components/members/member-details/member-details.component';
import { MemberListsComponent } from './components/members/member-lists/member-lists.component';
import { MessageComponent } from './components/message/message.component';
import { SharedModule } from './_Modules/shared.module';
import { TestErrorComponent } from './components/errors/test-error/test-error.component';
import { ErrorsInterceptor } from './_interceptors/errors.interceptor';
import { NotFoundComponent } from './components/errors/not-found/not-found.component';
import { ServerErrorComponent } from './components/errors/server-error/server-error.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    ListComponent,
    MemberDetailsComponent,
    MemberListsComponent,
    MessageComponent,
    TestErrorComponent,
    NotFoundComponent,
    ServerErrorComponent,
  ],
  imports: [
  BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    SharedModule

  ],
  providers: [
    {provide:HTTP_INTERCEPTORS, useClass:ErrorsInterceptor,multi:true}
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
