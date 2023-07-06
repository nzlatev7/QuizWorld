import { Component, OnInit } from '@angular/core';
import { UserService } from '../core/services/user/user.service';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(private user: UserService) { }

  ngOnInit(): void {
  }

  

  users: any = [];

  getUsers() {
    this.user.getAll().subscribe({
      next: (resp) => {console.log(resp);this.users=resp},
      error: (eror) => console.error(eror)
    })
  }
}