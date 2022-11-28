import { Component, inject, OnInit } from '@angular/core';
import { NonNullableFormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TipoInmuebleService } from 'src/app/servicios/tipo-inmueble.service';

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
    private router: Router
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
          alert('Almacenado correctamente.');
        },
        error: (err) => {
          alert('Error almacenando la información.');
        },
      });
    }
  }
}
