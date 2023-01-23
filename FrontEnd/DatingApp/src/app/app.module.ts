import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
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
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    SharedModule

  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
