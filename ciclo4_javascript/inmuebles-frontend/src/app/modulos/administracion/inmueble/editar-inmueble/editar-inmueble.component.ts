import { Component, inject, OnInit } from '@angular/core';
import { NonNullableFormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { InmuebleService } from '@modulos/administracion/servicios/inmueble.service';
import { TipoInmuebleService } from '@modulos/administracion/servicios/tipo-inmueble.service';
import { InmuebleModel } from 'src/app/modelos/Inmueble.model';
import { TipoInmuebleModel } from 'src/app/modelos/tipo-inmueble.model';

@Component({
  selector: 'app-editar-inmueble',
  templateUrl: './editar-inmueble.component.html',
  styleUrls: ['./editar-inmueble.component.scss'],
})
export class EditarInmuebleComponent implements OnInit {
  opcionesTipoInmueble: TipoInmuebleModel[] = [];
  private fb = inject(NonNullableFormBuilder);

  public inmuebleEditForm = this.fb.group({
    id: ['', [Validators.required]],
    propietario: ['', [Validators.required]],
    telefono: ['', [Validators.required]],
    direccion: ['', [Validators.required]],
    tipoId: ['', [Validators.required]],
  });

  constructor(
    private servicioInmueble: InmuebleService,
    private router: Router,
    private servicioTipoInmueble: TipoInmuebleService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.servicioTipoInmueble.ListarRegistros().subscribe({
      next: (data) => {
        this.opcionesTipoInmueble = data;
      },
      error: (err) => {
        alert('Error cargando la información.');
      },
    });
    this.BuscarRegistro();
  }

  BuscarRegistro() {
    let id = this.route.snapshot.params['id'];
    this.servicioInmueble.BuscaRegistroPorId(id).subscribe({
      next: (data) => {
        this.inmuebleEditForm.controls['id'].setValue(data._id);
        this.inmuebleEditForm.controls['propietario'].setValue(
          data.propietario
        );
        this.inmuebleEditForm.controls['direccion'].setValue(data.direccion);
        this.inmuebleEditForm.controls['telefono'].setValue(data.telefono);
        this.inmuebleEditForm.controls['tipoId'].setValue(data.tipoInmuebleId);
      },
      error: (err) => {
        alert('Error buscando la información.');
      },
    });
  }

  EditarRegistro() {
    if (this.inmuebleEditForm.valid) {
      let id = this.inmuebleEditForm.controls['id'].value;
      let propietario = this.inmuebleEditForm.controls['propietario'].value;
      let telefono = this.inmuebleEditForm.controls['telefono'].value;
      let direccion = this.inmuebleEditForm.controls['direccion'].value;
      let tipoInmuebleId = this.inmuebleEditForm.controls['tipoId'].value;
      let modelo = new InmuebleModel();
      modelo.direccion = direccion;
      modelo.propietario = propietario;
      modelo.telefono = telefono;
      modelo.tipoInmuebleId = tipoInmuebleId;
      modelo._id = id;
      this.servicioInmueble.EditarRegistro(modelo).subscribe({
        next: (data) => {
          this.router.navigate(['/listar-inmueble']);
          alert('Editado correctamente.');
        },
        error: (err) => {
          alert('Error editando la información.');
        },
      });
    }
  }
}
