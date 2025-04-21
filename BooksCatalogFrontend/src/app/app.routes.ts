import { Routes } from '@angular/router';
import { Page404Component } from './components/layout-area/page404/page404.component';
import { BookListComponent } from './components/books-area/book-list/book-list.component';
import { BookDetailsComponent } from './components/books-area/book-details/book-details.component';
import { UpsertBookComponent } from './components/books-area/upsert-book/upsert-book.component';

export const routes: Routes = [
    { path: "books", component: BookListComponent },
    { path: "books/details/:isbn", component: BookDetailsComponent },
    { path: "books/book/addBook", component: UpsertBookComponent },
    { path: "books/book/editBook/:isbn", component: UpsertBookComponent },
    { path: "", redirectTo: "/books", pathMatch: "full" },
    { path: "**", component: Page404Component }
];
