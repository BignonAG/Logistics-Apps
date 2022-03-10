import { Status } from "./status";
import { Image } from "./image";

export class Contact {
  id: number;
  createdOn: Date;
  updatedOn: Date;
  isActive: boolean;
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  verifiedEmail: string;
  acceptTermsOfService: boolean;
  language: string;
  timeZone: string;
  facebook: string;
  linkedin: string;
  viadeo: string;
  website: string;
  phone: string;
  status: Status;
  image: Image;
}
