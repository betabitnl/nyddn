import { ProductListComponent } from './../components/product-list.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';


export { ProductListComponent };

@NgModule({
  bootstrap: [ProductListComponent],
  declarations: [ProductListComponent],
  imports: [BrowserModule, HttpModule],
  providers: []
})
export class MainModule { }
