import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { InmuebleModel } from '../modelos/Inmueble.model';
@Injectable({
  providedIn: 'root',
})
export class InmuebleService {
  url: string = 'http://localhost:3000/inmueble';
  constructor(private http: HttpClient) {}

  /**
   * Lista los registros de la base de datos
   * @returns arreglo con los objetos de los registros
   */

  ListarRegistros(): Observable<InmuebleModel[]> {
    return this.http.get<InmuebleModel[]>(this.url);
  }

  /**
   * Busca un registro por Id
   * @param id id del registro a buscar
   * @returns el registro del id ingresado
   */

  BuscaRegistroPorId(id: string): Observable<InmuebleModel> {
    return this.http.get<InmuebleModel>(this.url + '/' + id);
  }

  /**
   * Almacena un nuevo registro
   * @param nombre propiedad del registro
   * @returns registro creado
   */

  GuardarRegistro(registro: InmuebleModel): Observable<InmuebleModel> {
    return this.http.post<InmuebleModel>(this.url, {
      propietario: registro.propietario,
      direccion: registro.direccion,
      telefono: registro.telefono,
      tipoInmuebleId: registro.tipoInmuebleId,
    });
  }

  /**
   * ELimina un registro de la base de datos
   * @param id id del registro a eliminar
   * @returns NA
   */

  EliminarRegistro(id: string): Observable<any> {
    return this.http.delete<any>(this.url + '/' + id);
  }
}
