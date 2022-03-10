import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
import { CurrencyService } from '../../service/currency.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  helper: JwtHelperService;

  constructor(private router: Router, private _currencyService: CurrencyService) {
    this.helper = new JwtHelperService();
    var token = localStorage.getItem("token");
    if (token == null || (token != null && this.helper.isTokenExpired(token))) {
      localStorage.removeItem("token");
      this.router.navigateByUrl('/auth/sign-in');
    }
  }

  ngOnInit() {
  }

  getCurrency() {
    return null;
  }
}
