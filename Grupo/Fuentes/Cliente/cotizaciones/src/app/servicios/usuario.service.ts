import { Injectable } from '@angular/core';
import { AppEvent, AppStorageKey } from '../constantes/app-constantes';
import { Usuario } from '../interfaces/usuario.interface';
import { Storage } from '@ionic/storage-angular';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})

export class UsuarioService {
    private apiUrl = 'https://localhost:7054/api/Usuario';

    constructor(public storage: Storage, private http: HttpClient,
    ) { }

    async login(usuario: Usuario): Promise<void> {
        console.log("USUARIO A REGISTRAR", usuario);
        await this.storage['set'](AppStorageKey.CurrentUser, usuario);
        this.http.post(this.apiUrl, usuario).subscribe({
            next: (response) => {
                console.log('Success:', response);
                window.dispatchEvent(new CustomEvent(AppEvent.Login, { detail: usuario }));
            },
            error: (error) => {
                console.error("Error login:", error);
            }
        });
    }

    async logout(): Promise<any> {
        await this.storage['remove'](AppStorageKey.CurrentUser);
        window.dispatchEvent(new CustomEvent(AppEvent.Logout));
    }

    async obtenerUsuario(): Promise<Usuario | undefined> {
        const user = await this.storage['get'](AppStorageKey.CurrentUser);
        if (!user) { return undefined; }
        return {
            nombre: user.nombre,
            email: user.email,
            latitud: user.latitud,
            longitud: user.longitud,
            token: user.token
        };
    }

    async isLoggedIn(): Promise<boolean> {
        return await this.obtenerUsuario() != undefined;
    }

}