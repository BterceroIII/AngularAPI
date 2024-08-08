import { Departamento } from "./Departamento";

export interface Empleado{
    idEmpleado : number;
    nombre : string;
    apellido : string;
    sueldo : number;
    fechaContrato : string;
    departamento: Departamento;
}