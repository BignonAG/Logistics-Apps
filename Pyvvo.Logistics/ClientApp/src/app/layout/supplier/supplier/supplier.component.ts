import { Component, OnInit } from '@angular/core';
import { SupplierService } from '../../../service/supplier.service';
import { Supplier } from '../../../service/Model/supplier';

@Component({
  selector: 'app-supplier',
  templateUrl: './supplier.component.html',
  styleUrls: ['./supplier.component.scss']
})
export class SupplierComponent implements OnInit {
  suppliers: Supplier[] = [];
  successMessage: string;
  errorMessage: string;
  loading = true;
  message: string;

  constructor(private _supplierService: SupplierService) { }

  ngOnInit() {
    this.getSuppliers();
  }

  getSuppliers() {
    return this._supplierService.getSuppliers().subscribe(
      result => {
        this.suppliers = result;
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

  deleteSupplier(id:number) {
    return this._supplierService.delete(id).subscribe(
      result => {
        this.getSuppliers();
        this.successMessage = "Supplier has been succefully deleted! ";
      },
      error => {
        console.log(error);
        this.errorMessage = "Something wrong! Please retry...";
      }
    )
  }

}
