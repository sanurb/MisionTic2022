import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { InmuebleService } from '@modulos/administracion/servicios/inmueble.service';

@Component({
  selector: 'app-eliminar-inmueble',
  templateUrl: './eliminar-inmueble.component.html',
  styleUrls: ['./eliminar-inmueble.component.scss'],
})
export class EliminarInmuebleComponent implements OnInit {
  propietario: string = '';
  direccion: string = '';
  telefono: string = '';
  idPorEliminar: string = '';

  constructor(
    private servicioInmueble: InmuebleService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.BuscarRegistro();
  }

  BuscarRegistro() {
    this.idPorEliminar = this.route.snapshot.params['id'];
    this.servicioInmueble.BuscaRegistroPorId(this.idPorEliminar).subscribe({
      next: (data) => {
        this.propietario = data.propietario;
        this.direccion = data.direccion;
        this.telefono = data.telefono;
      },
      error: (err) => {
        alert('Error buscando la información.');
      },
    });
  }

  EliminarRegistro() {
    this.servicioInmueble.EliminarRegistro(this.idPorEliminar).subscribe({
      next: (data) => {
        this.router.navigate(['/listar-inmueble']);
        alert('Eliminado correctamente.');
      },
      error: (err) => {
        alert('Error editando la información.');
      },
    });
  }
}
