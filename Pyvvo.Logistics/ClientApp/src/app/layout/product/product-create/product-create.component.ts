import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { NbDialogService } from '@nebular/theme';
import { GalleryComponent } from '../../gallery/gallery.component';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { Status } from '../../../service/Model/status';
import { StatusService } from '../../../service/status.service';
import { ProductCategoryService } from '../../../service/product-category.service';
import { ProductCategory } from '../../../service/Model/ProductCategory';
import { TaxeService } from '../../../service/taxe.service';
import { Taxe } from '../../../service/Model/taxe';
import { Option } from '../../../service/Model/Option';
import { Product } from '../../../service/Model/product';
import { Image } from '../../../service/Model/image';
import { ProductService } from '../../../service/product.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
  styleUrls: ['./product-create.component.scss']
})
export class ProductCreateComponent implements OnInit {
  productForm: FormGroup;
  txtBtnSubmit = "Save";
  formTitle = "Add new product";
  imageUrl: string;
  statusCategId = 23;
  status: Status[];
  productCategories: ProductCategory[];
  taxes: Taxe[];
  hasMultipleVariant: boolean;
  optionIndex = 1;
  optionLength = 3;
  canAddOption: boolean = true;
  options: Option[] = [];
  variantNames = [];
  tags: string[] = []
  productId = this.activatedRoute.snapshot.params["id"];
  selectedCategory;
  selectedTaxe;
  selectedStatus;
  errorMessage :string;
  cardLoading = false;
  loading = false;

  constructor(private _dialogService: NbDialogService, private _fb: FormBuilder, private _taxeService: TaxeService,
    private _statusService: StatusService, private _productCategoryService: ProductCategoryService,
    private _productService: ProductService, private router: Router, private activatedRoute: ActivatedRoute) {

    this.productForm = this._fb.group({
      name: ['', [Validators.required]],
      description: '',
      tags: '',
      isActive: true,
      hasMultipleVariant: true,
      productCategory: this._fb.group({
        id: ['', [Validators.required]]
      }),
      status: this._fb.group({
        id: ['', [Validators.required]]
      }),
      variant: this._fb.group({
        name: [''],
        retailPrice: [''],
        specialPrice: [''],
        sku: ['']
      }),
      variants: this._fb.array([]),
      options: this._fb.array([
        this._fb.group({
          name: '',
          optionValue: ''
        }),
        this._fb.group({
          name: '',
          optionValue: ''
        }),
        this._fb.group({
          name: '',
          optionValue: ''
        })
      ]),
      taxe: this._fb.group({
        id: ['', [Validators.required]]
      })
    });

    let option = new Option();
    option.name = 'Option';
    option.optionValues = [];
    this.options.push(option);

  }

  ngOnInit() {
    this.getProductToUpdate();
    this.getProductCategoryService();
    this.getStatus();
    this.getTaxes();
  }

  // Insert or update product
  upsert(product: Product) {

    if (this.productForm.valid) {

      if (this.imageUrl != null) {
        product.image = new Image();
        product.image.pathUrl = this.imageUrl;
      }
      if (this.tags.length > 0) {
        product.tags = this.tags.join();
      }

      if (!this.hasMultipleVariant && product.variants.length == 0) {
        product.variant.name = product.name;
        product.variants.push(product.variant);
      } else {
        product.variant = null;
        product.hasMultipleVariant = this.hasMultipleVariant;
      }

      if (this.productId != null && this.productId != "") {
        product.id = this.productId
        return this._productService.update(product).subscribe(
          result => {
            this.router.navigateByUrl('/app/products');
          }, error => {
            console.log(error);
          }
        );
      } else {
        return this._productService.create(product).subscribe(
          result => {
            this.router.navigateByUrl('/app/products');
          }, error => {
            console.log(error);
          }
        );
      }
    }

  }


  //Get product for update
  getProductToUpdate() {
    if (this.productId != null && this.productId != "") {
      return this._productService.get(this.productId).subscribe(
        product => {
          console.log(product);
          if (product.productCategory !=null)
            this.selectedCategory = product.productCategory.id;
          if (product.taxe != null)
            this.selectedTaxe = product.taxe.id;
          if (product.status != null)
            this.selectedStatus = product.status.id;
          if (product.image != null) {
            this.imageUrl = product.image.pathUrl
          }
          this.hasMultipleVariant = product.hasMultipleVariant;

          this.productForm.patchValue(product);
        },
        error => { console.log(error);}
      )
    }
  }

  //Add tags on key press "enter"
  addTag(tag:string) {
    this.tags.push(tag)
  }

  //Delete tag
  deleteTag(tag:string) {
    this.tags.splice(this.tags.indexOf(tag, 1));
  }

  //return that second level input has error // e.g: selected option not valid
  formSecondGroupLevelHasError(controlName: string, secondLevelControlName: string, errorName: string) {
    return ((this.productForm.controls[controlName]) as FormGroup).controls[secondLevelControlName].hasError(errorName);
  }

  addVariantItem(): FormGroup {
    return this._fb.group({
      name: [''],
      retailPrice: [''],
      specialPrice: [''],
      sku: ['']
    });
  }

  addOption() {
    this.optionIndex = this.optionIndex + 1;
    let option = new Option();
    option.name = 'Option';
    option.optionValues = [];
    this.options.push(option);
    this.defineVariantName();
    if (this.options.length == this.optionLength) {
      this.canAddOption = false;
    }
  }

  deleteOption(option) {
    if (this.optionIndex > 1) {
      this.optionIndex = this.optionIndex - 1;
      this.options.splice(this.options.indexOf(option), 1);
    }
    this.defineVariantName();
    if (this.options.length < this.optionLength) {
      this.canAddOption = true;
    }
  }

  createOptionsFormArray() {
    for (let otpion of this.options) {

    }
  }

  addOptionItem(option: Option, value: string) {
    option.optionValues.push(value);
    this.defineVariantName();
  }

  deleteOptionItem(option:Option, value: string) {
    option.optionValues.splice(option.optionValues.indexOf(value), 1);
    this.defineVariantName();
  }

  defineVariantName() {
    let optionList = [];
    this.variantNames = [];

    for (let option of this.options) {
      optionList.push(option.optionValues)
    }

    if (optionList.length == 3) {

      let first = optionList[0];
      let second = optionList[1];
      let third = optionList[2];

      for (let i of first) {
        for (let j of second) {
          for (let k of third) {
            this.variantNames.push(i + ' \\\ ' + j+ ' \\\ '+k);
          }
        }
      }

    }

    if (optionList.length == 2) {
      let first = optionList[0];
      let second = optionList[1];

      for (let i of first) {
        for (let j of second) {
            this.variantNames.push(i + ' \\\ ' + j);
        }
      }
   
    }

    if (optionList.length == 1) {
      let first = optionList[0];
      for (let i of first) {
        this.variantNames.push(i);
      }
    }
    this.createVariantsFormArray();
  }

  createVariantsFormArray() {
    let variants = this.productForm.get('variants') as FormArray;
    variants.clear();

    //for (let c of variants.controls) {
    //  console.log(variants.controls.indexOf(c))
    //  console.log(c.get('name').value)
    //  variants.removeAt(variants.controls.indexOf(c))
    //}

    for (let name of this.variantNames) {
      let variant = this._fb.group({
        name: '',
        retailPrice: '',
        specialPrice: '',
        sku: ''
      });

      variant.controls.name.setValue(name);

      variants.push(
        variant
      )
    }

  }

  // Get status 
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

  // Get product category 
  getProductCategoryService() {
    return this._productCategoryService.getCategories().subscribe(
      result => {
        this.productCategories = result;
      },
      error => {
        console.log(error);
      }
    )
  }

  //Get taxes
  // Get taxe slection options 
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

  openDialog() {
    this._dialogService.open(GalleryComponent, { closeOnBackdropClick: false })
      .onClose.subscribe(result => {
        this.imageUrl = result;
      });
  }

  //return that input has error 
  formHasError(controlName: string, errorName: string) {
    return this.productForm.controls[controlName].hasError(errorName);
  }
}
