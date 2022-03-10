import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CustomerService } from '../../../service/customer.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Customer } from '../../../service/Model/customer';
import { Status } from '../../../service/Model/status';
import { StatusService } from '../../../service/status.service';

@Component({
  selector: 'app-customer-create',
  templateUrl: './customer-create.component.html',
  styleUrls: ['./customer-create.component.scss']
})
export class CustomerCreateComponent implements OnInit {
  customerForm: FormGroup;
  loading = false;
  cardLoading = false;
  errorMessage: string;
  customerId: string;
  updateContactId: number;
  updateShippingAddressId: number;
  updateBillingAddressId: number;
  formTitle: string = "Add new customer";
  txtBtnSubmit: string = "Save";
  sameAddressChecked = true;
  status: Status[] = [];
  statusCategId = 18;
  selectedStatusId;


  constructor(private _fb: FormBuilder, private _customerService: CustomerService,
    private router: Router, private activatedRoute: ActivatedRoute, private _statusService: StatusService) {

    // Create form group that the  html form and construct the json entity
    this.customerForm = this._fb.group({
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
      shippingAddress: this._fb.group({
        address1: ['', [Validators.required]],
        address2: '',
        province: '',
        zip: ['', [Validators.required]],
        country: ['', [Validators.required]],
      }),
      billingAddress: this._fb.group({
        address1: [''],
        address2: '',
        province: '',
        zip: [''],
        country: [''],
      }),
      status: this._fb.group({
        id: ['', [Validators.required]]
      })
    });
    this.customerId = this.activatedRoute.snapshot.params["id"];// Get the supplier id param from url
  }

  ngOnInit() {
    if (this.customerId != null && this.customerId != "") {
      this.formTitle = "Update customer informations";
      this.txtBtnSubmit = "Update";
      this.cardLoading = true;
      this.sameAddressChecked = false;// allow user to udpdate the 2 addresses
      this.getCustomerForUpdate();//Get supplier information to update and pre-fullfil the form
    }
    this.getStatus();
  }

  getCustomerForUpdate() {
    return this._customerService.get(this.customerId).subscribe(
      result => {
        console.log(result);
        this.updateShippingAddressId = result.shippingAddress.id;
        this.updateBillingAddressId = result.billingAddress.id;
        this.updateContactId = result.contact.id;
        this.selectedStatusId = result.status.id;
        this.customerForm.patchValue(result);
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

  upsertCustomer(customer: Customer) {
    if (this.customerForm.valid) {

      this.loading = true; // enable button loading

      if (this.customerId != null && this.customerId != "") {// Check if id exist in url for update 
        var id: number = +this.customerId; // convert id string into number 
        customer.id = id; // set id for udpdate
        if (this.updateContactId != 0) customer.contact.id = this.updateContactId;// Set contact id for update
        //Set addresses ids for update
        if (this.updateShippingAddressId != 0) customer.shippingAddress.id = this.updateShippingAddressId;
        if (this.updateBillingAddressId != 0) customer.billingAddress.id = this.updateBillingAddressId;
        return this._customerService.update(customer).subscribe( // update
          result => {
            this.router.navigateByUrl("/customers"); // after redirect to customer list 
          },
          error => {
            console.log(error);//Log error in devoloper console 
            this.errorMessage = "Something wrong! Please check your informations and retry...";//Set error message to display in html to user;
            this.loading = false;// Disable loading 
          }
        );
      } else {
        if (this.sameAddressChecked = true) // Check if toogle is checked 
          customer.billingAddress = customer.shippingAddress;// Set same address for shipping and facturation 
        return this._customerService.create(customer).subscribe(// create if not update
          result => {
            this.router.navigateByUrl("/customers"); // redirect to customers list 
          },
          error => {
            console.log(error);//Log error in devoloper console 
            this.errorMessage = "Something wrong! Please check your informations and retry...";//Set error message to display in html to user;
            this.loading = false;// Disable loading 
          }
        );
      }
    }
  }

  toggle(checked: boolean) {
    if (checked) {
      this.sameAddressChecked = checked;

    } else
      this.sameAddressChecked = false;
  }
}
