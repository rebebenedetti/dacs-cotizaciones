import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';
import { FormsModule } from '@angular/forms';
import { BuscarMonedasComponent } from './buscar-monedas/buscar-monedas.component';


@NgModule({
  declarations: [
    BuscarMonedasComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
  ],
  exports: [
    BuscarMonedasComponent
  ]
})
export class ComponentesModule { }
