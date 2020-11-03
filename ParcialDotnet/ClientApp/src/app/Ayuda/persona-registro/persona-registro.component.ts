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
    this.persona.apoyo = this.Apoyo;
    this.ApoyoDisponible();
  }

  ApoyoDisponible() {
    this.personaService.getSumaApoyo().subscribe((s) => {
      this.CantidadEntrega = s;
      this.CantidadDisponible = this.personaService.maxAids - this.CantidadEntrega;
    });
  }

  isRegistered() {
    this.ApoyoDisponible();
    this.persona.apoyo = this.Apoyo;
    if (this.persona.apoyo.valorApoyo <= this.CantidadDisponible) {
      console.log('Aprovado');
      this.add();
    } else {
      alert('supera el monto disponible ' + this.CantidadDisponible);
    }
  }

  add(): void {
    console.log('En proceso');
    this.persona.apoyo.valorApoyo = +this.persona.apoyo.valorApoyo;
    this.personaService.post(this.persona).subscribe((p) => {
      if (p != null) {
        alert('Persona guadada');
        console.log(p);
      }
    });
  }
}
