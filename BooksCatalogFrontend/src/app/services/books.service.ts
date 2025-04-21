import { Injectable } from '@angular/core';
import { BookModel } from '../models/book.model';
import { HttpClient } from '@angular/common/http';
import { appConfig } from '../app.config';
import { firstValueFrom } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class BooksService {

    public constructor(private http: HttpClient) { }

    public async getAllBooks(): Promise<BookModel[]> {
        const observable = this.http.get<BookModel[]>(appConfig.booksCatalogUrl + "GetAllBooks");
        const books = await firstValueFrom(observable);
        return books;
    }

    public async getOneBook(isbn: string): Promise<BookModel> {
        const observable = this.http.get<BookModel>(appConfig.booksCatalogUrl + "GetOneBook/" + isbn);
        return await firstValueFrom(observable);
    }

    public async upsertBook(book: BookModel, isEditMode: boolean): Promise<void> {
        if (!book.cover?.trim()) {
            delete book.cover;
        };
        const headers = { 'Content-Type': 'application/json' };
        const url = appConfig.booksCatalogUrl + (isEditMode ? "EditBook" : "AddBook");
        const observable = isEditMode
            ? this.http.put<BookModel>(url, book, { headers })
            : this.http.post<BookModel>(url, book, { headers });
        await firstValueFrom(observable);
    }

    public async deleteBook(isbn: string): Promise<void> {
        const observable = this.http.delete(appConfig.booksCatalogUrl + "DeleteBook/" + isbn);
        await firstValueFrom(observable);
    }
}
