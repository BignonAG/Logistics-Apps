import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';
import { LogoutComponent } from './auth/logout/logout.component';
import { SignInComponent } from './auth/sign-in/sign-in.component';
import { SignUpComponent } from './auth/sign-up/sign-up.component';
import { CustomerCreateComponent } from './layout/customer/customer-create/customer-create.component';
import { CustomerComponent } from './layout/customer/customer/customer.component';
import { InvoiceDetailComponent } from './layout/invoice/invoice-detail/invoice-detail.component';
import { InvoiceComponent } from './layout/invoice/invoice/invoice.component';
import { LayoutComponent } from './layout/layout.component';
import { OrderCreateComponent } from './layout/order/order-create/order-create.component';
import { OrderDetailComponent } from './layout/order/order-detail/order-detail.component';
import { OrderComponent } from './layout/order/order/order.component';
import { ProcessingCreateComponent } from './layout/processing/processing-create/processing-create.component';
import { ProcessingListComponent } from './layout/processing/processing-list/processing-list.component';
import { ProductCreateComponent } from './layout/product/product-create/product-create.component';
import { ProductDetailComponent } from './layout/product/product-detail/product-detail.component';
import { ProductListComponent } from './layout/product/product-list/product-list.component';
import { RefundCreateComponent } from './layout/refund/refund-create/refund-create.component';
import { RefundDetailComponent } from './layout/refund/refund-detail/refund-detail.component';
import { RefundComponent } from './layout/refund/refund/refund.component';
import { StatusCategoryComponent } from './layout/status-category/status-category.component';
import { SupplierCreateComponent } from './layout/supplier/supplier-create/supplier-create.component';
import { SupplierDetailComponent } from './layout/supplier/supplier-detail/supplier-detail.component';
import { SupplierComponent } from './layout/supplier/supplier/supplier.component';
import { UserCreateComponent } from './layout/user/user-create/user-create.component';
import { UserComponent } from './layout/user/user/user.component';
import { VariantCreateComponent } from './layout/variant/variant-create/variant-create.component';
import { VariantDetailComponent } from './layout/variant/variant-detail/variant-detail.component';
import { VariantListComponent } from './layout/variant/variant-list/variant-list.component';
import { WarehouseCreateComponent } from './layout/warehouse/warehouse-create/warehouse-create.component';
import { WarehouseDetailComponent } from './layout/warehouse/warehouse-detail/warehouse-detail.component';
import { WarehouseComponent } from './layout/warehouse/warehouse/warehouse.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

const routes: Routes = [
  { path: '', redirectTo: 'app', pathMatch: 'full'},
  {
    path: 'auth', children: [
      { path: 'sign-in', component: SignInComponent },
      { path: 'sign-up', component: SignUpComponent },
    ]
  },
  {
    path: 'app', component: LayoutComponent, children: [
      { path: '', component: OrderComponent },
      { path: 'warehouses', component: WarehouseComponent, canActivate: [AuthGuard] },
      { path: 'warehouse/create', component: WarehouseCreateComponent, canActivate: [AuthGuard] },
      { path: 'warehouse/update/:id', component: WarehouseCreateComponent, canActivate: [AuthGuard] },
      { path: 'warehouse/:id', component: WarehouseDetailComponent, canActivate: [AuthGuard] },
      { path: 'status/category', component: StatusCategoryComponent },
      { path: 'supplier/:id', component: SupplierDetailComponent, canActivate: [AuthGuard] },
      { path: 'suppliers', component: SupplierComponent, canActivate: [AuthGuard] },
      { path: 'supplier/create', component: SupplierCreateComponent, canActivate: [AuthGuard] },
      { path: 'supplier/update/:id', component: SupplierCreateComponent, canActivate: [AuthGuard] },
      { path: 'customers', component: CustomerComponent, canActivate: [AuthGuard] },
      { path: 'customer/create', component: CustomerCreateComponent, canActivate: [AuthGuard] },
      { path: 'customer/update/:id', component: CustomerCreateComponent, canActivate: [AuthGuard] },
      { path: 'users', component: UserComponent, canActivate: [AuthGuard] },
      { path: 'user/create', component: UserCreateComponent, canActivate: [AuthGuard] },
      { path: 'user/update/:id', component: UserCreateComponent, canActivate: [AuthGuard] },
      { path: 'orders', component: OrderComponent, canActivate: [AuthGuard] },
      { path: 'order/create', component: OrderCreateComponent, canActivate: [AuthGuard] },
      { path: 'order/update/:id', component: OrderCreateComponent, canActivate: [AuthGuard] },
      { path: 'order/:id', component: OrderDetailComponent, canActivate: [AuthGuard] },
      { path: 'refunds', component: RefundComponent, canActivate: [AuthGuard] },
      { path: 'refund/create', component: RefundCreateComponent, canActivate: [AuthGuard] },
      { path: 'refund/update/:id', component: RefundCreateComponent, canActivate: [AuthGuard] },
      { path: 'refund/:id', component: RefundDetailComponent, canActivate: [AuthGuard] },
      { path: 'invoice/:id', component: InvoiceDetailComponent, canActivate: [AuthGuard] },
      { path: 'order/:orderId/invoice', component: InvoiceDetailComponent, canActivate: [AuthGuard] },
      { path: 'invoices', component: InvoiceComponent, canActivate: [AuthGuard] },
      { path: 'products', component: ProductListComponent, canActivate: [AuthGuard] },
      { path: 'product/create', component: ProductCreateComponent, canActivate: [AuthGuard] },
      { path: 'product/update/:id', component: ProductCreateComponent, canActivate: [AuthGuard] },
      { path: 'product/:id', component: ProductDetailComponent, canActivate: [AuthGuard] },
      { path: 'variant/:id', component: VariantDetailComponent, canActivate: [AuthGuard] },
      { path: 'variant/update/:id', component: VariantCreateComponent, canActivate: [AuthGuard] },
      { path: 'variants', component: VariantListComponent, canActivate: [AuthGuard] },
      { path: 'processing/create', component: ProcessingCreateComponent, canActivate: [AuthGuard] },
      { path: 'processing/update/:id', component: ProcessingCreateComponent, canActivate: [AuthGuard] },
      { path: 'processings', component: ProcessingListComponent, canActivate: [AuthGuard] },
      { path: 'logout', component: LogoutComponent },
      { path: '**', component: PageNotFoundComponent },  // Wildcard route for a 404 page
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }