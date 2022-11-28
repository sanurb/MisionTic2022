import { Component, OnInit } from '@angular/core';
import { InmuebleService } from '@modulos/administracion/servicios/inmueble.service';
import { InmuebleModel } from 'src/app/modelos/Inmueble.model';

@Component({
  selector: 'app-listar-inmueble',
  templateUrl: './listar-inmueble.component.html',
  styleUrls: ['./listar-inmueble.component.scss'],
})
export class ListarInmuebleComponent implements OnInit {
  listaRegistros: InmuebleModel[] = [];

  constructor(private servicioInmueble: InmuebleService) {}

  ngOnInit(): void {
    this.servicioInmueble.ListarRegistros().subscribe({
      next: (data) => {
        this.listaRegistros = data;
      },
      error: (err) => {
        alert('Error obteniendo la información.');
      },
    });
  }

}
