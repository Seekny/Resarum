import { Equipment } from './equipment.model';
import { Room } from './room.model';

export class EquipmentRooms {

    EquipmentID : number;
    RoomID : string;
    

    equipment?: Equipment[];
    room?: Room[];
}
