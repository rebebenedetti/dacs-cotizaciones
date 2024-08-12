import { Component, inject, OnInit } from '@angular/core';
import { AlertController, Platform } from '@ionic/angular';
import { LoginService } from './servicios/login.service';
import { UsuarioService } from './servicios/usuario.service';
import { Usuario } from './interfaces/usuario.interface';
import { AppEvent } from './constantes/app-constantes';
import { Storage } from '@ionic/storage-angular';
import { Messaging } from '@angular/fire/messaging';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
})
export class AppComponent implements OnInit {
  usuario: Usuario | undefined;
  loggedIn = false;
  private messaging = inject(Messaging);

  public appPages = [
    { title: 'Consultar divisa', url: '/consultar', icon: 'cash' },
    { title: 'Consultar histórico', url: '/historico', icon: 'analytics' },
    { title: 'Configurar alerta', url: '/alerta', icon: 'settings' },
  ];

  constructor(
    private platform: Platform,
    private loginService: LoginService,
    private storage: Storage,
    private usuarioService: UsuarioService,
    private alertController: AlertController,

  ) { this['initializeApp']; }

  async ngOnInit() {
    await this.storage['create']();
    this.checkLoginStatus();
    this.listenForLoginEvents();
    if ('serviceWorker' in navigator) {
      navigator.serviceWorker.register('/assets/firebase-messaging-sw.js', { type: 'module' })
        .then((registration) => {
          console.log('Service Worker registrado correctamente:', registration);
        })
        .catch((error) => {
          console.error('Error al registrar el Service Worker:', error);
        });
    }
  }

  async ayudaContextual(pIcono: string) {
    let titulo!: string, mensaje!: string;
    if (pIcono === 'cash') {
      titulo = 'Consultar divisa';
      mensaje = 'Conozca la cotización actual de la divisa que desee en base a la divisa de su ubicación.';
    } else if (pIcono === 'analytics') {
      titulo = 'Consultar histórico de una divisa';
      mensaje = 'Seleccione una divisa para conocer la variación de su cotización en un rango de fechas deseado en base a la divisa de su ubicación.';
    } else if (pIcono === 'settings') {
      titulo = 'Configurar alerta';
      mensaje = 'Seleccione una divisa para recibir una alerta cuando la cotización de esta tenga un porcentaje de variación determinado.';
    }
    const alert = await this.alertController.create({
      header: titulo,
      message: mensaje,
      backdropDismiss: false,
      buttons: ['Ok']
    });
    await alert.present();
  }

  initializeApp() {
    this.platform.ready().then(() => {
      this.loginService.refreshToken();
    });
  }

  async checkLoginStatus() {
    const loggedIn = await this.usuarioService.isLoggedIn();
    let user = await this.usuarioService.obtenerUsuario();
    return await this.updateLoggedInStatus(loggedIn, user);
  }

  updateLoggedInStatus(loggedIn: boolean, user: Usuario | undefined) {
    setTimeout(() => {
      this.usuario = user;
      this.loggedIn = loggedIn;
    }, 300);
  }

  listenForLoginEvents() {
    window.addEventListener(AppEvent.Login, (event: any) => {
      this.updateLoggedInStatus(true, event.detail);
    });

    window.addEventListener(AppEvent.Logout, () => {
      this.updateLoggedInStatus(false, undefined);
    });
  }

  async logout() {
    await this.loginService.logout();
  }

}
