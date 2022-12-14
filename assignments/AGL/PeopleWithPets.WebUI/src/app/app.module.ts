import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { CatsByOwnersGenderComponent } from './cats-by-owners-gender/cats-by-owners-gender.component';

@NgModule({
  declarations: [
    AppComponent,
    CatsByOwnersGenderComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
