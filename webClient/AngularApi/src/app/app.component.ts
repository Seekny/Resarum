import { Component, OnInit, AfterViewInit } from '@angular/core';
import { MsAdalAngular6Service } from 'microsoft-adal-angular6';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})


export class AppComponent {

  constructor(private adalSvc: MsAdalAngular6Service) {
    this.adalSvc.acquireToken('<RESOURCE>').subscribe((resToken: string) => {
      console.log(resToken);
    });

  }

  AccountLogout() {
    this.adalSvc.logout();
  }
}
