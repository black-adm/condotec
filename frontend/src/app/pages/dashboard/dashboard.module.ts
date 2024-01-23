import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';
import { SidebarComponent } from 'src/app/components/sidebar/sidebar.component';
import { OrdersTableComponent } from 'src/app/components/orders-table/orders-table.component';

@NgModule({
  declarations: [
    DashboardComponent,
    SidebarComponent,
    OrdersTableComponent,
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule
  ]
})
export class DashboardModule { }
