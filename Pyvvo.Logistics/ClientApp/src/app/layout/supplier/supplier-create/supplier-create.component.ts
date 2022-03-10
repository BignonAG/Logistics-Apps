import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { SupplierService } from '../../../service/supplier.service';
import { Supplier } from '../../../service/Model/supplier';
import { Router, ActivatedRoute } from '@angular/router';
import { Status } from '../../../service/Model/status';
import { StatusService } from '../../../service/status.service';

@Component({
  selector: 'app-supplier-create',
  templateUrl: './supplier-create.component.html',
  styleUrls: ['./supplier-create.component.scss']
})
export class SupplierCreateComponent implements OnInit {
  supplierForm: FormGroup;
  loading = false;
  cardLoading = false;
  errorMessage: string;
  supplierId: string;
  updateContactId: number;
  updateAddressId: number;
  formTitle: string = "Add new supplier";
  txtBtnSubmit: string = "Save";
  status: Status[] = [];
  selectedStatusId;
  statusCategId = 16;

    constructor(private _fb: FormBuilder, private _supplierService: SupplierService,
      private router: Router, private activatedRoute: ActivatedRoute, private _statusService: StatusService) {

      // Create form group that the  html form and construct the json entity
      this.supplierForm = this._fb.group({
        contact: this._fb.group({
          firstName: ['', [Validators.required]],
          lastName: ['', [Validators.required]],
          email: ['', [Validators.required]],
          phone: ['', [Validators.required]],
          website: [''],
          facebook: [''],
          linkedin: [''],
          viadeo: [''],
          status: this._fb.group({
            id: ['', [Validators.required]]
          })
        }),
        address: this._fb.group({
          address1: ['', [Validators.required]],
          address2: '',
          province: '',
          zip: ['', [Validators.required]],
          country: ['', [Validators.required]],
        })
      });
      this.supplierId = this.activatedRoute.snapshot.params["id"];// Get the supplier id param from url 
  }

  ngOnInit() {
    if (this.supplierId != null && this.supplierId != "") {
      this.formTitle = "Update supplier informations";
      this.txtBtnSubmit = "Update";
      this.cardLoading = true;
      this.getSupplierForUpdate();//Get supplier information to update and pre-fullfil the form
    }
    this.getStatus();
  }

  upsertSupplier(supplier: Supplier) {
    if (this.supplierForm.valid) {
      this.loading = true;
      if (this.supplierId != null && this.supplierId != "") {
        var id: number = +this.supplierId;
        supplier.id = id;
        if (this.updateContactId != 0) supplier.contact.id = this.updateContactId;
        if (this.updateAddressId != 0) supplier.address.id = this.updateAddressId;
        return this._supplierService.update(supplier).subscribe(
          result => {
            this.router.navigateByUrl("/app/suppliers")
          },
          error => {
            console.log(error);
            this.errorMessage = "Something wrong! Please check your informations and retry...";
            this.loading = false;
          }
        );
      } else {
        console.log(supplier);
        return this._supplierService.create(supplier).subscribe(
          result => {
            this.router.navigateByUrl("/app/suppliers")
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

  getSupplierForUpdate() {
    return this._supplierService.get(this.supplierId).subscribe(
      result => {
        this.updateAddressId = result.address.id;
        this.updateContactId = result.contact.id;
        this.selectedStatusId = result.contact.status.id;
        this.supplierForm.patchValue(result);
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
