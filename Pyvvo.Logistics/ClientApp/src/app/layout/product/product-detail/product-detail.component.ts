import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../../service/product.service';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../../../service/Model/product';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {

  productId = this.activatedRoute.snapshot.params["id"];
  product: Product;

  constructor(private _productService: ProductService, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.getProduct();
  }

  getProduct() {
    this._productService.get(this.productId).subscribe(
      result => { console.log(result); this.product = result },
      error => console.log(error)
    )
  }

}
