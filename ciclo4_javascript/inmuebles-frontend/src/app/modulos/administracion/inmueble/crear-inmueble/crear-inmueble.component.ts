import { Component, inject, OnInit } from '@angular/core';
import { NonNullableFormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { InmuebleService } from '@modulos/administracion/servicios/inmueble.service';
import { TipoInmuebleService } from '@modulos/administracion/servicios/tipo-inmueble.service';
import { InmuebleModel } from 'src/app/modelos/Inmueble.model';
import { TipoInmuebleModel } from 'src/app/modelos/tipo-inmueble.model';

@Component({
  selector: 'app-crear-inmueble',
  templateUrl: './crear-inmueble.component.html',
  styleUrls: ['./crear-inmueble.component.scss'],
})
export class CrearInmuebleComponent implements OnInit {
  opcionesTipoInmueble: TipoInmuebleModel[] = [];
  private fb = inject(NonNullableFormBuilder);

  public inmuebleForm = this.fb.group({
    propietario: ['', [Validators.required]],
    telefono: ['', [Validators.required]],
    direccion: ['', [Validators.required]],
    tipoId: ['', [Validators.required]],
  });

  constructor(
    private router: Router,
    private servicioInmueble: InmuebleService,
    private servicioTipoInmueble: TipoInmuebleService
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
  }

  submit(): void {
    if (this.inmuebleForm.valid) {
      let propietario = this.inmuebleForm.controls['propietario'].value;
      let telefono = this.inmuebleForm.controls['telefono'].value;
      let direccion = this.inmuebleForm.controls['direccion'].value;
      let tipoInmuebleId = this.inmuebleForm.controls['tipoId'].value;
      let modelo = new InmuebleModel();
      modelo.direccion = direccion;
      modelo.propietario = propietario;
      modelo.telefono = telefono;
      modelo.tipoInmuebleId = tipoInmuebleId;
      this.servicioInmueble.GuardarRegistro(modelo).subscribe({
        next: (data) => {
          this.router.navigate(['/listar-inmueble']);
          alert('Almacenado correctamente.');
        },
        error: (err) => {
          alert('Error almacenando la información.');
        },
      });
    }
  }
}
