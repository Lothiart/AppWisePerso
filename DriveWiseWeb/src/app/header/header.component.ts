import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router'

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})

export class HeaderComponent  implements OnInit {
  constructor(private router: Router) { }

  onClickLogin() {
    this.router.navigate(['/login']); 
  }
  onClickHome() {
    this.router.navigate(['/template']);
  }
  loginButtonClick = new EventEmitter<void>();
  ngOnInit(): void {

  }
}
