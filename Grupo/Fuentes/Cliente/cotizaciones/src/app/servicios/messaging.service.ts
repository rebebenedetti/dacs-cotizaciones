import { Injectable } from "@angular/core";
import { Messaging, getToken, onMessage, deleteToken } from "@angular/fire/messaging";
import { Observable, tap } from "rxjs";
import { LocalStorageService } from "./local-storage.service";
import { AppStorageKey } from "../constantes/app-constantes";

@Injectable({
    providedIn: "root",
})
export class MessagingService {
    private fcmToken: string | null = null;

    constructor(
        private msg: Messaging,
        private localStorageService: LocalStorageService
    ) { }

    async requestNotificationPermission(): Promise<boolean> {
        const permission = await Notification.requestPermission();
        return permission === "granted";
    }

    async registrarServiceWorkerYObtenerToken(): Promise<void> {
        try {
            const serviceWorkerRegistration = await navigator.serviceWorker.register("/assets/firebase-messaging-sw.js", { type: "module" });
            this.fcmToken = await getToken(this.msg, { serviceWorkerRegistration });

            if (this.fcmToken) {
                await this.localStorageService.set(AppStorageKey.FCMToken, this.fcmToken);
                console.log('FCM Token:', this.fcmToken);
            } else {
                console.error('No se pudo obtener el token FCM.');
            }
        } catch (error) {
            console.error('Error al registrar el Service Worker o al obtener el token FCM:', error);
        }
    }

    message$ = new Observable((sub) => onMessage(this.msg, (msg) =>
        sub.next(msg))).pipe(
            tap((msg) => {
                console.log("Mensaje de Firebase Cloud Messaging", msg);
            })
        );

    async deleteToken(): Promise<void> {
        await deleteToken(this.msg);
        await this.localStorageService.remove(AppStorageKey.FCMToken);
    }

    async getStoredFCMToken(): Promise<string | null> {
        return this.localStorageService.get(AppStorageKey.FCMToken);
    }
}
