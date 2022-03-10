import { User } from "./user";

export class AccountLogin {
  id: number;
  createdOn: Date;
  updateOn: Date;
  email: string;
  password: string;
  token: string;
  user: User;
}
