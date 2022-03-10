import { Component, OnInit } from '@angular/core';
import { StatusCategory } from '../../service/Model/StatusCategory';
import { StatusCategoryService } from '../../service/status-category.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-status-category',
  templateUrl: './status-category.component.html',
  styleUrls: ['./status-category.component.scss']
})
export class StatusCategoryComponent implements OnInit {
  statusCategory: StatusCategory;
  statusCategForm:FormGroup;
  errorMessage:string;

  constructor(private _statusCategService: StatusCategoryService, private formBuilder: FormBuilder) {
    this.statusCategForm = this.formBuilder.group({
        name: ['', [Validators.required]],
      }
    )
  }

  ngOnInit() {

  }

  createStatusCateg(statusCateg: StatusCategory) {
    return this._statusCategService.create(statusCateg).subscribe(
      result => { this.statusCategory = result; console.log(result)},
      error => console.log(error)
    )
  }

}
