import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PageNotFoundComponent } from './pages/error-pages/page-not-found/page-not-found.component';
import { AgenciesComponent } from './pages/agencies/agencies.component';
import { RoomPlanComponent } from './pages/room-plan/room-plan.component';
import { InternalServerComponent } from './pages/error-pages/internal-server/internal-server.component';
import { MyBookingComponent } from './pages/my-booking/my-booking.component';
import { AuthenticationGuard } from 'microsoft-adal-angular6';

/* All routes that we can access */
const routes: Routes = [
  { path: '', redirectTo: '/agencies', pathMatch: 'full', canActivate: [AuthenticationGuard]},
  /*disable commentaires pour activer le guard d'authentification */
  { path: 'agencies', /*canActivate: [AuthentificationGuard],*/ component: AgenciesComponent, canActivate: [AuthenticationGuard] },  
  { path: 'agencies/:id', /*canActivate: [AuthentificationGuard],*/  component: RoomPlanComponent, canActivate: [AuthenticationGuard] },   
  { path: 'my-booking', component: MyBookingComponent, canActivate: [AuthenticationGuard]},
  { path: 'not-found', component: PageNotFoundComponent },
  { path: '500', component: InternalServerComponent, canActivate: [AuthenticationGuard] },  
  { path: '', component: AgenciesComponent, canActivate: [AuthenticationGuard] },
  { path: '**', redirectTo: 'not-found', canActivate: [AuthenticationGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)], 
  exports: [RouterModule],
})
export class AppRoutingModule { }
