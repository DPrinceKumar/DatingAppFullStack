import { Component, OnInit } from '@angular/core';
import { Router, NavigationExtras } from '@angular/router';

@Component({
  selector: 'app-server-error',
  templateUrl: './server-error.component.html',
  styleUrls: ['./server-error.component.css']
})
export class ServerErrorComponent implements OnInit {
  error: any;
  
  constructor(private router:Router) {

    const navigation=this.router.getCurrentNavigation();
    this.error = navigation?.extras?.state?.['error'];
    // console.log("object",this.error);
  }
  ngOnInit(): void {
    // throw new Error('Method not implemented.');
  }
}
