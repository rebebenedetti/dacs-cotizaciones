import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Moneda } from 'src/app/interfaces/moneda.interface';
import { MonedaService } from 'src/app/servicios/moneda.service';

@Component({
  selector: 'app-buscar-monedas',
  templateUrl: './buscar-monedas.component.html',
  styleUrls: ['./buscar-monedas.component.scss'],
})
export class BuscarMonedasComponent implements OnInit {
  estaAbierta = false;
  opcionSeleccionada: string = "";
  monedaBuscada: any;
  cargando = true;

  @Output() cambioOpcionSeleccionada = new EventEmitter<string>();

  @Input() monedas: Moneda[] = []

  constructor(private monedaService: MonedaService) { }

  ngOnInit() {
    this.monedaService.obtenerMonedas().subscribe({
      next: (res) => {
        this.monedas = res;
        this.monedaBuscada = [...this.monedas];
        this.cargando = false;
      },
      error: (err) => {
        this.cargando = false;
        console.error(err);
      }
    });
  }

  abrir() {
    this.estaAbierta = true;
  }

  aceptar() {
    this.estaAbierta = false;
  }

  buscarMonedas(evento: any) {
    const texto = evento.target.value.toLowerCase();
    this.monedaBuscada = this.monedas.filter(d => d.nombre.toLowerCase().indexOf(texto) > -1
      || d.codigo.toLowerCase().indexOf(texto) > -1);
  }

  monedaSeleccionada(evento: any) {
    this.opcionSeleccionada = evento.detail.value;
    this.cambioOpcionSeleccionada.emit(this.opcionSeleccionada);
  }
}
