import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    this.checkToken();
  }

  islogged = false;

  logOut():void{
    localStorage.removeItem('token');
    this.checkToken();
  }

  checkToken():void{
    const token = localStorage.getItem('token');
    if(token){
      this.islogged = true;
    } else{
      this.islogged = false;
    }
  }

}
