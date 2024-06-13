import { NgModule } from '@angular/core';
import { LoginComponent } from '../login/login.component';
import { RouterModule, Routes } from '@angular/router';
import { HeaderComponent } from '../header/header.component';
import { TemplateComponent } from '../template/template.component';

const routes: Routes = [
  { path: '', component: TemplateComponent },
  { path: 'login', component: LoginComponent },
  { path: 'template', component: TemplateComponent }

];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class RoutingModule { }
