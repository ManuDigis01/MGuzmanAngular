import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html'
})
export class HeaderComponent {

  constructor(private router: Router) { }

  isLogged(): boolean {
    return localStorage.getItem('token') !== null;
  }

  logout() {
    localStorage.removeItem('token'); // 👈 importante
    this.router.navigate(['/login']);
  }

  goLogin() {
    this.router.navigate(['/login']);
  }
}
