import { Component, Input, OnInit } from '@angular/core';
import { MonedaService } from 'src/app/servicios/moneda.service';
import { AlertController } from '@ionic/angular';
import { Cotizacion } from 'src/app/interfaces/cotizacion.interface';
import { finalize } from 'rxjs';

@Component({
  selector: 'app-historico',
  templateUrl: './historico.page.html',
  styleUrls: ['./historico.page.scss'],
})
export class HistoricoPage implements OnInit {
  fechaActual!: Date;
  fechaMinima!: string;
  fechaDesde: string = '';
  fechaHasta: string = '';
  opcionSeleccionada: string = '';
  codigoSeleccion: string = '';
  idUsuario: string = '';
  mostrar = false;
  cargando = false;

  @Input()
  cotizaciones!: Cotizacion[];
  monedaSeleccionada!: string;
  monedaUsuario!: string;

  constructor(
    private monedaService: MonedaService,
    private alertController: AlertController
  ) { }

  ngOnInit() {
    this.fechaActual = new Date();
    this.fechaMinima = this.fechaActual.toISOString().substring(0, 10);
  }

  determinarFechaDesde(e: any) {
    this.fechaDesde = e.detail.value;
    this.calcularFechaMinima(this.fechaDesde);
  }

  calcularFechaMinima(desde: string) {
    let aux: Date;
    Date.parse(desde);
    aux = new Date(desde);
    aux.setDate(aux.getDate() + 1);
    this.fechaMinima = aux.toISOString().substring(0, 10);
  }

  determinarFechaHasta(e: any) {
    this.fechaHasta = e.detail.value;
  }

  async presentarAlerta(mensaje: string) {
    const alert = await this.alertController.create({
      message: mensaje,
      buttons: ['OK'],
      backdropDismiss: false,
    });

    await alert.present();
  }

  enviarSeleccion() {
    if (
      this.fechaDesde != '' &&
      this.fechaHasta != '' &&
      this.opcionSeleccionada != ''
    ) {
      if (this.fechaDesde < this.fechaHasta) {
        this.codigoSeleccion = this.opcionSeleccionada.substring(0, 3);
        this.monedaService
          .obtenerHistorico(
            this.codigoSeleccion,
            this.fechaDesde.substring(0, 10),
            this.fechaHasta.substring(0, 10)
          )
          .pipe(
            finalize(() => this.cargando = false)
          )
          .subscribe({
            next: (res) => {
              this.cotizaciones = res;
              this.monedaSeleccionada = this.cotizaciones[0].nombreMonedaSeleccionada;
              this.monedaUsuario = this.cotizaciones[0].nombreMonedaUsuario;
              this.mostrar = true;
            },
            error: (error) => {
              console.error('Error al obtener histórico:', error);
              this.presentarAlerta('Hubo un error al obtener los datos');
            }
          });
      } else {
        this.presentarAlerta('Debe seleccionar una moneda y un rango de fechas');
      }
    }
  }
}
