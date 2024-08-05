import { Routes } from '@angular/router';
import { InicioComponent } from './Pages/inicio/inicio.component';

export const routes: Routes = [
    {path:'',component:InicioComponent},
    {path:'inicio',component:InicioComponent},
    {path:'empleado/:id',component:InicioComponent},
];
