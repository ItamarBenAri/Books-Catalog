import { Component } from '@angular/core';
import { BooksService } from '../../../services/books.service';
import { BookModel } from '../../../models/book.model';
import { CommonModule } from '@angular/common';
import { Title } from '@angular/platform-browser';
import { RouterLink } from '@angular/router';

@Component({
    selector: 'app-book-list',
    standalone: true,
    imports: [CommonModule, RouterLink],
    templateUrl: './book-list.component.html',
    styleUrl: './book-list.component.css'
})
export class BookListComponent {

    public books: BookModel[];
    public loadingStopped: boolean = false;

    public constructor(private title: Title, private booksService: BooksService) {
        title.setTitle("Books Catalog | Books");
    }

    public async ngOnInit(): Promise<void> {
        try {
            this.books = await this.booksService.getAllBooks();
            this.loadingStopped = true;
        }
        catch (err: any) {
            alert(err.message);
            this.loadingStopped = true;
        }
    }
}
