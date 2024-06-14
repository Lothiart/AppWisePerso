import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { LoginComponent } from './components/login/login.component';
import { RoutingModule } from './routing/routing.module';
import { HomeComponent } from './components/home/home.component';
import { CarpoolComponent } from './components/carpool/carpool.component';
import { ListCarpoolComponent } from './components/list-carpool/list-carpool.component';
import { ListRentComponent } from './components/list-rent/list-rent.component';
import { RentComponent } from './components/rent/rent.component';
import { CreatecarpoolComponent } from './components/createcarpool/createcarpool.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    LoginComponent,
    HomeComponent,
    CarpoolComponent,
    ListCarpoolComponent,
    ListRentComponent,
    ListRentComponent,
    RentComponent,
    CreatecarpoolComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
