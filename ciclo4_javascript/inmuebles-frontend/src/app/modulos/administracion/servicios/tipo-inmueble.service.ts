import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TipoInmuebleModel } from '../../../modelos/tipo-inmueble.model';

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

  /**
   * Busca un registro por Id
   * @param id id del registro a buscar
   * @returns el registro del id ingresado
   */

  BuscaRegistroPorId(id: string): Observable<TipoInmuebleModel> {
    return this.http.get<TipoInmuebleModel>(this.url + '/' + id);
  }

  /**
   *  Almacena un nuevo registro
   * @param nombre propiedad del registro
   * @returns registro creado
   */

  GuardarRegistro(nombre: string): Observable<TipoInmuebleModel> {
    return this.http.post<TipoInmuebleModel>(this.url, { nombre: nombre });
  }

  /**
   *  Almacena un nuevo registro
   * @param id id del registro
   * @param nombre nuevo nombre
   * @returns Observable vacío
   */

  EditarRegistro(id: string, nombre: string): Observable<any> {
    return this.http.put<any>(this.url + '/' + id, { nombre: nombre });
  }

  /**
   *  Almacena un nuevo registro
   * @param id id del registro a eliminar
   * @returns NA
   */

  EliminarRegistro(id: string): Observable<any> {
    return this.http.delete<any>(this.url + '/' + id);
  }
}
