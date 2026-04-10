import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {

  usuario = {
    email: '',
    password: ''
  };

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    const token = localStorage.getItem('token');

    if (token) {
      this.router.navigate(['/usuarios']);
    }
  }

  login() {
    this.http.post('https://localhost:7217/api/Auth', this.usuario)
      .subscribe({
        next: (response: any) => {

          // 🔐 guardar token
          localStorage.setItem('token', response.token);

          this.router.navigate(['/usuarios']);
        },
        error: () => {
          alert('Credenciales incorrectas');
        }
      });
  }
}
