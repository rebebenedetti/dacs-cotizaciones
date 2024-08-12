import { Component, OnInit } from '@angular/core';
import { AlertController } from '@ionic/angular';
import { RangeCustomEvent } from '@ionic/angular';
import { RangeValue } from '@ionic/core';
import { MessagingService } from 'src/app/servicios/messaging.service';
import { MonedaService } from 'src/app/servicios/moneda.service';
import { Storage } from '@ionic/storage-angular';
import { AppStorageKey } from 'src/app/constantes/app-constantes';

@Component({
  selector: 'app-alerta',
  templateUrl: './alerta.page.html',
  styleUrls: ['./alerta.page.scss'],
})
export class AlertaPage implements OnInit {
  opcionSeleccionada: string = '';
  codigoSeleccion: string = '';
  idUsuario: string = '';
  porcentaje: RangeValue = 0;
  notificacionesPermitidas: boolean = false;

  constructor(
    private monedaService: MonedaService,
    private alertController: AlertController,
    private messagingService: MessagingService,
    public storage: Storage,
  ) { }

  async ngOnInit(): Promise<void> {
    this.notificacionesPermitidas = await this.messagingService.requestNotificationPermission();

    if (this.notificacionesPermitidas) {
      await this.messagingService.registrarServiceWorkerYObtenerToken();
    } else {
      this.presentarAlerta('Debe conceder el permiso de notificaciones para configurar una alerta.');
    }
  }

  onIonChange(ev: Event) {
    this.porcentaje = (ev as RangeCustomEvent).detail.value;
    console.log(typeof (this.porcentaje));
  }

  pinFormatter(value: number) {
    return `${Math.round(100 * value) / 100}%`;
  }

  async presentarAlerta(mensaje: string) {
    const alert = await this.alertController.create({
      message: mensaje,
      buttons: ['OK'],
      backdropDismiss: false,
    });

    await alert.present();
  }

  async configurarAlerta() {
    if (!this.notificacionesPermitidas) {
      this.presentarAlerta('Debe conceder el permiso de notificaciones para configurar una alerta.');
      return;
    }

    if (this.porcentaje != 0 && this.opcionSeleccionada != '') {
      this.codigoSeleccion = this.opcionSeleccionada.substring(0, 3);
      const fcmToken = await this.storage.get(AppStorageKey.FCMToken);
      if (fcmToken != null) {
        this.monedaService.establecerAlerta(this.codigoSeleccion, this.porcentaje, fcmToken);
        this.presentarAlerta('Su alerta fue configurada correctamente.');
      } else {
        this.presentarAlerta('Ocurrió un error con el token. Por favor, intente de nuevo.');
      }
    } else if (this.porcentaje == 0) {
      this.presentarAlerta('Debe seleccionar un porcentaje distinto de cero.');
    } else {
      this.presentarAlerta('Debe seleccionar una moneda y un porcentaje.');
    }
  }
}
