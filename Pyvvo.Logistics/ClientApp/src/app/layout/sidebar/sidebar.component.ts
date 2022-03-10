import { Component, OnInit } from '@angular/core';
import { NbMenuItem } from '@nebular/theme';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
    items: NbMenuItem[] = [

        {
            title: 'Dashboard',
            icon: 'bar-chart-outline',
            link: '/app/dashboard'
        },
        {
            title: 'Order Management',
            icon: 'shopping-bag-outline',
            expanded: false,
            children: [
                {
                    title: 'Order',
                    link: '/app/orders',
                },
                {
                    title: 'Refunds',
                    link: '/app/refunds',
                },
                {
                    title: 'Invoices',
                    link: '/app/invoices',
                },

            ],
        },

        {
            title: 'Product Management',
            icon: 'cube-outline',
            expanded: false,
            children: [
                //{
                //    title: 'Categories',
                //    link: 'product-categories',
                //},
                {
                    title: 'Products',
                    link: '/app/products',
                },
                {
                    title: 'Variants',
                    link: '/app/variants',
                },
            ],
        },

        {
            title: 'Fulfillment Management',
            icon: 'clipboard-outline',
            expanded: false,
            children: [
                {
                    title: 'Shipments',
                    link: '/app/shipments',
                },
                {
                    title: 'Shipping Methods',
                    link: '/app/shipping-methods',
                },
                {
                    title: 'Carrier Services',
                    link: '/app/carrier-services',
                },
                {
                    title: 'Returns',
                    link: '/app/returns',
                },
                {
                    title: 'Processing',
                    link: '/app/processings',
                },

            ],
        },

        {
            title: 'Supply Management',
            icon: 'car-outline',
            expanded: false,
            children: [
                {
                    title: 'Suppliers',
                    link: '/app/suppliers'
                },
                {
                    title: 'Purchase Order',
                    link: '/app/purchase-orders',
                }
            ],
        },

        {
            title: 'Warehouse Management',
            icon: 'home-outline',
            expanded: false,
            children: [
                {
                    title: 'Warehouses',
                    link: '/app/warehouses',
                },
                {
                    title: 'Stock Transfers',
                    link: '/app/stock-transfers',
                },
                {
                    title: 'Stock Adjustments',
                    link: '/app/stock-adjustments',
                },

            ],
        },

        {
            title: 'Users',
            icon: 'people-outline',
            expanded: false,
            children: [
                {
                  title: 'Users',
                  link: '/app/users',
                },
                {
                    title: 'Teams',
                    link: '/app/teams',
                },
                {
                    title: 'Tasks',
                    link: '/app/tasks',
                },
                {
                    title: 'Agents',
                    link: '/app/agents',
                },
            ],
        },

        {
            title: 'Admin',
            icon: 'person-done-outline',
            expanded: false,
            children: [

                {
                    title: 'Roles',
                    link: '/app/roles',
                },

                {
                    title: 'Permissions',
                    link: '/app/permissions',
                },

            ],
        },

        {
            title: 'Customers',
            icon: 'person-outline',
            link: '/app/customers'
        },

        {
            title: 'Settings',
            icon: 'settings-2-outline',
            link: '/app/settings'
        },
        //{
        //    title: 'Shipments & Returns',
        //   group: true
        //},
  ]

  constructor() { }

  ngOnInit() {
  }

}
