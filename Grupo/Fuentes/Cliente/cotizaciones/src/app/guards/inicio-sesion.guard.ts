import { Injectable } from '@angular/core';
import {
    ActivatedRouteSnapshot,
    CanActivate,
    RouterStateSnapshot,
    UrlTree,
} from '@angular/router';
import { NavController } from '@ionic/angular';
import { Observable } from 'rxjs';
import { UsuarioService } from '../servicios/usuario.service';

@Injectable({
    providedIn: 'root',
})
export class InicioSesionGuard implements CanActivate {

    constructor(public navCtrl: NavController, private usuarioService: UsuarioService) { }

    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ):
        | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
        return this.usuarioService.isLoggedIn().then(result => {
            if (result) {
                return true; //Si inició sesión el usuario puede acceder a las paginas
            } else {
                this.navCtrl.navigateRoot('inicio');
                return false; //Si no vuelve a inicio para que se registre
            }
        });
    }
}
