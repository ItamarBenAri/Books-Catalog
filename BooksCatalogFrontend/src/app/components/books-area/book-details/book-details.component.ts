import { Component } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { BooksService } from '../../../services/books.service';
import { BookModel } from '../../../models/book.model';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
    selector: 'app-book-details',
    standalone: true,
    imports: [CommonModule, RouterLink],
    templateUrl: './book-details.component.html',
})
export class BookDetailsComponent {

    public book: BookModel;

    public constructor(
        private title: Title,
        private booksService: BooksService,
        private activatedRoute: ActivatedRoute,
        private router: Router
    ) { };

    public async ngOnInit() {
        try {
            const isbn = this.activatedRoute.snapshot.params["isbn"];
            this.book = await this.booksService.getOneBook(isbn);
            this.title.setTitle("Books Catalog | " + this.book.title);
        }
        catch (err: any) {
            alert(err.message)
        }
    }

    public async deleteBook() {
        try {
            const sure = confirm("Are you sure?");
            if (sure) {
                await this.booksService.deleteBook(this.book.isbn);
                alert("Book has been deleted successfully!");
                this.router.navigateByUrl("/books");
            };
        }
        catch (err: any) {
            alert(err.message)
        }
    }
}
