import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/app.types';
import { HttpService } from 'src/app/http.service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.scss']
})
export class CategoriesComponent implements OnInit {

  categories: Category[] = [];

  constructor(private service: HttpService) { }

  ngOnInit(): void {
    this.service.getCategories()
      .subscribe(data => this.categories = data)
  }

}
