import { Injectable } from "@angular/core";
import { AppStorageKey } from "../constantes/app-constantes";
import { Storage } from '@ionic/storage-angular';

@Injectable({
    providedIn: 'root'
})
export class LocalStorageService {

    constructor(private storage: Storage) { }

    async set(key: AppStorageKey, value: any) {
        await this.storage["set"](key, value);
    }

    get(key: AppStorageKey) {
        return this.storage["get"](key);
    }

    async remove(key: AppStorageKey) {
        await this.storage.remove(key);
    }

    async clear(keys: Array<string>) {
        if (!keys) { return; }
        if (keys.length === 1 && keys[0] === '*') { keys = Object.values(AppStorageKey); }
        keys = keys.filter(x => x != AppStorageKey.CurrentUser);
        keys.forEach(async key => {
            await this.storage["remove"](key);
        });
    }
}