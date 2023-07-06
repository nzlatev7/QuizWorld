import { Component, OnInit } from '@angular/core';
import { UserService } from '../core/services/user/user.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {

  constructor(private user: UserService) { }

  ngOnInit(): void {
  }

}
