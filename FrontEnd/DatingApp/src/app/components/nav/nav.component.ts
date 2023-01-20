import { Component, OnInit } from '@angular/core';
import { AccountService } from './../../_services/Account/account.service';
import { User } from 'src/app/_models/user';
import { Observable, of } from 'rxjs';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  model: any = {
    username: '',
    password: '',
  };

  username = '';
  constructor(public _accountServ: AccountService) {}

  ngOnInit(): void {
    this.getCurrentUSer();
  }

  getCurrentUSer() {
    // this._accountServ.currentUserSource$.subscribe({
    //   next:user=>{
    //     const username=localStorage.getItem('username');
    //     if (!username) return;
    //     this.username = JSON.parse(username);
    //     console.log(username);
    //   },
    //   error:error=>console.log(error)
    // })
    const username = localStorage.getItem('username');
    if (!username) return;
    return this.username = JSON.parse(username);
  }

  login() {
    this._accountServ.login(this.model).subscribe({
      next: (_resp) => {
        console.log(_resp);
      },
      error: (_err) => console.log(_err.error),
    });
  }

  logOut() {
    this._accountServ.logOut();
  }
}
