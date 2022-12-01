import { Component, inject, OnInit } from '@angular/core';
import { InjectProductos } from '../services/app.services';
import { ICamiseta } from '../interface/Icamiseta';


@Component({
    selector: 'search-component',
    templateUrl: './app.search.component.html',
    styles: []
})

export class SearchComponent implements OnInit{

    public camisetas: ICamiseta[] = [];
    public camisetasFiltradas: ICamiseta[] = [];


    constructor(public injectProductos: InjectProductos) {
        this.camisetas = injectProductos.camisetas;
    }

    ngOnInit(): void {
        this.injectProductos.loadProducts()
            .subscribe();
    }

}