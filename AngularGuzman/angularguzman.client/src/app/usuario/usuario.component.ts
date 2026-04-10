import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../service/usuario.service';

declare var bootstrap: any;

export interface Usuario {
  idUsuario?: number;
  userName: string;
  nombre: string;
  email: string;
  password: string; // 🔥 AGREGAR
  fechaNacimiento: string;
  estatus: boolean;
}

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent implements OnInit {

  usuarios: Usuario[] = [];

  usuarioSeleccionado: Usuario = {
    userName: '',
    nombre: '',
    email: '',
    password: '', // 🔥 IMPORTANTE
    fechaNacimiento: '',
    estatus: true
  };

  constructor(private usuarioService: UsuarioService) { }

  ngOnInit(): void {
    this.GetAll();
  }

  trackById(index: number, item: Usuario): number {
    return item.idUsuario ?? index;
  }

  // GET ALL
  GetAll() {
    this.usuarioService.getAll().subscribe({
      next: (response: any) => {
        if (response.correct) {
          this.usuarios = response.objects || [];
        }
      },
      error: (error) => console.error(error)
    });
  }

  // AGREGAR
  agregar() {
    this.usuarioSeleccionado = {
      userName: '',
      nombre: '',
      email: '',
      password: '', // 🔥 IMPORTANTE
      fechaNacimiento: '',
      estatus: true
    };
    this.abrirModal();
  }

  // EDITAR
  editar(usuario: Usuario) {
    this.usuarioSeleccionado = { ...usuario };
    this.abrirModal();
  }

  // MODAL
  abrirModal() {
    const modal = new bootstrap.Modal(document.getElementById('usuarioModal'));
    modal.show();
  }

  cerrarModal() {
    const modalElement = document.getElementById('usuarioModal');
    const modalInstance = bootstrap.Modal.getInstance(modalElement);
    modalInstance?.hide();
  }

  // GUARDAR
  guardar() {

    if (!this.usuarioSeleccionado.userName || !this.usuarioSeleccionado.email) {
      alert('UserName y Email son obligatorios');
      return;
    }

    if (this.usuarioSeleccionado.idUsuario !== undefined) {

      this.usuarioService.update(this.usuarioSeleccionado).subscribe({
        next: () => {
          this.GetAll();
          this.cerrarModal();
        }
      });

    } else {

      this.usuarioService.add(this.usuarioSeleccionado).subscribe({
        next: () => {
          this.GetAll();
          this.cerrarModal();
        }
      });
    }
  }

  // ELIMINAR
  eliminar(idUsuario?: number) {

    if (!idUsuario) return;

    if (confirm('¿Eliminar usuario?')) {

      this.usuarioService.delete(idUsuario).subscribe({
        next: () => {
          this.usuarios = this.usuarios.filter(u => u.idUsuario !== idUsuario);
        }
      });
    }
  }
}
