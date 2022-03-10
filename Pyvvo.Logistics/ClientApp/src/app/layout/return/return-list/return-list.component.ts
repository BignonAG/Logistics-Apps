import { Component, OnInit } from '@angular/core';
import { Return } from '../../../service/Model/return';
import { ReturnService } from '../../../service/return.service';

@Component({
  selector: 'app-return-list',
  templateUrl: './return-list.component.html',
  styleUrls: ['./return-list.component.scss']
})
export class ReturnListComponent implements OnInit {

  returns: Return[];
  successMessage: string;
  errorMessage: string;
  message: string;
  loading: boolean;
  constructor(private _returnService: ReturnService) { }

  ngOnInit() {
    this.getReturns();
  }

  getReturns() {
    this.loading = true;
    return this._returnService.getReturns().subscribe(
      result => {
        this.returns = result;
        if (result.length == 0)
          this.message = "There is no data at this time...";
        this.loading = false;
      },
      error => {
        this.loading = false;
        console.log(error);
      }
    )
  }

  delete(id: number) {
    return this._returnService.delete(id).subscribe(
      result => {
        this.getReturns();
        this.successMessage = "The item has been succefully deleted! ";
      },
      error => {
        console.log(error);
        this.errorMessage = "Something wrong! Please retry...";
      }
    )
  }

}
