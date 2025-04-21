```markdown
# 📚 Books Catalog Solution

A full-featured, cleanly structured book catalog system built with **Angular** for the frontend and **ASP.NET Core Web API** for the backend.  
The system allows users to manage books with detailed metadata, using XML-based storage on the server side and a user-friendly UI on the client side.
```
---
```
## 📦 Solution Structure

BooksCatalog/
├── BooksCatalogBackend/      # ASP.NET Core Web API project
│   ├── Controllers/
│   ├── Middleware/
│   ├── Models/
│   ├── Services/
│   └── Assets/Files/Books.xml
│
├── BooksCatalogFrontend/     # Angular frontend project
│   ├── src/app/
│   ├── src/assets/
│   ├── angular.json
│   └── package.json
│
├── BooksCatalogDal/          # Dal
│   ├── Dal.cs
│   └── DalService.cs
│
├── BooksCatalogModels/       # Solution models
│   ├── BookModel.cs
│   └── ClientExeptions.cs
│
└── BooksCatalog.sln          # Solution file
```
---
```
## ✨ Main Features

- ✅ Full CRUD functionality for books (create, read, update, delete)
- 🔒 Strong input validation (client + server)
- 🧠 ISBN format validation (Regex for ISBN-10 and ISBN-13)
- 🔥 Centralized custom error handling in the backend
- ❌ Smart handling for invalid routes
- 📄 XML-based persistent storage (no database needed)
- 🔁 Reusable form component for adding/editing books
- 📐 Responsive, accessible UI built with Angular + Bootstrap
```
---
```
## 🧰 Tech Stack

### Backend
- ASP.NET Core Web API
- C#
- System.Xml.Linq (XDocument)
- Custom Middleware for error handling

### Frontend
- Angular
- TypeScript
- Angular Reactive Forms
- Bootstrap (CSS framework)
```
---
## 🚀 Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download) or later
- [Node.js](https://nodejs.org/) & [Angular CLI](https://angular.io/cli)

### 1. Clone the repository

```bash
git clone https://github.com/itamarBenAri/Books-Catalog.git
cd books-catalog
```

### 2. Run the Backend

```bash
cd BooksCatalogBackend
dotnet restore
dotnet run
```

> 📡 API available at: `http://localhost:5109/api/Book`

### 3. Run the Frontend

```bash
cd BooksCatalogFrontend
npm install
ng serve
```

> 🌐 App available at: `http://localhost:4200`

---

## 🔗 API Endpoints (Sample)

| Method | Endpoint                    | Description             |
|--------|-----------------------------|-------------------------|
| GET    | `/Book/GetAllBooks`         | Retrieve all books      |
| GET    | `/Book/GetOneBook/{isbn}`   | Get book by ISBN        |
| POST   | `/Book/AddBook`             | Add a new book          |
| PUT    | `/Book/EditBook`            | Edit an existing book   |
| DELETE | `/Book/DeleteBook/{isbn}`   | Delete a book by ISBN   |

---

## 🛡️ Validation & Error Handling

- **Client-side**: Real-time Angular form validation with detailed feedback.
- **Server-side**: Input validated against strict rules.
- **Middleware**: Custom middleware catches and formats all exceptions.
- **404 Middleware**: Handles unmatched routes with custom error message.

---

## ⚙️ Backend Configuration

Set the file path for the books XML file inside `BooksCatalogBackend/appsettings.json`:

```json
{
  "AppSettings": {
    "BooksFilePath": "Assets/Files/Books.xml"
  }
}
```

---

## 📞 Contact

Maintained by **Itamar Ben Ari** - [etamar234@gmail.com](mailto:etamar234@gmail.com)  
Feel free to reach out for feedback, questions, or contributions.

---