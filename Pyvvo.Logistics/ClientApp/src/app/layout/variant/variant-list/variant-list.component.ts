import { Component, OnInit } from '@angular/core';
import { Product } from '../../../service/Model/product';
import { ProductService } from '../../../service/product.service';
import { VariantService } from '../../../service/variant.service';

@Component({
  selector: 'app-variant-list',
  templateUrl: './variant-list.component.html',
  styleUrls: ['./variant-list.component.scss']
})
export class VariantListComponent implements OnInit {
  successMessage: string;
  message: string;
  errorMessage: string;
  loading = true;
  products: Product[];

  constructor(private _productService: ProductService, private _variantService: VariantService) { }

  ngOnInit() {
    this.getProducts();
  }

  getProducts() {
    this.loading = true;
    return this._productService.getAllByCompany().subscribe(
      result => {
        this.products = result;
        if (result.length == 0)
          this.message = "There is no data at this time...";
        this.loading = false;
      }, error => {
        console.log(error);
        this.loading = false;
        this.errorMessage = "An error occured! Please try again...";
      }
    )
  }

  delete(id: number) {
    return this._variantService.delete(id).subscribe(rs => this.getProducts(),
      err => console.log(err))
  }

}
