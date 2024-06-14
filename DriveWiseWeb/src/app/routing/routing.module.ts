import { NgModule } from '@angular/core';
import { LoginComponent } from '../components/login/login.component';
import { RouterModule, Routes } from '@angular/router';
import { HeaderComponent } from '../components/header/header.component';
import { ListCarpoolComponent } from '../components/list-carpool/list-carpool.component';
import { HomeComponent } from '../components/home/home.component';
import { ListRentComponent } from '../components/list-rent/list-rent.component';

const routes: Routes = [
  
  { path: 'login', component: LoginComponent },
  { path: '', component: HomeComponent},
  { path: 'listcarpool', component: ListCarpoolComponent },
  { path: 'listrent', component: ListRentComponent }

];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class RoutingModule { }
