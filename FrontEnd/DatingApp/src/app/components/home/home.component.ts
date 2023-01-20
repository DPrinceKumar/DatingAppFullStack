import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core'


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  users: any;
  constructor(private http: HttpClient) {}
  ngOnInit(): void {
    this.getUser();
  }
  registerMode = false;
  registerModeToggle() {
    this.registerMode = !this.registerMode;
  }
  cancleRegisterMode(event:boolean){
    this.registerMode = event;
  }

  getUser() {
    this.http.get('https://localhost:7215/api/getInfo').subscribe({
      next: (resp) => {
        this.users = resp;
      },
      error: (err) => console.log(err),
      complete() {},
    });
  }
}
