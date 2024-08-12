import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { map, switchMap } from 'rxjs/operators';
import { Moneda } from '../interfaces/moneda.interface';
import { Cotizacion } from '../interfaces/cotizacion.interface';
import { from, Observable } from 'rxjs';
import { UsuarioService } from './usuario.service';


@Injectable({
  providedIn: 'root'
})
export class MonedaService {

  constructor(private http: HttpClient, private usuarioService: UsuarioService) { }

  obtenerMonedas(): Observable<Moneda[]> {
    return this.http.get<any>("https://localhost:7054/api/Moneda")
      .pipe(
        map((respuesta: any) => {
          if (respuesta && respuesta.$values) {
            return respuesta.$values.map((moneda: { codigo: any; nombre: any; }) => ({
              codigo: moneda.codigo,
              nombre: moneda.nombre
            }));
          } else {
            return [];
          }
        })
      );
  }


  obtenerCotizacionActual(codigoSeleccion: string, emailUsuario: string): Observable<Cotizacion> {
    return from(this.usuarioService.obtenerUsuario()).pipe(
      switchMap(usuario => {
        const emailUsuario = usuario?.email;
        const url = `https://localhost:7054/api/Cotizacion?emailUsuario=${emailUsuario}&codigoMoneda=${codigoSeleccion}`;
        return this.http.get<any>(url).pipe(
          map(cotizacion => ({
            nombreMonedaSeleccionada: cotizacion.moneda,
            nombreMonedaUsuario: cotizacion.monedaBase,
            cotizacion: cotizacion.valor,
            fecha: cotizacion.fechaHora
          }))
        );
      })
    );
  }

  obtenerHistorico(codigoSeleccion: string, fechaDesde: string, fechaHasta: string): Observable<Cotizacion[]> {
    return from(this.usuarioService.obtenerUsuario()).pipe(
      switchMap(usuario => {
        const emailUsuario = usuario?.email;
        const url = `https://localhost:7054/api/Cotizacion/cotizaciones?emailUsuario=${emailUsuario}&codigoMoneda=${codigoSeleccion}&fechaInicio=${fechaDesde}&fechaFin=${fechaHasta}`;
        return this.http.get<any>(url).pipe(
          map(respuesta => {
            if (respuesta && respuesta.$values) {
              return respuesta.$values.map((cotizacion: any) => ({
                nombreMonedaSeleccionada: cotizacion.moneda,
                nombreMonedaUsuario: cotizacion.monedaBase,
                cotizacion: cotizacion.valor,
                fecha: cotizacion.fechaHora,
              }));
            } else {
              return [];
            }
          })
        );
      })
    );
  }

  establecerAlerta(codigoMoneda: string, porcentaje: any, tokenFCM: string | null) {
    const porcentajeNumerico = Number(porcentaje);
    console.log(porcentajeNumerico, tokenFCM);
    this.usuarioService.obtenerUsuario().then(usuario => {
      if (usuario) {
        const alertaDTO = {
          Token: tokenFCM,
          Porcentaje: porcentaje,
          EmailUsuario: usuario.email,
          CodigoMoneda: codigoMoneda
        };

        this.http.post('https://localhost:7054/api/Alerta', alertaDTO)
          .subscribe({
            next: (response) => {
              console.log('Alerta configurada:', response);
            },
            error: (error) => {
              console.error('Error al configurar la alerta:', error);
            },
            complete: () => {
              console.log('Configuración de alerta completada.');
            }
          });
      }
    }).catch(error => {
      console.error('Error al obtener el usuario:', error);
    });
  }
}
