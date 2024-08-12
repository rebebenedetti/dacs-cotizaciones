import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { GoogleAuth } from "@codetrix-studio/capacitor-google-auth";
import { Platform } from "@ionic/angular";
import { initializeApp } from "firebase/app";
import { GoogleAuthProvider, User, getAuth, onAuthStateChanged, signInWithCredential } from "firebase/auth";
import { environment } from "src/environments/environment";
import { UsuarioService } from "./usuario.service";
import { LocalStorageService } from "./local-storage.service";
import { AppStorageKey } from "../constantes/app-constantes";
import { Position } from "@capacitor/geolocation";

@Injectable({
    providedIn: 'root'
})
export class LoginService {
    isWeb = false;
    firebase: any;
    constructor(
        private usuarioService: UsuarioService,
        private localStorageService: LocalStorageService,
        private platform: Platform,
        private router: Router) {
        this.isWeb = !(this.platform.is('android') || this.platform.is('ios'));
        this.firebase = initializeApp(environment.firebase);
    }

    public async refreshToken() {
        const auth = getAuth(this.firebase);
        onAuthStateChanged(auth, async (currenUser: User | null) => {
            if (currenUser) {
                const idToken = await currenUser.getIdToken(true);
                console.log(idToken);
                await this.localStorageService.set(AppStorageKey.AccessToken, idToken);
            } else {
                await this.logout();
            }
        });
    }

    async logout() {
        await getAuth(this.firebase).signOut();
        await GoogleAuth.signOut().then(() => console.log('Signed Out')).catch(() => { console.log('Signed Out') });
        this.usuarioService.logout().then(async () => {
            this.router.navigateByUrl('/inicio');
        });
    }

    initialize() {
        if (this.isWeb) {
            GoogleAuth.initialize({ grantOfflineAccess: true });
        }
    }

    async loginViaGoogle(coordenadas: Position) {
        try {
            const usuario = await GoogleAuth.signIn();
            if (usuario) {
                const s = await signInWithCredential(getAuth(this.firebase), GoogleAuthProvider.credential(usuario.authentication.idToken));
                const access_token = await s.user.getIdToken();
                await this.localStorageService.set(AppStorageKey.AccessToken, access_token);

                this.usuarioService.login({
                    nombre: usuario.givenName,
                    email: usuario.email,
                    latitud: coordenadas.coords.latitude.toString(),
                    longitud: coordenadas.coords.longitude.toString(),
                }).then(() => {
                    this.router.navigateByUrl('/paginas');
                }).catch((error) => {
                    console.error("Error al iniciar sesión:", error);
                });
            }
        } catch (error) {
            console.log(error);
        }
    }
}