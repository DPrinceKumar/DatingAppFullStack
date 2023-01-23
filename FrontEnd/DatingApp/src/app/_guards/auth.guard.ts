import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { Observable } from 'rxjs';
import { AccountService } from './../_services/Account/account.service';
import { ToastrService } from 'ngx-toastr';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private accountService:AccountService,
    private tosterService:ToastrService) {

  }
  canActivate(): Observable<boolean>{
    return this.accountService.currentUserSource$.pipe(
      map(user=>{
        if (user) return true;
        else{
          this.tosterService.error('Login / Authentication required');
          return false;
        }
      })
    );
  }

}
