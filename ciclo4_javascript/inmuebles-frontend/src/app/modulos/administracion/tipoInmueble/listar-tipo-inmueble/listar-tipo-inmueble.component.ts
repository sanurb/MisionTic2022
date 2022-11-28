import { Component, OnInit } from '@angular/core';
import { TipoInmuebleModel } from 'src/app/modelos/tipo-inmueble.model';
import { TipoInmuebleService } from 'src/app/servicios/tipo-inmueble.service';

@Component({
  selector: 'app-listar-tipo-inmueble',
  templateUrl: './listar-tipo-inmueble.component.html',
  styleUrls: ['./listar-tipo-inmueble.component.scss']
})
export class ListarTipoInmuebleComponent implements OnInit {

  listaRegistros: TipoInmuebleModel[] = [];
  nombre: string = '';
  idPorEliminar: string = '';

  constructor(
    private servicioTipoInmueble: TipoInmuebleService,
  ) {}

  ngOnInit(): void {
    this.CargarData();
  }

  CargarData(){
    this.servicioTipoInmueble.ListarRegistros().subscribe({
      next: (data) => {
        this.listaRegistros = data;
      },
      error: (err) => {
        alert('Error obteniendo la información.');
      },
    });
  }

}
