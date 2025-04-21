import { Component } from '@angular/core';
import { BookModel } from '../../../models/book.model';
import { ActivatedRoute, Router } from '@angular/router';
import { BooksService } from '../../../services/books.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-upsert-book',
    standalone: true,
    imports: [CommonModule, FormsModule],
  templateUrl: './upsert-book.component.html'
})
export class UpsertBookComponent {

    public book: BookModel = new BookModel();
    public isEditMode = false;
    public authors: string[] = []; // parsed array
    public authorsInput = ''; // string from the input
    public currentYear = new Date().getFullYear();

    public constructor(
        private route: ActivatedRoute,
        private booksService: BooksService,
        private router: Router,
        private title: Title
    ) { }

    public async ngOnInit(): Promise<void> {
        const isbn = this.route.snapshot.params["isbn"];
        if (isbn) {
            this.isEditMode = true;
            this.title.setTitle("Books Catalog | Edit");
            const bookFromServer = await this.booksService.getOneBook(isbn);
            this.book = bookFromServer;
            this.authorsInput = this.book.author?.join(", ");
            this.authors = bookFromServer.author;
        }
        else this.title.setTitle("Books Catalog | Add");
    }

    public onAuthorChange(): void {
        this.authors = this.authorsInput
            .split(',')
            .map(a => a.trim())
            .filter(a => a.length > 0);
        this.book.author = this.authors;
    }

    public async send(): Promise<void> {
        if (this.authors.length === 0) {
            alert("At least one author is required.");
            return;
        }

        try {
            await this.booksService.upsertBook(this.book, this.isEditMode);
            if (this.isEditMode) {
                alert("Book updated successfully.");
            } else {
                alert("Book added successfully.");
            }
            this.router.navigateByUrl("/books");
        } catch (err: any) {
            alert("Error: " + err.message);
        }
    }
}
