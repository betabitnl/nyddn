import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class ProductService {
    constructor(private http: Http) {
    }

    getProducts():Observable<any>{
        return this.http.get(`/api/Products`)
        .map((res)=> res.json() as any[]);
    }
}