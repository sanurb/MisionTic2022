import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TipoInmuebleModel } from '../modelos/tipo-inmueble.model';

@Injectable({
  providedIn: 'root',
})
export class TipoInmuebleService {
  url: string = 'http://localhost:3000/tipo-inmueble';

  constructor(private http: HttpClient) {}

  /**
   * Lista los registros de la base de datos
   * @returns arreglo con los objetos de los registros
   */

  ListarRegistros(): Observable<TipoInmuebleModel[]> {
    return this.http.get<TipoInmuebleModel[]>(this.url);
  }
}
