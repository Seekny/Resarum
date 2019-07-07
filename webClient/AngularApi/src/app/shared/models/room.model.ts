import { Agency } from './agency.model';

export class Room {  
    RoomID :number;
    Floor :number;
    Description :string;
    Places :number;
    RoomName : string;
    RoomImage: string;

    agency?: Agency[];
    
}