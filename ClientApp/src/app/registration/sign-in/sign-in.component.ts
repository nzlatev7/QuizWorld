import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/core/services/user/user.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit {

  constructor(private user: UserService,
              private router: Router) { }

  ngOnInit(): void {
  }

  form = new FormGroup({
    username: new FormControl(""),
    password: new FormControl("")
  })

  onSubmit() {
    const body = {
      username: this.form.value.username,
      password: this.form.value.password
    }
    this.router.navigate(["profile"]);
    this.user.logIn(body).subscribe({
      next: resp => localStorage.setItem('token', JSON.stringify(resp)),
      error: error => console.log(error)
    })
    }

}
