import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { SearchComponent } from './search/app.search.component';
import { InjectProductos } from './services/app.services';
import { FormsModule } from '@angular/forms';
import * as $ from 'jquery';


@NgModule({
  declarations: [
      AppComponent,
      SearchComponent
      
  ],
  imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule
  ],
    providers: [
    InjectProductos
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
