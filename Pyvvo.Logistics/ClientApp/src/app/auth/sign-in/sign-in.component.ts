import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../service/auth.service';
import { AccountLogin } from '../../service/Model/account-login';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit {
  loading: boolean;
  token: string;
  authForm: FormGroup;
  errorMessage: string;
  helper: JwtHelperService;
  successMessage: string;

  constructor(private _authService: AuthService, private formBuilder: FormBuilder, private router: Router) {
    this.authForm = this.formBuilder.group({
      email: ['', [Validators.required]],
      password: ['', [Validators.required]]
    }
    )

  }

  ngOnInit() {
  }

  signIn(accountLogin: AccountLogin) {
    this.loading = true; // enable button loading
    return this._authService.signIn(accountLogin).subscribe(
      result => {
        localStorage.setItem("token", result.token);
        localStorage.setItem("companyId", result.user.company.id.toString());
        this.router.navigateByUrl('/app');
        this.loading = false;
      }, error => {
        if (error.status == 401) {
          this.errorMessage = "Invalid email or password. Please try again!";
        }
        this.errorMessage = "An error occured! Please try again...";
        console.log(error);
        this.loading = false;
        }
     )
  }

}
