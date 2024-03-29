import { Component, OnInit } from '@angular/core';
import { UserService } from '../core/services/user/user.service';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.scss']
})
export class MyProfileComponent implements OnInit {

  constructor(private user: UserService) { }

  ngOnInit(): void {
  }

  users: any = [];

  getUsers() {
    const token = localStorage.getItem('token');
    if (token) {
      this.user.getAll().subscribe({
        next: (resp) => { console.log(resp); this.users = resp },
        error: (eror) => console.error(eror)
      })
    } else {
      alert("Log in");
    }
  }

  deleteUser(id: number):void {
    const body = {
      "id": id
    }
    this.user.delete(body).subscribe({
      next: resp => {console.log(resp); this.getUsers()},
      error: err => console.log(err)
    });
  }
}
