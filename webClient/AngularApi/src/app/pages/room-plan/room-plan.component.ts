import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Agency } from '../../shared/models/agency.model';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { Room } from '../../shared/models/room.model';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Content } from '@angular/compiler/src/render3/r3_ast';
declare let mapsindoors: any;

@Component({
  selector: 'app-room-plan',
  templateUrl: './room-plan.component.html',
  styleUrls: ['./room-plan.component.scss']
})
export class RoomPlanComponent implements OnInit {

  @Input() selection: any;
  isOn = false;
  rooms: Room[];
  agency: Agency = new Agency();
  errorMessage: string = '';
  public should_open = false;

  /*
  @ViewChild('map') mapElement: any;
  public Agencies: Array<any>;
  map: google.maps.Map;
  myMapsIndoors: any;
  latlng: any;
  infoBox: any;
  */

  constructor(private repository: RepositoryService, private activeRoute: ActivatedRoute, private router: Router, private errorHandler: ErrorHandlerService) { }

  ngOnInit() {
    // this.GetAllRooms();
    this.getAgencyRooms();
    this.getAgencyName();
  }

  getAgencyRooms() {
    let id: string = this.activeRoute.snapshot.params['id'];
    let apiUrl: string = `api/Rooms/Agency=${id}`;

    this.repository.getData(apiUrl)
      .subscribe(res => {
        this.rooms = res as Room[];
      }, (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      });
  }

  //get agency name 
  getAgencyName() {
    let id: string = this.activeRoute.snapshot.params['id'];
    let apiUrl: string = `api/agencies/${id}`;
    this.repository.getData(apiUrl)
      .subscribe(res => {
        this.agency = res as Agency;
      },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        });
  }


  // Delay 
  async delay(ms: number) {
    await new Promise(resolve => setTimeout(() => resolve(), ms));
  }

  //On clic 'consutler ' go down 
  async scrollDown() {
    this.delay(100).then(any => {
      document.getElementById("testtest").scrollIntoView();
    });
  }

  //arrow back menu
  onBack() {
    this.router.navigate(['agencies']);
  }


  // GetLAtLng from a point
  /*getLatLng(location: { geometry: { type: string; coordinates: any[]; }; properties: { anchor: { coordinates: any[]; }; }; }) {
    let coords: any[];
    if (location.geometry.type === 'Point') {
      coords = location.geometry.coordinates;
    } else {
      coords = location.properties.anchor.coordinates;
    }
    return { lat: coords[1], lng: coords[0] };
  }*/

  /*onClick(location: { geometry: any; properties: any; }) {

   this.infoBox.close();

   /* Convert to Google LatLng */
  /* let latlng = this.getLatLng(location);*/

  /* Set an infowindow */
  /* this.infoBox.setContent(location.properties.name);
  this.infoBox.setPosition(latlng);
  this.infoBox.open(this.map);
  console.log(latlng);
  console.log(location);
  console.log(location.properties.name);
  this.selection = location.properties.name;
  console.log('mymapsindors', this.myMapsIndoors);
  this.getRoomByID();

}*/

  // create div with googlemaps api & mapsindoors api from the ID lat & lng
  /*  const mapProperties = {
      center: { lat: Number(this.agency.Latitude), lng: Number(this.agency.Longitude) },
      zoom: 20,
      mapTypeId: google.maps.MapTypeId.ROADMAP,
    };*/
  /*
          this.map = new google.maps.Map(this.mapElement.nativeElement, mapProperties);
          this.myMapsIndoors = new mapsindoors.MapsIndoors({ map: this.map });
          this.infoBox = new google.maps.InfoWindow();
  
          // Add a floor selector
          var div = document.createElement('div');
          var floorSelector = new mapsindoors.FloorSelector(div, this.myMapsIndoors);
          this.map.controls[google.maps.ControlPosition.RIGHT_TOP].push(div);
  
          /* Will fire when a location or a room polygon is clicked on the map. */
  /*      google.maps.event.addListener(this.myMapsIndoors, 'click', (e) => {
          this.onClick(e);
        });*/

  /* getRoomByID() {
let apiUrl: string = `api/rooms/${this.selection}`;
this.repository.getData(apiUrl)
.subscribe(res => {
  this.rooms = res as Room[];
  console.log("testtest")
}, (error) => {
  this.errorHandler.handleError(error);
  this.errorMessage = this.errorHandler.errorMessage;
});

}*/



}
