import { Component, OnInit } from '@angular/core';
import { Customer } from '../../../service/Model/customer';
import { CustomerService } from '../../../service/customer.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {
  customers: Customer[] = [];
  successMessage: string;
  message: string;
  errorMessage: string;
  loading = true;

  constructor(private _customerService: CustomerService) { }

  ngOnInit() {
    this.getCustomers();
  }

  getCustomers() {
    return this._customerService.getUserCustomers().subscribe(
      result => {
        this.customers = result;
        if (result.length == 0)
          this.message = "There is no data at this time...";
        this.loading = false;
        //console.log(this.customers);
      },
      error => {
        console.log(error);
        this.loading = false;
        this.errorMessage = "An error occured! Please try again...";
      }
    )
  }

  deleteCustomer(id: number) {
    return this._customerService.delete(id).subscribe(
      result => {
        this.getCustomers();
        this.successMessage = "The customer has been succefully deleted! ";
      },
      error => {
        console.log(error);
        this.errorMessage = "Something wrong! Please retry...";
      }
    )
  }

}
