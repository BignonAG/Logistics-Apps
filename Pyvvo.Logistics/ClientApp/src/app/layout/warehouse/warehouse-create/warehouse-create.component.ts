import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { WarehouseService } from '../../../service/warehouse.service';
import { Warehouse } from '../../../service/Model/warehouse';
import { StatusService } from '../../../service/status.service';
import { Status } from '../../../service/Model/status';


@Component({
  selector: 'app-warehouse-create',
  templateUrl: './warehouse-create.component.html',
  styleUrls: ['./warehouse-create.component.scss']
})
export class WarehouseCreateComponent implements OnInit {
    warehouseForm: FormGroup;
    loading = false;
    cardLoading = false;
    errorMessage: string;
    warehouseId: string;
    updateContactId: number;
    updateAddressId: number;
    formTitle: string = "Add new warehouse";
    txtBtnSubmit: string = "Save";
    status: Status[] = [];
    selectedStatusId;
    statusCategId = 16;

    constructor(private _fb: FormBuilder, private _warehouseService: WarehouseService,
        private router: Router, private activatedRoute: ActivatedRoute, private _statusService: StatusService) {

        // Create form group that the  html form and construct the json entity
        this.warehouseForm = this._fb.group({
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
            address: this._fb.group({
                address1: ['', [Validators.required]],
                address2: '',
                province: '',
                zip: ['', [Validators.required]],
                country: ['', [Validators.required]],
            })
        });
        this.warehouseId = this.activatedRoute.snapshot.params["id"];// Get the warehouse id param from url 
    }

    ngOnInit() {
        if (this.warehouseId != null && this.warehouseId != "") {
            this.formTitle = "Update warehouse informations";
            this.txtBtnSubmit = "Update";
                this.formTitle = "Update warehouse";
                this.txtBtnSubmit = "Update";
                this.cardLoading = true;
            this.getEntityForUpdate();//Get warehouse information to update and pre-fullfil the form

    
        }
        this.getStatus();
    }

    upsertEntity(warehouse: Warehouse) {
        if (this.warehouseForm.valid) {
            this.loading = true;
            if (this.warehouseId != null && this.warehouseId != "") {
                var id: number = +this.warehouseId;
                warehouse.id = id;
                if (this.updateContactId != 0) warehouse.address.id = this.updateContactId;
                if (this.updateAddressId != 0) warehouse.address.id = this.updateAddressId;
                return this._warehouseService.update(warehouse).subscribe(
                    result => {
                        this.router.navigateByUrl("/app/warehouses")
                    },
                    error => {
                        console.log(error);
                        this.errorMessage = "Something wrong! Please check your informations and retry...";
                        this.loading = false;
                    }
                );
            } else {
                return this._warehouseService.create(warehouse).subscribe(
                    result => {
                        this.router.navigateByUrl("/app/warehouses")
                        console.log(result);
                        
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

    getEntityForUpdate() {
        return this._warehouseService.get(this.warehouseId).subscribe(
            result => {
                console.log(result);
                this.updateAddressId = result.address.id;
                this.updateContactId = result.contact.id;
                //his.selectedStatusId = result.contact.status.id;
                this.warehouseForm.patchValue(result);
                
            },
            error => {
                console.log(error);
            },
            ()=>{
                this.cardLoading = false;
            }
            
        );
    }

    getStatus() {

        return this._statusService.getStatus(this.statusCategId).subscribe(
            result => {
                console.log(result);
                this.status = result;
            },
            error => {
                console.log(error);
            }
        )
    }

}
