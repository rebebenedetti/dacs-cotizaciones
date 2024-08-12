import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { NavController } from '@ionic/angular';
import { Observable } from 'rxjs';
import { UsuarioService } from '../servicios/usuario.service';

@Injectable({
    providedIn: 'root'
})
export class NoInicioSesionGuard implements CanActivate {

    constructor(public navCtrl: NavController, private usuarioService: UsuarioService) { }

    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
        return this.usuarioService.isLoggedIn().then(result => {
            if (result) {
                this.navCtrl.navigateRoot('paginas');
                return false;  //Si inició sesion, no puede acceder a inicio, lo redirige a consultar
            } else {
                return true; //Si no inició sesión si puede estar en inicio
            }
        });
    }
}