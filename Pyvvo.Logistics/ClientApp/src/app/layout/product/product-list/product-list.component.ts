import { Component, OnInit } from '@angular/core';
import { Product } from '../../../service/Model/product';
import { ProductService } from '../../../service/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {
  successMessage: string;
  message: string;
  errorMessage: string;
  loading = true;
  products: Product[];

  constructor(private _productService: ProductService) { }

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

  deleteProduct(id: number) {
    return this._productService.delete(id).subscribe(
      result => {
        this.getProducts();
        this.successMessage = "The product has been succefully deleted! ";
      },
      error => {
        console.log(error);
        this.errorMessage = "Something wrong! Please retry...";
      }
    )
  }

}
