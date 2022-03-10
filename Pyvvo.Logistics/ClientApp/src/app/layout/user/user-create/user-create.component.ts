import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { UserService } from '../../../service/user.service';
import { User } from '../../../service/Model/user';
import { Router, ActivatedRoute } from '@angular/router';
import { StatusService } from '../../../service/status.service';
import { Status } from '../../../service/Model/status';

@Component({
  selector: 'app-user-create',
  templateUrl: './user-create.component.html',
  styleUrls: ['./user-create.component.scss']
})
export class UserCreateComponent implements OnInit {
  loading = false;
  cardLoading = false;
  errorMessage: string;
  userId: string;
  updateContactId: number;
  formTitle: string = "Add new user";
  txtBtnSubmit: string = "Save";
  userForm: FormGroup;
  statusCategId = 17;
  selectedStatusId;
  status: Status[] = [];


  constructor(private _fb: FormBuilder, private _userService: UserService,
    private router: Router, private activatedRoute: ActivatedRoute, private _statusService: StatusService) {

    // Create form group that the  html form and construct the json entity
    this.userForm = this._fb.group({
      contact: this._fb.group({
        firstName: ['', [Validators.required]],
        lastName: ['', [Validators.required]],
        email: ['', [Validators.required]],
        phone: ['', [Validators.required]],
        website: [''],
        facebook: [''],
        linkedin: [''],
        viadeo: [''],
      }),
      status: this._fb.group({
        id: ['', [Validators.required]]
      })
    });
    this.userId = this.activatedRoute.snapshot.params["id"];// Get the user id param from url 
  }

  ngOnInit() {
    if (this.userId != null && this.userId != "") {
      this.formTitle = "Update user informations";
      this.txtBtnSubmit = "Update";
      this.cardLoading = true;
      this.getUserForUpdate();//Get user information to update and pre-fullfil the form
    }
    this.getStatus();
  }

  upsertUser(user: User) {
    if (this.userForm.valid) {
      this.loading = true;
      if (this.userId != null && this.userId != "") {
        var id: number = +this.userId;
        user.id = id;
        if (this.updateContactId != 0) user.contact.id = this.updateContactId;
        return this._userService.update(user).subscribe(
          result => {
            this.router.navigateByUrl("/users")
          },
          error => {
            console.log(error);
            this.errorMessage = "Something wrong! Please check your informations and retry...";
            this.loading = false;
          }
        );
      } else {
        return this._userService.create(user).subscribe(
          result => {
            this.router.navigateByUrl("/users")
          },
          error => {
            console.log(error);
            this.errorMessage = "Something wrong! Please check your informations and retry...";
            this.loading = false;
          }
        );
      }
    }
  }

  getUserForUpdate() {
    return this._userService.get(this.userId).subscribe(
      result => {
        console.log(result);
        this.updateContactId = result.contact.id;
        this.selectedStatusId = result.status.id;
        this.userForm.patchValue(result);
        this.cardLoading = false;
      },
      error => {
        console.log(error);
        this.cardLoading = false;
      }
    );
  }

  getStatus() {
    return this._statusService.getStatus(this.statusCategId).subscribe(
      result => {
        this.status = result;
      },
      error => {
        console.log(error);
      }
    )
  }

}
