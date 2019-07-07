import { Component, OnInit } from '@angular/core';
import { Agency } from '../../shared/models/agency.model';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';

@Component({
  selector: 'app-agencies',
  templateUrl: './agencies.component.html',
  styleUrls: ['./agencies.component.scss']
})

export class AgenciesComponent implements OnInit {

  Agencies: Agency[];
  public errorMessage: string = '';

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService) {
  }

  ngOnInit() {
    this.getAllOwners();
  }


  // Get all Agencies to display in view 
  public getAllOwners() {
    let apiAddress: string = "api/agencies";
    this.repository.getData(apiAddress)
      .subscribe(res => {
        this.Agencies = res as Agency[];
      },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        })
  }

}

