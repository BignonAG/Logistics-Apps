import { Component, OnInit } from '@angular/core';
import { User } from '../../../service/Model/user';
import { UserService } from '../../../service/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {
  users: User[] = [];
  successMessage: string;
  errorMessage: string;
  loading = true;
  message: string;

  constructor(private _userService: UserService) { }

  ngOnInit() {
    this.getUsers();
  }

  getUsers() {
    return this._userService.getUsers().subscribe(
      result => {
        this.users = result;
        this.loading = false;
        if (result.length == 0)
          this.message = "There is no data at this time...";
        //console.log(this.suppliers);
      },
      error => {
        console.log(error);
        this.loading = false;
        this.errorMessage = "An error occured! Please try again...";
      }
    );
  }

  deleteUser(id: number) {
    return this._userService.delete(id).subscribe(
      result => {
        this.getUsers();
        this.successMessage = "User has been succefully deleted! ";
      },
      error => {
        console.log(error);
        this.errorMessage = "Something wrong! Please retry...";
      }
    )
  }

}
