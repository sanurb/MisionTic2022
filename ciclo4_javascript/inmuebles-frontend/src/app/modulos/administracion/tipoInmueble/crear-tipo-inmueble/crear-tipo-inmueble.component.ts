import { Component, inject, OnInit } from '@angular/core';
import { NonNullableFormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TipoInmuebleService } from '@modulos/administracion/servicios/tipo-inmueble.service';
import { HotToastService } from '@ngneat/hot-toast';


@Component({
  selector: 'app-crear-tipo-inmueble',
  templateUrl: './crear-tipo-inmueble.component.html',
  styleUrls: ['./crear-tipo-inmueble.component.scss'],
})
export class CrearTipoInmuebleComponent implements OnInit {
  private fb = inject(NonNullableFormBuilder);
  public inmuebleForm = this.fb.group({
    tipo_inmueble: ['', [Validators.required]],
  });

  constructor(
    private servicioTipoInmueble: TipoInmuebleService,
    private router: Router,
    private toast: HotToastService
  ) {}

  ngOnInit(): void {}

  submit(): void {
    if (this.inmuebleForm.invalid) {
      alert('Faltan datos');
    } else {
      let nombre = this.inmuebleForm.controls['tipo_inmueble'].value;
      this.servicioTipoInmueble.GuardarRegistro(nombre).subscribe({
        next: (data) => {
          this.router.navigate(['/listar-tipo-inmueble']);
          this.toast.success('Almacenado correctamente!');
        },
        error: (err) => {
          this.toast.error('Error almacenando la información.');
        },
      });
    }
  }
}
