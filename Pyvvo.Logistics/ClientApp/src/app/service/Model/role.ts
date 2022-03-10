import { User } from "./user";

export class Role {
  id: number;
  createdOn: Date;
  updatedOn: Date;
  isActive: boolean;
  name: string;
  description: string;
  createdBy: User;
}
