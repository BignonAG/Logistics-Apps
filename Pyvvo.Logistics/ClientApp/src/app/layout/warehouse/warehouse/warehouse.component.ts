import { Component, HostBinding, OnInit } from '@angular/core';
import { NbToastrService } from '@nebular/theme';
import { Warehouse } from '../../../service/Model/warehouse';
import { WarehouseService } from '../../../service/warehouse.service';

@Component({
    selector: 'app-warehouse',
    templateUrl: './warehouse.component.html',
    styleUrls: ['./warehouse.component.scss']
})



export class WarehouseComponent implements OnInit {

    @HostBinding('class')
    classes = 'example-items-rows';
    private index: number = 0;

    warehouses: Array<{ state: boolean, data: Warehouse }> = [];
    loading = true;
    message: string;
    checkboxArray: Array<{ state: boolean, data: Warehouse }>;
    ColumnCheckButton: boolean = false; isAllchecked: boolean = false;
    editButton: boolean = false; deleteButton: boolean = false;
    id : number =undefined;

    constructor(private _warehouseService: WarehouseService, private toastrService: NbToastrService) { }

    ngOnInit() {
        this.getEntities();
    }

    getEntities() {
        this.warehouses = [];
        this._warehouseService.getUserEntities().subscribe(
            result => {
                console.log(result);
                for (let i = 0; i < result.length; i++) {
                    this.warehouses[i] = { state: false, data: result[i] };
                }

                this.loading = false;
                if (result.length == 0)
                    this.message = "There is no data at this time...";
            },
            error => {
                console.log(error);
                this.loading = false;
            }

        );
    }

    edit(): number {
        let id = this.warehouses.find(element => { return element.state == true }).data.id

        if (id) {
            
            return id;
        }
        else {
            this.showToast("An error occured! Please try again...", "danger", id);
            return -1;
        }
    }

    delete() {

        this.warehouses.filter(element => { return element.state == true }).forEach(
            element => {

                this._warehouseService.delete(element.data.id).subscribe(

                    () => {
                        
                        this.showToast("The row is successfully deleted", "success", element.data.id);
                    
                    },
                    error => {
                        this.showToast("An error occured! Please try again...", "danger", element.data.id);
                        console.log(error);
                    },
                    () => {
                        this.getEntities();
                    }
                        
                
                )
            }
        );
        
    }

    RowIsChecked(index: number, state: boolean) {

        this.warehouses[index].state = state;
        this.menuButtonStateChecker();
        
    }

    checkAllRow(state: boolean) {

        for (let i = 0; i < this.warehouses.length; i++) {
            this.warehouses[i].state = state;
        }
        this.menuButtonStateChecker();

    }

    menuButtonStateChecker() {
        let numberOfCheckedRow = 0;
        for (let i = 0; i < this.warehouses.length; i++) {
            this.warehouses[i].state ? numberOfCheckedRow++ : numberOfCheckedRow;
        }
        this.editButton = numberOfCheckedRow == 1 
        if(this.editButton)
        {
            this.id = this.warehouses.find(element => { return element.state == true }).data.id
        }
        this.deleteButton = numberOfCheckedRow >= 1;
        this.ColumnCheckButton = numberOfCheckedRow == this.warehouses.length;
    }

    showToast(message: string, status, name) {

        this.toastrService.show(message,
            name,
            { status });
    }



}

