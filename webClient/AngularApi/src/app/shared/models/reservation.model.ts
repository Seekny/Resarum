import { User } from './user.model';
import { Room } from './room.model';

export class Reservation {    
    
    ReservationID :number;
    StartDate : Date;    
    EndDate: Date;
    Note: string;

    user?: User[];
    room?: Room[];
}

