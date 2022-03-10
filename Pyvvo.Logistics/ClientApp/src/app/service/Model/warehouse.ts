import { Address } from "./Address";
import { User } from "./user";
import { Contact } from "./contact";
import { Note } from "./Note";

export class Warehouse {
    id: number;
    createdOn: Date;
    createdOnLocalTime: string;
    updatedOn: Date;
    name: string;
    isexternal: boolean;
    isactive: boolean;
    notes: Note[];
    address: Address;
    contact: Contact;
    createdBy: User;
}
