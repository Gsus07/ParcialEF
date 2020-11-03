import { Component, OnInit } from '@angular/core';
import { PersonaService } from 'src/app/services/persona.service';
import { Persona } from '../models/persona';

@Component({
  selector: 'app-persona-consulta',
  templateUrl: './persona-consulta.component.html',
  styleUrls: ['./persona-consulta.component.css']
})
export class PersonaConsultaComponent implements OnInit {
  personas: Persona[];
  CantidadEntregada: number = 0;
  constructor(private personaService: PersonaService) { }
  ngOnInit() {
  }

  get(): void {
    this.personaService.get().subscribe(result => {
      if (result != null) {
        this.personas = result;
        this.ApoyoEntregado();
      }

    });
  }
  ApoyoEntregado() {
    this.personaService.getSumaApoyo().subscribe(s => {
      this.CantidadEntregada = s;
    });
  }

}
