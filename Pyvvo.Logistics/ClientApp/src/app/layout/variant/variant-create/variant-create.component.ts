import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NbDialogService } from '@nebular/theme';
import { GalleryComponent } from '../../gallery/gallery.component';
import { Taxe } from '../../../service/Model/taxe';
import { Status } from '../../../service/Model/status';
import { Parameter } from '../../../service/Model/parameter';
import { Supplier } from '../../../service/Model/supplier';
import { StatusService } from '../../../service/status.service';
import { TaxeService } from '../../../service/taxe.service';
import { SupplierService } from '../../../service/supplier.service';
import { ParameterService } from '../../../service/parameter.service';
import { ActivatedRoute, Router } from '@angular/router';
import { VariantService } from '../../../service/variant.service';
import { Variant } from '../../../service/Model/variant';

@Component({
  selector: 'app-variant-create',
  templateUrl: './variant-create.component.html',
  styleUrls: ['./variant-create.component.scss']
})
export class VariantCreateComponent implements OnInit {
  variantForm: FormGroup;
  status: Status[];
  taxes: Taxe[];
  parameters: Parameter[];
  suppliers: Supplier[];
  imageUrl: string;
  statusCategId = 24;
  txtBtnSubmit = "Update";
  variantId = this.activatedRoute.snapshot.params["id"];
  selectedParameter;
  selectedStatus;
  selectedTaxe;
  selectedSupplier;
  formTitle:string;
  loading=false;
  cardLoading =false;
  errorMessage:string;

  constructor(private fb: FormBuilder, private _dialogService: NbDialogService, private _statusService: StatusService,
    private _taxeService: TaxeService, private _supplierService: SupplierService, private _parameterService: ParameterService,
    private activatedRoute: ActivatedRoute, private _variantService: VariantService, private router: Router) {

    this.variantForm = this.fb.group({
      name: ['', [Validators.required]],
      type: '',
      retailPrice: '',
      specialPrice: '',
      sku: '',
      ean: '',
      upc: '',
      isbn: '',
      hsCode: '',
      supplierCode: '',
      weight: '',
      avgSupplyTime: '',
      lineNumber: '',
      moq: '',
      isTaxable: false,
      isActive: true,
      initialStockLevel:'',
      status: this.fb.group({
        id: ['', [Validators.required]]
      }),
      taxe: this.fb.group({
        id: ''
      }),
      parameter: this.fb.group({
        id: ['', [Validators.required]]
      }),
      supplier: this.fb.group({
        id: ''
      }),
    })
  }

  ngOnInit() {
    this.getVariant();
    this.getStatus();
    this.getTaxes();
    this.getSuppliers();
    this.getParameters();
  }

  upsert(variant: Variant) {
    if (this.variantForm.valid) {
      variant.id = this.variantId;
      return this._variantService.update(variant).subscribe(
        result => {
          this.router.navigateByUrl('/app/variants');
        },
        error => {
          console.log(error);
        }
      );
    }
  }

  getVariant() {
    if (this.variantId != null && this.variantId != "") {
      return this._variantService.get(this.variantId).subscribe(variant => {
        console.log(variant)
        this.selectedParameter = variant.parameter != null ? variant.parameter.id: 0;
        this.selectedStatus = variant.status!=null ?  variant.status.id : 0;
        this.selectedTaxe = variant.taxe != null ? variant.taxe.id : 0;
        this.selectedSupplier = variant.supplier != null ? variant.supplier.id : 0;
        this.imageUrl = variant.image !=null ? variant.image.pathUrl : null;
        this.variantForm.patchValue(variant);

        }, error => { console.log(error) }
      );
    }
  }

  openDialog() {
    this._dialogService.open(GalleryComponent, { closeOnBackdropClick: false })
      .onClose.subscribe(result => {
        this.imageUrl = result;
      });
  }

  getTaxes() {
    return this._taxeService.getTaxes().subscribe(
      result => {
        this.taxes = result;
      },
      error => {
        console.log(error);
      }
    )
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

  getSuppliers() {
    return this._supplierService.getSuppliers().subscribe(
      result => {
        this.suppliers = result;
      },
      error => {
        console.log(error);
      }
    )
  }

  getParameters() {
    return this._parameterService.getEntities().subscribe(
      result => {
        this.parameters = result;
      },
      error => {
        console.log(error);
      }
    )
  }

  formHasError(controlName: string, errorName: string) {
    return this.variantForm.controls[controlName].hasError(errorName);
  }

  //return that second level input has error // e.g: selected option not valid
  formSecondGroupLevelHasError(controlName: string, secondLevelControlName: string, errorName: string) {
    return ((this.variantForm.controls[controlName]) as FormGroup).controls[secondLevelControlName].hasError(errorName);
  }

}
