import { Component, OnInit } from '@angular/core';
import { PersonaService } from 'src/app/services/persona.service';
import { Apoyo } from '../models/Apoyo';
import { Persona } from '../models/persona';

@Component({
  selector: 'app-persona-registro',
  templateUrl: './persona-registro.component.html',
  styleUrls: [ './persona-registro.component.css' ]
})
export class PersonaRegistroComponent implements OnInit {
  persona: Persona;
  Apoyo: Apoyo;
  CantidadDisponible: number = 0;
  CantidadEntrega: number = 0;

  constructor(private personaService: PersonaService) {}

  ngOnInit() {
    this.persona = new Persona();
    this.Apoyo = new Apoyo();
    this.ApoyoDisponible();
  }

  ApoyoDisponible() {
    this.personaService.getSumaApoyo().subscribe((s) => {
      this.CantidadEntrega = s;
      this.CantidadDisponible = this.personaService.maxAids - this.CantidadEntrega;
    });
  }

  isRegistered() {
    this.persona.Apoyo = this.Apoyo;

    this.personaService.getPersona(this.persona).subscribe((p) => {
      if (p.identificacion == this.persona.identificacion) {
        alert('persona ya registrada en el sistema');
      } else {
        //if (this.persona.Apoyo.valorApoyo <= this.CantidadDisponible) {
        console.log('Aprovado');
        this.add();
        //} else {
        //alert('supera el monto disponible ' + this.CantidadDisponible);
        //}
      }
    });
  }

  add(): void {
    console.log('En proceso');
    this.personaService.post(this.persona).subscribe((p) => {
      if (p != null) {
        alert('Persona guadada');
        this.persona = p;
      }
    });
  }
}
