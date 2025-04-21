# 📚 Books Catalog

A full-featured web application for managing a catalog of books, including functionality to **add**, **edit**, **delete**, and **browse** books with detailed metadata. Built using **Angular** for the frontend and **ASP.NET Core Web API** for the backend.

## ✨ Features

- Add new books with details: ISBN, title, author(s), category, cover, language, year, and price.
- Edit existing book entries.
- Delete books from the catalog.
- View the catalog in a user-friendly UI.
- Form validation with real-time feedback.
- Shared form component for add/edit logic.
- Optional cover input.
- Backend API integration with file support via `FormData`.

## 🧰 Tech Stack

### Frontend
- [Angular](https://angular.io/)
- HTML5 + CSS3 (with Bootstrap for styling)
- TypeScript
- Angular Forms + Form Validation

### Backend
- [ASP.NET Core Web API](https://learn.microsoft.com/en-us/aspnet/core/web-api/)
- C#

## 🚀 Setup & Run

### Prerequisites

- Node.js & Angular CLI
- .NET 6 SDK or later

### 1. Clone the repo

```bash
git clone https://github.com/itamarBenAri/books-catalog-frontend.git
cd BooksCatalog
```

### 2. Run the Backend

```bash
cd BooksCatalogBackend
dotnet restore
dotnet run
```

API will be available at: `http://localhost:5109/api/Book`

### 3. Run the Frontend

```bash
cd BooksCatalogFrontend
npm install
ng serve
```

Frontend will run at: `http://localhost:4200`

## 🧠 Design Notes

- The `UpsertBookComponent` is reused for both adding and editing books.
- Form validation is enforced both client-side and server-side.
- Authors are entered as comma-separated values and parsed into an array.
- Optional fields like `cover` can be omitted without errors.

## 📞 Contact

Maintained by **Itamar Damari Ben Ari**  
Feel free to reach out for feedback or contributions.
