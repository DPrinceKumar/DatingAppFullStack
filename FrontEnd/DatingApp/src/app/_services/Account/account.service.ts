import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs/operators';
import { User } from 'src/app/_models/user';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl = 'https://localhost:7215/api/';

  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentUserSource$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) { }

  // login user
  login(model: any): Observable<any> {
    return this.http.post<User>(this.baseUrl + 'Account/login', model).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
          localStorage['setItem']('token', JSON.stringify(user.token));
          localStorage['setItem']('username', JSON.stringify(user.username));
          localStorage['setItem']('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      })
    );
  }

  //register user
  register(model: any) {
    return this.http.post<User>(this.baseUrl + 'Account/register', model).pipe(
      map((user) => {
        if (user) {
          localStorage['setItem']('token', JSON.stringify(user.token));
          localStorage['setItem']('username', JSON.stringify(user.username));
          localStorage['setItem']('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
        return user;
      })
    );
  }
  setcurrentUser(user: User) {
    this.currentUserSource.next(user);
  }
  logOut() {
    localStorage.clear();
    this.currentUserSource.next(null);
  }
}
