import { Component, OnInit } from '@angular/core';
import { Spending } from 'src/app/app.types';
import { HttpService } from 'src/app/http.service';

@Component({
  selector: 'app-spendings',
  templateUrl: './spendings.component.html',
  styleUrls: ['./spendings.component.scss']
})
export class SpendingsComponent implements OnInit {

  spendings: Spending[] = [];

  constructor(private service: HttpService) { }

  ngOnInit(): void {
    this.service.getSpendings()
      .subscribe(data => this.spendings = data)
  }

}
