import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../service/auth.service';
import { AccountLogin } from '../../service/Model/account-login';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent implements OnInit {

  token: string;
  authForm: FormGroup;
  successMessage: string;
  errorMessage:string;

  constructor(private _authService: AuthService, private formBuilder: FormBuilder) {
    this.authForm = this.formBuilder.group({
      email: ['', [Validators.required]],
      password: ['', [Validators.required]]
    }
    )
  }

  ngOnInit() {
  }

  signUp(accountLogin: AccountLogin) {
    return this._authService.signUp(accountLogin).subscribe(
      result => {
        localStorage.setItem("token", result.token);
        console.log(result.token), this.successMessage = 'The data was added'
      },
      error => console.log(error),
    )
  }
}
