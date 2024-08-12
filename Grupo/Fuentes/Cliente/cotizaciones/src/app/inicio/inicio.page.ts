import { Component, OnInit } from '@angular/core';
import { AlertController } from '@ionic/angular';
import { Geolocation, Position } from '@capacitor/geolocation';
import { LoginService } from '../servicios/login.service';
import { Usuario } from '../interfaces/usuario.interface';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.page.html',
  styleUrls: ['./inicio.page.scss'],
})
export class InicioPage {
  coordenadas!: Position;
  usuario = null;

  constructor(
    private alertController: AlertController,
    public loginService: LoginService
  ) { }

  async ionViewDidEnter() {
    this.loginService.initialize();
    const alert = await this.alertController.create({
      header: 'Importante!',
      message: 'Necesitamos tu ubicación para localizar la divisa de tu país',
      backdropDismiss: false,
      buttons: [
        {
          text: 'Utilizar mi ubicación actual',
          handler: async () => {
            this.coordenadas = await Geolocation.getCurrentPosition();
          },
        },
      ],
    });
    await alert.present();
  }

  iniciarSesion() {
    this.loginService.loginViaGoogle(this.coordenadas);
  }
}
