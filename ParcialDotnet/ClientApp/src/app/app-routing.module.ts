import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './services/auth.guard';
import { LoginComponent } from './login/login.component';
import { PersonaConsultaComponent } from './Ayuda/persona-consulta/persona-consulta.component';
import { PersonaRegistroComponent } from './Ayuda/persona-registro/persona-registro.component';

const routes: Routes = [
  {
  path: 'personaConsulta',
  component: PersonaConsultaComponent
  },

  {
    path: 'personaRegistro',
    component: PersonaRegistroComponent, canActivate: [AuthGuard]
  },

];


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ]
})
export class AppRoutingModule { }
