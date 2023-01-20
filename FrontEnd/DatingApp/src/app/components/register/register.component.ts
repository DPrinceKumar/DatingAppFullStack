import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AccountService } from 'src/app/_services/Account/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit{
  // @Input() usersFromHomeComponent:any;

  @Output() cancleRegister=new EventEmitter();

  constructor(private _userService:AccountService) {}
  ngOnInit(): void {}


user:any={
  username:'',
  // email:'',
  password:'',
  // gender:'',
}

register(){
  console.log('register',this.user);
  this._userService.register(this.user).subscribe({
    next:(_resp)=>{
      console.log(_resp);
      this.cancle();
    },error:(_err)=>{console.log(_err)}
  })
}
cancle(){
  this.cancleRegister.emit(false);
}
}

