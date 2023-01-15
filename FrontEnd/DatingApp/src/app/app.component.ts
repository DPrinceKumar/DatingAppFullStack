import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'DatingApp';
  users: any;
  constructor(private http: HttpClient) {}
  ngOnInit(): void {
    this.http.get('https://localhost:7205/api/getInfo').subscribe({
      next: (resp) => {
        this.users = resp;
        console.log(resp);
      },
      error: (err) => console.log(err),
      complete() {
        console.log('Completed');
      },
    });
  }
}
