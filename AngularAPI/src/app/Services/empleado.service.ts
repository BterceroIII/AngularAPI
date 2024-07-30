import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { appsettings } from '../Settings/appsettings';
import { Empleado } from '../Models/Empleado';
import { ApiResponse } from '../Models/ApiResponse';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmpleadoService {

  private http = inject(HttpClient);
  private apiUrl: string = appsettings.apiUrl + "Empleado";

  constructor() { }

  getEmpleados(): Observable<ApiResponse<Empleado[]>> {
    return this.http.get<ApiResponse <Empleado[]>>(this.apiUrl);
  }

  getEmpleadosId(id:number): Observable<ApiResponse<Empleado[]>>{ 
    return this.http.get<ApiResponse <Empleado[]>>(`${this.apiUrl}/${id}`);
  }

  addEmpleados(objeto:Empleado): Observable<ApiResponse<null>>{
    return this.http.post<ApiResponse<null>>(this.apiUrl,objeto);
  }

  updateEmpleado(objeto:Empleado): Observable<ApiResponse<null>>{
    return this.http.put<ApiResponse<null>>(this.apiUrl,objeto)
  }

  deleteEmpleados(id:number): Observable<ApiResponse<null>>{ 
    return this.http.delete<ApiResponse <null>>(`${this.apiUrl}/${id}`);
  }

}
