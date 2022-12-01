import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { ICamiseta } from "../interface/Icamiseta";

@Injectable()
export class InjectProductos {

    constructor(private http: HttpClient) {

    }

    public camisetas: ICamiseta[] = []


    loadProducts(): Observable<void>{
        return this.http.get<ICamiseta[]>("/api/search")
            .pipe(map(data => {
                this.camisetas = data;
                return;
            }));
    }
}