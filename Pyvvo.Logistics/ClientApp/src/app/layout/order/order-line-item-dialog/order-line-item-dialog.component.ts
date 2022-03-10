import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../../service/product.service';
import { Product } from '../../../service/Model/product';
import { NbDialogRef } from '@nebular/theme';
import { OrderLineItem } from '../../../service/Model/order-line-item';

@Component({
  selector: 'app-order-line-item-dialog',
  templateUrl: './order-line-item-dialog.component.html',
  styleUrls: ['./order-line-item-dialog.component.scss']
})
export class OrderLineItemDialogComponent implements OnInit {
  products: Product[];
  orderLineItems: OrderLineItem;
  loading = true;
  checkedProducts: Product[];

  constructor(protected dialogRef: NbDialogRef<OrderLineItemDialogComponent>, private _productService: ProductService) {
  }

  ngOnInit() {
    this.getProducts();
    this.checkedProducts = this._productService.getCheckedProduct();
  }

  close() {
    this.dialogRef.close();
  }

  submit() {
    this.dialogRef.close(this.products);
  }

  // get selected/unselected products from checkbox
  productChecked(ev, product) {
    if (ev.target.checked && product != null) {// if product checkbox is checked
      product.checked = true; // set checkbox variable in model to true
      // checked all variants related to the product
      for (let variant of product.variants) {
        variant.checked = true;
      }
    } else {// if product checkbox is not checked 
      product.checked = false; // set product checkbox to false
      // unchecked all variant
      for (let variant of product.variants) {
        variant.checked = false;
      }
    }
  }

  // get selected/unselected variants from checkbox
  variantChecked(ev, variant, product) {
    if (ev.target.checked && variant != null && product != null) {// if variant is checked 
      variant.checked = true;// checked vaiant 
      product.checked = true;// checked variant product
    }
    else {// if variant is unchecked 
      variant.checked = false;// uncheck variant

      // chec if there is again unchecked after uncheck variant.
      //if not so unchecked vairant product too  
      var uncheckedVariants = product.variants.filter(x => x.checked == true); 
      if (uncheckedVariants.length == 0 ) {
        product.checked = false;
      }

    }
  }

  getProducts() {
    return this._productService.getAllByCompany().subscribe(
      result => {
        this.products = result;
        if (this.checkedProducts != null && this.checkedProducts.length > 0) {
          for (let checkedProduct of this.checkedProducts.filter(x => x.checked == true)) {
            var product = this.products.find(x => x.id == checkedProduct.id);
            for (let checkedVariant of checkedProduct.variants.filter(x => x.checked == true)) {
              product.variants.find(x => x.id == checkedVariant.id).checked = true;
            }
            product.checked = true;
          }
        }
        console.log(this.checkedProducts);
        this.loading = false;
      },
      error => { this.loading = false; console.log(error); }
    )
  }
}
