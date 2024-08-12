import { Component, Input, OnInit } from '@angular/core';
import { MonedaService } from 'src/app/servicios/moneda.service';
import { AlertController } from '@ionic/angular';
import { Cotizacion } from 'src/app/interfaces/cotizacion.interface';

@Component({
  selector: 'app-consultar',
  templateUrl: './consultar.page.html',
  styleUrls: ['./consultar.page.scss'],
})
export class ConsultarPage {
  opcionSeleccionada: string = '';
  codigoSeleccion: string = '';
  idUsuario: string = '';
  mostrar = false;
  cargando = false;

  @Input()
  cotizacionActual!: Cotizacion;

  constructor(
    private monedaService: MonedaService,
    private alertController: AlertController
  ) { }

  async presentarAlerta() {
    const alert = await this.alertController.create({
      header: 'Importante',
      message: 'Debes seleccionar una moneda!',
      buttons: ['OK'],
      backdropDismiss: false,
    });
    await alert.present();
  }

  enviarSeleccion() {
    if (this.opcionSeleccionada != '') {
      this.codigoSeleccion = this.opcionSeleccionada.substring(0, 3);
      this.cargando = true;
      this.monedaService.obtenerCotizacionActual(this.codigoSeleccion, "1").subscribe({
        next: (res: Cotizacion) => {
          this.cotizacionActual = res;
          this.cargando = false;
          this.mostrar = true;
        },
        error: (error: any) => {
          this.cargando = false;
          console.error('Error al obtener cotización:', error);
        }
      });
    } else {
      this.presentarAlerta();
    }
  }
}
