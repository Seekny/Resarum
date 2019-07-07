import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AgenciesComponent } from './pages/agencies/agencies.component';
import { RoomPlanComponent } from './pages/room-plan/room-plan.component';
import { PageNotFoundComponent } from './pages/error-pages/page-not-found/page-not-found.component';
import { HttpClientModule } from '@angular/common/http';
import { EnvironmentUrlService } from './shared/services/environment-url.service';
import { RepositoryService } from './shared/services/repository.service';
import { BookingComponent, DefaultIntl } from './pages/room-plan/booking/booking.component';
import { InternalServerComponent } from './pages/error-pages/internal-server/internal-server.component';
import { ErrorHandlerService } from './shared/services/error-handler.service';
import { OwlDateTimeModule, OwlNativeDateTimeModule, OwlDateTimeIntl } from 'ng-pick-datetime';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { OWL_DATE_TIME_LOCALE } from 'ng-pick-datetime';
import { MyBookingComponent } from './pages/my-booking/my-booking.component';
import { registerLocaleData } from '@angular/common';
import localeFr from '@angular/common/locales/fr';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {FullCalendarModule} from 'primeng/fullcalendar';
import { MsAdalAngular6Module, AuthenticationGuard } from 'microsoft-adal-angular6';


registerLocaleData(localeFr, 'fr');


@NgModule({
  declarations: [
    AppComponent,
    AgenciesComponent,
    RoomPlanComponent,
    PageNotFoundComponent,
    BookingComponent,
    InternalServerComponent,
    MyBookingComponent
  ],
  imports: [
    MsAdalAngular6Module.forRoot({
      tenant: 'daa1a0c9-806b-4c60-a29a-517ad1eef417',
        clientId: '601686e0-32a6-4a72-a96c-eeb0a181a711',
      redirectUri: window.location.origin,
      endpoints: { 
        "https://localhost:44323/": "1c4a0ce4-03be-486a-aa35-c0d1fc66139c",
        },
      navigateToLoginRequestUrl: false,
      cacheLocation: 'localStorage', 
      }),
    BrowserModule,
    AppRoutingModule,    
    FormsModule,
    HttpClientModule,
    OwlDateTimeModule,
    OwlNativeDateTimeModule,
    BrowserAnimationsModule,
    Ng2SmartTableModule, 
    ReactiveFormsModule,    
    FullCalendarModule
  ],
  /* Injected services */ 
  providers: [
     RepositoryService, 
     EnvironmentUrlService,
     ErrorHandlerService,     
     AuthenticationGuard,
     
    FormsModule,
     {provide: OWL_DATE_TIME_LOCALE, useValue: 'fr'},     
    { provide: LOCALE_ID, useValue: 'fr' },
    {provide: OwlDateTimeIntl, useClass: DefaultIntl} 
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
