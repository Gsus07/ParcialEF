
import { Persona } from '../Ayuda/models/persona';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { tap, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { DecimalPipe } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {

  baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }
  deliveredVale: number = 0;
  maxAids: number = 600000000;

  getPersona(persona: Persona): Observable<Persona> {

    return this.http.get<Persona>(this.baseUrl + 'api/Persona' + '/' + persona.identificacion)
      .pipe(tap(_ => this.handleErrorService.log('verificado con exito')),
        catchError(this.handleErrorService.handleError<Persona>('buscado con exito', new Persona()))
      );
  }

  post(persona: Persona): Observable<Persona> {
    return this.http.post<Persona>(this.baseUrl + 'api/Persona', persona)
      .pipe(tap(_ => this.handleErrorService.log('datos guardados')),
        catchError(this.handleErrorService.handleError<Persona>('Registro Persona', null))
      );
  }

  get(): Observable<Persona[]> {
    return this.http.get<Persona[]>(this.baseUrl + 'api/Persona').
      pipe(tap(_ => this.handleErrorService.log('datos consultados')),
        catchError(this.handleErrorService.handleError<Persona[]>('Consultar de Persona', null))
      );
  }
  getSumaApoyo(): Observable<number> {
    return this.http.get<number>(this.baseUrl + 'api/Apoyo')
      .pipe(tap(_ => this.handleErrorService.log('Apoyos consultados')),
        catchError(this.handleErrorService.handleError<number>('Suma', 0))
      );
  }
 
}
