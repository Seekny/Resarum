import { Component, OnInit, Input } from '@angular/core';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Room } from 'src/app/shared/models/room.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { EquipmentRooms } from 'src/app/shared/models/equipmentRooms.model';
import { OwlDateTimeIntl, DateTimeAdapter } from 'ng-pick-datetime';
import { DatePipe } from '@angular/common';
import dayGridPlugin from '@fullcalendar/daygrid';
import frLocale from '@fullcalendar/core/locales/es';
import listPlugin from '@fullcalendar/list';
import { Calendar } from '@fullcalendar/core';
import { Reservation } from 'src/app/shared/models/reservation.model';
import timeGridPlugin from '@fullcalendar/timegrid'
import Tooltip from 'tooltip.js'




// Rename button datepicker  picker
export class DefaultIntl extends OwlDateTimeIntl {

  /** A label for the cancel button */
  cancelBtnLabel = 'Annuler';

  /** A label for the set button */
  setBtnLabel = 'Appliquer';
};

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.scss'],
  providers: [DatePipe]
})
export class BookingComponent implements OnInit {

  @Input() selection: any;
  @Input() Note: string;

  public min = new Date(Date.now());
  public OneRoom: Room;
  public StartDate: Date;
  public EndDate: Date;
  Room: Room[];

  errorMessage: string = '';
  Reservations: Reservation[];

  ListEquipments: EquipmentRooms[];

  reservationForm: FormGroup;
  submitted = false;


  constructor(private datePipe: DatePipe, dateTimeAdapter: DateTimeAdapter<any>, private formBuilder: FormBuilder, private repository: RepositoryService, private activeRoute: ActivatedRoute, private router: Router, private errorHandler: ErrorHandlerService) {
    dateTimeAdapter.setLocale('fr-FR');
    
  }

  ngOnInit() {
  }

  //On clic 'consulter' change the child component with the agency's selection datas
  ngOnChanges(changes: any) {


    this.getAllReservations();

    this.getRoomByID();
    this.getEquipmentByRoomID();
    // Form Annotations
    this.reservationForm = this.formBuilder.group({
      StartDate: [Validators.required],
      EndDate: [Validators.required],
      Note: [''],
      // RECUPERER L'ID USER QUAND SERVER LDAP INSTALLE ! 
      UserID: 1,
      //
      RoomID: this.selection
    })
  }

  // Get Room by Selection from parent component
  getRoomByID() {
    let apiUrl: string = `api/rooms/${this.selection}`;
    this.repository.getData(apiUrl)
      .subscribe(res => {
        this.OneRoom = res as Room;
        console.log(this.OneRoom);
      }, (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      });
  }

  // Get equipments from room ID
  getEquipmentByRoomID() {
    let apiUrl: string = `api/EquipmentRooms/${this.selection}`;
    console.log(apiUrl);
    this.repository.getData(apiUrl)
      .subscribe(res => {
        this.ListEquipments = res as EquipmentRooms[];
        console.log(this.ListEquipments);
      }, (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;

      });
  }

  // create reservation & go back to agencies
  async createReservation(event) {

    // Transform datetime in french datetime
    const FormValues = this.reservationForm.value;
    FormValues.StartDate = this.datePipe.transform(FormValues.StartDate, 'yyyy-MM-dd HH:mm');
    FormValues.EndDate = this.datePipe.transform(FormValues.EndDate, 'yyyy-MM-dd HH:mm');

    let apiUrl: string = `api/Reservations`;
    if (this.reservationForm.valid) {
      //popup
      if (window.confirm('Etes vous sur de vouloir confirmer cette réservation ?')) {
        this.repository.create(apiUrl, FormValues).subscribe((data) => {
          this.router.navigate(['/agencies']);
        }, (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        });
      }
    } else {
      event.confirm.reject();
    }
  }

  // Create form onClick Button
  onSubmit() {
    if (!this.reservationForm.valid) {
      console.log("error");
    } else {
      this.createReservation(event);
      this.submitted = true;
    }
  }


  // Get All Reservations to send them into full calendar lib
  public getAllReservations() {

    let apiUrl: string = `api/Reservations/Room=${this.selection}`;
    this.repository.getData(apiUrl).subscribe(res => {
      this.Reservations = res as Reservation[];

      //full calendar intit
      var calendarEl = document.getElementById('calendar');
      var calendar = new Calendar(calendarEl, {
        plugins: [listPlugin, dayGridPlugin, timeGridPlugin],  // List plugins we can use 
        header: {
          right: 'dayGridMonth,listMonth'
        },
        // defaultView: $(window).width() < 765 ? 'listMonth':'dayGridMonth',
        footer: {
          left: 'prev,next',
          right: 'today'
        },
        buttonText: {
          today: 'Aujourd\'hui',
          month: 'Mois',
          list: 'Liste',
          week: 'Semaine',
        },
        navLinks: true,
        eventLimit: 3, // allow "more" link when too many events
        locales: [frLocale],
        locale: 'fr', // the initial locale. of not specified, uses the first one
        hiddenDays: [6, 7],
        eventColor: 'aquamarine',
        eventTextColor: 'Black',
        events: this.Reservations.map(function (x) { // Map reservation in FullCalendar
          return {
            title: x.Note,
            start: x.StartDate,
            end: x.EndDate
          };
        }),
      });
     
      calendar.setOption('locale', 'fr'); // Langage in French
      calendar.render();
    },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
  }


  
}





