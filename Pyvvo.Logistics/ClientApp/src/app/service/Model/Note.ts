import { User } from "./user";

export class Note {
  id: number;
  content: string;
  createdOn: Date;
  updatedOn: Date;
  createdBy: User;
}
