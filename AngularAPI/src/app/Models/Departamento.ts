import { Empleado } from "./Empleado";

export interface Departamento{
    idDepartamento: number;
    nombre: string;
    empleados?: Empleado[];
}