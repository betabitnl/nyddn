import { ProductService } from './product.service';
import { Component, OnInit } from '@angular/core';
import 'rxjs/add/operator/catch';

@Component({
  selector: 'product-list-app',
  templateUrl: 'product-list.template.html',
  styleUrls: ['product-list.style.scss'],
  providers: [ProductService]
})
export class ProductListComponent implements OnInit {
  public products: any[] = [];
  public loading: boolean = true;
  public errorLoading: boolean = false;


  constructor(private productListService: ProductService) {

  }

  ngOnInit(): void {
    this.reload();
  }

  reload(): void {
    this.loading = true;
    this.errorLoading = false;
    this.productListService.getProducts()
      .subscribe((p) => {
        this.products = p;
        this.loading = false;
      }, (err) => {
        this.errorLoading = true;
      });
  }
}
