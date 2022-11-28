import { Component, inject, OnInit } from '@angular/core';
import { NonNullableFormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TipoInmuebleService } from '@modulos/administracion/servicios/tipo-inmueble.service';

@Component({
  selector: 'app-editar-tipo-inmueble',
  templateUrl: './editar-tipo-inmueble.component.html',
  styleUrls: ['./editar-tipo-inmueble.component.scss'],
})
export class EditarTipoInmuebleComponent implements OnInit {

  private fb = inject(NonNullableFormBuilder);
  public EditarTipoInmuebleForm = this.fb.group({
    id: ['', [Validators.required]],
    tipo_inmueble: ['', [Validators.required]],
  });

  constructor(
    private servicioTipoInmueble: TipoInmuebleService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.BuscarRegistro();
  }

  /**
   * Busca un registro por id
   */

  BuscarRegistro() {
    let id = this.route.snapshot.params['id'];
    this.servicioTipoInmueble.BuscaRegistroPorId(id).subscribe({
      next: (data) => {
        this.EditarTipoInmuebleForm.controls['id'].setValue(data._id);
        this.EditarTipoInmuebleForm.controls['tipo_inmueble'].setValue(data.nombre);
      },
      error: (err) => {
        alert('Error buscando la información.');
      },
    });
  }

  /**
   * Editar un registro
   */

  EditarRegistro() {
    if (this.EditarTipoInmuebleForm.valid) {
      let nombre = this.EditarTipoInmuebleForm.controls['tipo_inmueble'].value;
      let id = this.EditarTipoInmuebleForm.controls['id'].value;
      this.servicioTipoInmueble.EditarRegistro(id, nombre).subscribe({
        next: (data) => {
          this.router.navigate(['/listar-tipo-inmueble']);
          alert('Modificado correctamente.');
        },
        error: (err) => {
          alert('Error editando la información.');
        },
      });
    }
  }
}
