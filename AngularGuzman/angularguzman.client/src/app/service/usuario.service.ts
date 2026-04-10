import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

// ✅ Interfaz (tipado fuerte)
export interface Usuario {
  idUsuario?: number;
  userName: string;
  nombre: string;
  email: string;
  password: string; // 🔥 AGREGAR
  fechaNacimiento: string;
  estatus: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  private apiUrl = 'https://localhost:7217/api/Usuario/';
  private authUrl = 'https://localhost:7217/api/Auth';

  constructor(private http: HttpClient) { }

  // 🔹 HEADERS (opcional para token después)
  private getHeaders(): HttpHeaders {
    return new HttpHeaders({
      'Content-Type': 'application/json'
      // 'Authorization': 'Bearer ' + localStorage.getItem('token')
    });
  }

  // ✅ GET ALL
  getAll(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}GetAll`);
  }

  // ✅ GET BY ID
  getById(idUsuario: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}GetById/${idUsuario}`);
  }

  // ✅ DELETE
  delete(idUsuario: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}Delete/${idUsuario}`);
  }

  // ✅ UPDATE
  update(usuario: Usuario): Observable<any> {
    return this.http.put<any>(
      `${this.apiUrl}Update`,
      usuario,
      { headers: this.getHeaders() }
    );
  }

  // ✅ ADD
  add(usuario: Usuario): Observable<any> {
    return this.http.post<any>(
      `${this.apiUrl}Add`,
      usuario,
      { headers: this.getHeaders() }
    );
  }

  // ✅ LOGIN
  login(data: { email: string; password: string }): Observable<any> {
    return this.http.post<any>(this.authUrl, data);
  }

}
