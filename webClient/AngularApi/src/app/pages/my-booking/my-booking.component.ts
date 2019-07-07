import { Component, OnInit } from '@angular/core';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Reservation } from 'src/app/shared/models/reservation.model';
import { HttpErrorResponse } from '@angular/common/http';
import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-my-booking',
  templateUrl: './my-booking.component.html',
  styleUrls: ['./my-booking.component.scss']
})
export class MyBookingComponent implements OnInit {

  errorMessage: string = '';
  Reservations: Reservation[];

  /*Setttings Smart Table */
  settings = {
    //delete button
    delete: {
      confirmDelete: true,
      deleteButtonContent: 'Supprimer'
    },
    actions: {
      position: 'right',
      edit: false,
      add: false,
      delete: true
    },
    columns: {
      /*property foreign key */
      User: {
        title: 'Reservation de :',
        type: 'string',
        valuePrepareFunction: (User) => {
          return User.UserName;
        },
        /*filter on foreign key */
        filterFunction(obj?: any, search?: string): boolean {
          if (obj.UserName.toLowerCase().indexOf(search) > -1)
            return true;
          return false;
        },
      },
      StartDate: {
        title: 'Date Début',
        sort: true,
        sortDirection: 'asc',
        valuePrepareFunction: (StartDate) => {
          if (StartDate) {
            return new DatePipe('fr').transform(StartDate, 'dd/MM/yyyy HH:mm');
          }
        }
      },
      EndDate: {
        title: 'Date Fin',
        valuePrepareFunction: (StartDate) => {
          if (StartDate) {
            return new DatePipe('fr').transform(StartDate, 'dd/MM/yyyy HH:mm');
          }
        }
      },
      Room: {
        title: 'Agence',
        valuePrepareFunction: (Room) => {
          console.log('iteration', Room, 'end');
          return Room.Agency.AgencyName;
        },
        filterFunction(obj?: any, search?: string, row?: any): boolean {
          if (obj.Agency.AgencyName.indexOf(search) > -1)
            return true;
          return false;
        },
      },
      'RoomName': {
        title: 'Salle',
        type: 'string',
        valuePrepareFunction: (cell, row) => {
          return row.Room.RoomName;
        },
        // no filter
        filter: false,
      },
    }
  };

  constructor(private repository: RepositoryService,
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit() {
    this.getAllReservations();
  }


  // Get all reservations on init Vue Admin
  public getAllReservations() {
    let apiAddress: string = "api/reservations";
    this.repository.getData(apiAddress).subscribe(res => {
      this.Reservations = res as Reservation[];
      console.log(this.Reservations);
    },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
  }


  // Delete reservation selected
  async deleteRecord(event) {
    let id: string = event.source.id
    let apiUrl: string = `api/reservations/${event.data.ReservationID}`;
    //popup
    if (window.confirm('Etes vous sur de vouloir supprimer cette réservation ?')) {
      await this.repository.delete(apiUrl).subscribe(
        res => {
          console.log(res);
          event.confirm.resolve(event.data.ReservationID);
        },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        })
      //event.confirm.resolve(event.source.data);
    } else {
      event.confirm.reject();
    }
  }
}
