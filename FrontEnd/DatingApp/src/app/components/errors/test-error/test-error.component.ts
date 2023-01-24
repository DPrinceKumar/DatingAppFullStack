import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.css'],
})
export class TestErrorComponent implements OnInit {
  errorUrl = 'https://localhost:7215/';
  validationErrors:string[] = [];
  constructor(private http: HttpClient) {
    // this.http.get();
  }
  ngOnInit(): void {
    // throw new Error('Method not implemented.');
  }

  get400Error() {
    return this.http.get(this.errorUrl + 'bad-request').subscribe({
      next: (_) => console.log(_),
      error: (error) => console.log(error),
    });
  }

  get400ValidationError() {
    return this.http.post(this.errorUrl + 'api/Account/register',{}).subscribe({
      next: (_) => console.log(_),
      error: (error) =>{
        this.validationErrors=error;
      },
    });
  }
  get401Error() {
    return this.http.get(this.errorUrl + 'auth').subscribe({
      next: (_) => console.log(_),
      error: (error) => console.log(error),
    });
  }
  get404Error() {
    return this.http.get(this.errorUrl + 'not-found').subscribe({
      next: (_) => console.log(_),
      error: (error) => console.log(error),
    });
  }

  get500Error() {
    return this.http.get(this.errorUrl + 'server-Error').subscribe({
      next: (_) => console.log(_),
      error: (error) => console.log(),
    });
  }
}
