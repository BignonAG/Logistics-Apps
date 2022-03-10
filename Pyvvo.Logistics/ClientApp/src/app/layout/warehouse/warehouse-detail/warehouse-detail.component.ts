import { Component, OnInit } from '@angular/core';
import { Warehouse } from '../../../service/Model/warehouse';
import { ActivatedRoute } from '@angular/router';
import { WarehouseService } from '../../../service/warehouse.service';

@Component({
  selector: 'app-warehouse-detail',
  templateUrl: './warehouse-detail.component.html',
  styleUrls: ['./warehouse-detail.component.scss']
})
export class WarehouseDetailComponent implements OnInit {

    warehouseId: string;
    warehouse: Warehouse;
    grandTotal: number = 0;
    totalTax: number = 0;
    total: number = 0;
    shippingCharge: number = 0;

    constructor(private activatedRoute: ActivatedRoute, private _warehouseService: WarehouseService) { }


    ngOnInit() {
        this.warehouseId = this.activatedRoute.snapshot.params["id"];// Get the supplier id param from url
        this.getWarehouse();

    }

    getWarehouse() {
        return this._warehouseService.get(this.warehouseId).subscribe(
            result => {
                console.log(result);
                this.warehouse = result;
            },
            error => {
                console.log(error);
            }
        );
    }


}
