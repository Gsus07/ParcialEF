import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { PersonaConsultaComponent } from './Ayuda/persona-consulta/persona-consulta.component';
import { PersonaRegistroComponent } from './Ayuda/persona-registro/persona-registro.component';
import { LoginComponent } from './login/login.component';
import { JwtInterceptor } from './services/jwt.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    PersonaConsultaComponent,
    PersonaRegistroComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'personaConsulta', component: PersonaConsultaComponent },
      { path: 'personaRegistro', component: PersonaRegistroComponent },
      providers: [{ provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },]

    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
