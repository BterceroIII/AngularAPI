import { Component, inject } from '@angular/core';

import {MatCardModule} from '@angular/material/card';
import {MatTableModule} from '@angular/material/table';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import { EmpleadoService } from '../../Services/empleado.service';
import { Empleado } from '../../Models/Empleado';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-inicio',
  standalone: true,
  imports: [MatCardModule,MatTableModule,MatIconModule,MatButtonModule],
  templateUrl: './inicio.component.html',
  styleUrl: './inicio.component.css'
})
export class InicioComponent {
  private empleadoServicio = inject(EmpleadoService);
  public listaEmpleados:Empleado[] = [];
  public displayedColumns: string[] = ['nombre','apellido','sueldo','fechaContrato','departamento','activo','accion'];

  getEmpleados(){
    this.empleadoServicio.getEmpleados().subscribe({
      next:(data)=>{
        if (data.data.length > 0) {
          this.listaEmpleados = data.data;
        }
      },
      error:(err)=>{
        console.log(err.message)
      }
    })
  }

  constructor(private router:Router){

    this.getEmpleados();
  }

  addEmpleado(){
    this.router.navigate(['/empleado',0]);
  }

  updateEmpleado(empleado: Empleado){
    this.router.navigate(['/empleado',empleado.idEmpleado]);
  }

  deleteEmpleado(empleado: Empleado){
    if(confirm("Desea eliminar el empleado" + empleado.nombre + empleado.apellido)){
      this.empleadoServicio.deleteEmpleados(empleado.idEmpleado).subscribe({
        next:(data)=>{
          if (data.message) {
            this.getEmpleados();
          }
          else{
            alert("No se pudo eliminar")
          }
        },
        error:(err)=>{
          console.log(err.message)
        }
      })

    }
  }

}
