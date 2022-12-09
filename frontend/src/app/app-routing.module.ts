import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoriesComponent } from './features/categories/categories.component';
import { SpendingsComponent } from './features/spendings/spendings.component';

const routes: Routes = [
  { path: 'spendings', component: SpendingsComponent },
  { path: 'categories', component: CategoriesComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
