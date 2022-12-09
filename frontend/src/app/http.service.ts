import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category, Spending } from './app.types';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http: HttpClient) { }

  getCategories = () => {
    return this.http.get<Category[]>('https://localhost:7168/api/categories');
  }
  getSpendings = () => {
    return this.http.get<Spending[]>('https://localhost:7168/api/spendings');
  }
}
