import { Component, OnInit } from '@angular/core';
import { AccountService } from './../../_services/Account/account.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

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
  constructor(public _accountServ: AccountService, private _router: Router,
    private toster:ToastrService) {}

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
    return (this.username = JSON.parse(username));
  }

  login() {
    this._accountServ.login(this.model).subscribe({
      next: (_) =>this._router.navigateByUrl('/members'),
      // error: (_err) => { this.toster.error(_err.error.title || _err.error);},
    });
  }

  logOut() {
    this._accountServ.logOut();
    this._router.navigateByUrl('/');
  }
}
