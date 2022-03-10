import { Component, OnInit } from '@angular/core';
import { Processing } from '../../../service/Model/processing';
import { ProcessingService } from '../../../service/processing.service';

@Component({
  selector: 'app-processing-list',
  templateUrl: './processing-list.component.html',
  styleUrls: ['./processing-list.component.scss']
})
export class ProcessingListComponent implements OnInit {
  processings: Processing[];
  successMessage: string;
  errorMessage: string;
  message: string;
  loading: boolean;
  constructor(private _processingService: ProcessingService) { }

  ngOnInit() {
    this.getProcessings();
  }

  getProcessings() {
    this.loading = true;
    return this._processingService.getProcessings().subscribe(
      result => {
        this.processings = result;
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
    return this._processingService.delete(id).subscribe(
      result => {
        this.getProcessings();
        this.successMessage = "The item has been succefully deleted! ";
      },
      error => {
        console.log(error);
        this.errorMessage = "Something wrong! Please retry...";
      }
    )
  }

}
