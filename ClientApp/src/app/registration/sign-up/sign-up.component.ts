import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/core/services/user/user.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent implements OnInit {

  constructor(private user: UserService,
              private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm){
    const body = {
      username: form.value.username,
      email: form.value.email,
      password: form.value.password
    }
    this.user.registrate(body).subscribe({
      next: () => this.router.navigate(['signIn']),
      error: (error: any) => console.log(error)
    });
  }
}
