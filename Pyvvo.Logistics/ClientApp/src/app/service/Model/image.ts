import { User } from "./user";

export class Image {
  id: number;
  createdOn: Date;
  updatedOn: Date;
  isActive: boolean;
  pathUrl: string;
  name: string;
  filename: string;
  extension: string;
  createdBy: User;
}
