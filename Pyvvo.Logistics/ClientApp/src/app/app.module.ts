import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
  NbThemeModule,
  NbLayoutModule,
  NbSidebarModule,
  NbButtonModule,
  NbMenuModule,
  NbInputModule,
  NbContextMenuModule,
  NbUserModule,
  NbIconModule,
  NbActionsModule,
  NbCardModule,
  NbSelectModule,
  NbSpinnerModule,
  NbToggleModule,
  NbDatepickerModule,
  NbDialogModule,
  NbCheckboxModule,
  NbStepperModule,
  NbBadgeModule,
  NbWindowModule,
  NbToastrModule
} from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { SidebarComponent } from './layout/sidebar/sidebar.component';
import { HeaderComponent } from './layout/header/header.component';
import { StatusCategoryComponent } from './layout/status-category/status-category.component';
import { SignInComponent } from './auth/sign-in/sign-in.component';
import { SignUpComponent } from './auth/sign-up/sign-up.component';
import { LogoutComponent } from './auth/logout/logout.component';
import { WarehouseComponent } from './layout/warehouse/warehouse/warehouse.component';
import { SupplierComponent } from './layout/supplier/supplier/supplier.component';
import { SupplierCreateComponent } from './layout/supplier/supplier-create/supplier-create.component';
import { CustomerComponent } from './layout/customer/customer/customer.component';
import { CustomerCreateComponent } from './layout/customer/customer-create/customer-create.component';
import { UserComponent } from './layout/user/user/user.component';
import { UserCreateComponent } from './layout/user/user-create/user-create.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { OrderComponent } from './layout/order/order/order.component';
import { OrderCreateComponent } from './layout/order/order-create/order-create.component';
import { OrderLineItemDialogComponent } from './layout/order/order-line-item-dialog/order-line-item-dialog.component';
import { LayoutComponent } from './layout/layout.component';
//import { DashboardComponent } from './layout/dashboard/dashboard.component';
import { OrderDetailComponent } from './layout/order/order-detail/order-detail.component';
import { RefundComponent } from './layout/refund/refund/refund.component';
import { RefundCreateComponent } from './layout/refund/refund-create/refund-create.component';
import { RefundLineItemDialogComponent } from './layout/refund/refund-line-item-dialog/refund-line-item-dialog.component';
import { RefundDetailComponent } from './layout/refund/refund-detail/refund-detail.component';
import { InvoiceComponent } from './layout/invoice/invoice/invoice.component';
import { InvoiceDetailComponent } from './layout/invoice/invoice-detail/invoice-detail.component';
import { ProductListComponent } from './layout/product/product-list/product-list.component';
import { ProductCreateComponent } from './layout/product/product-create/product-create.component';
import { ProductDetailComponent } from './layout/product/product-detail/product-detail.component';
import { GalleryComponent } from './layout/gallery/gallery.component';
import { VariantListComponent } from './layout/variant/variant-list/variant-list.component';
import { VariantCreateComponent } from './layout/variant/variant-create/variant-create.component';
import { VariantDetailComponent } from './layout/variant/variant-detail/variant-detail.component';
import { ProcessingListComponent } from './layout/processing/processing-list/processing-list.component';
import { ProcessingCreateComponent } from './layout/processing/processing-create/processing-create.component';
import { ProcessingDetailComponent } from './layout/processing/processing-detail/processing-detail.component';
import { DEFAULT_THEME } from './@theme/styles/theme.default';
import { COSMIC_THEME } from './@theme/styles/theme.cosmic';
import { CORPORATE_THEME } from './@theme/styles/theme.corporate';
import { DARK_THEME } from './@theme/styles/theme.dark';
//import { LineChartJsComponent } from './layout/dashboard/line-chart-js/line-chart-js.component';
//import { PieEchartComponent } from './layout/dashboard/pie-echart/pie-echart.component';
//import { ChartModule } from 'angular2-chartjs';
//import { NgxEchartsModule } from 'ngx-echarts';
//import * as echarts from 'echarts';
//import { ChannelsTraficComponent } from './layout/dashboard/channels-trafic/channels-trafic.component';
//import { BestCustomersComponent } from './layout/dashboard/best-customers/best-customers.component';
//import { PageViewComponent } from './layout/dashboard/page-view/page-view.component';
import { WarehouseDetailComponent } from './layout/warehouse/warehouse-detail/warehouse-detail.component';
import { WarehouseCreateComponent } from './layout/warehouse/warehouse-create/warehouse-create.component';
import { SupplierDetailComponent } from './layout/supplier/supplier-detail/supplier-detail.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { config } from 'process';




@NgModule({
  declarations: [
    AppComponent,
    SidebarComponent,
    HeaderComponent,
    StatusCategoryComponent,
    SignInComponent,
    SignUpComponent,
    LogoutComponent,
    WarehouseComponent,
    SupplierComponent,
    SupplierCreateComponent,
    CustomerComponent,
    CustomerCreateComponent,
    UserComponent,
    UserCreateComponent,
    PageNotFoundComponent,
    OrderComponent,
    OrderCreateComponent,
    OrderLineItemDialogComponent,
    LayoutComponent,
   // Should be removed DashboardComponent,
    OrderDetailComponent,
    RefundComponent,
    RefundCreateComponent,
    RefundLineItemDialogComponent,
    RefundDetailComponent,
    InvoiceComponent,
    InvoiceDetailComponent,
    ProductListComponent,
    ProductCreateComponent,
    ProductDetailComponent,
    GalleryComponent,
    VariantListComponent,
    VariantCreateComponent,
    VariantDetailComponent,
    ProcessingListComponent,
    ProcessingCreateComponent,
    ProcessingDetailComponent,
    //LineChartJsComponent,
    //PieEchartComponent,
    //ChannelsTraficComponent,
    //BestCustomersComponent,
    //PageViewComponent,
    WarehouseCreateComponent,
    WarehouseDetailComponent,
    SupplierDetailComponent 

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,  
    BrowserAnimationsModule,
    NbLayoutModule,
    NbEvaIconsModule,
    NbSidebarModule.forRoot(), // NbSidebarModule.forRoot(), //if this is your app.module
    NbButtonModule,
    NbMenuModule.forRoot(),
    NbInputModule,
    ReactiveFormsModule,
    NbContextMenuModule,
    NbUserModule,
    NbIconModule,
    NbActionsModule,
    NbCardModule,
    NbSelectModule,
    NbSpinnerModule,
    NbToggleModule,
    NbCheckboxModule,
    NbStepperModule,
    NbBadgeModule,
    NbToastrModule.forRoot(),
    NbDatepickerModule.forRoot(),
    NbDialogModule.forChild(),
    NbWindowModule.forRoot(),
    NbThemeModule.forRoot({
      name: 'default',
    },
    [DEFAULT_THEME, COSMIC_THEME, CORPORATE_THEME, DARK_THEME]),
    NgbModule,
    AppRoutingModule
    //ChartModule,
    //NgxEchartsModule.forRoot({ echarts }),
  ],
  entryComponents: [
    OrderLineItemDialogComponent,
    RefundLineItemDialogComponent,
    GalleryComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
