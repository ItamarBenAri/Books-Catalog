import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';

@Component({
    selector: 'app-page404',
    standalone: true,
    imports: [],
    templateUrl: './page404.component.html',
    styleUrl: './page404.component.css'
})
export class Page404Component implements OnInit {

    public constructor(private title: Title) { }

    public ngOnInit(): void {
        this.title.setTitle("Page Not Found");
    }

}

