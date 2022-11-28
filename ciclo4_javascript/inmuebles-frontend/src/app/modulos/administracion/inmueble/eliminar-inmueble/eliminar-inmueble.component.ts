import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { InmuebleService } from '@modulos/administracion/servicios/inmueble.service';
import { HotToastService } from '@ngneat/hot-toast';

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
    private route: ActivatedRoute,
    private toast: HotToastService,
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
        this.toast.error('Error buscando la información.');
      },
    });
  }

  EliminarRegistro() {
    this.servicioInmueble.EliminarRegistro(this.idPorEliminar).subscribe({
      next: (data) => {
        this.router.navigate(['/listar-inmueble']);
        this.toast.success('Eliminado correctamente.');
      },
      error: (err) => {
        this.toast.error('Error editando la información.');
      },
    });
  }
}
