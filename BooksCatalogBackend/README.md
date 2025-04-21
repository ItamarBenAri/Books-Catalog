﻿```markdown
# 📚 Books Catalog API

A clean and robust ASP.NET Core Web API for managing a catalog of books using XML file storage.  
Built with extensibility, validation, and custom error handling in mind.

---

## 🛠️ Technologies

- **ASP.NET Core Web API**
- **C#**
- **System.Xml.Linq (XDocument)**
- **Custom Middleware**
- **Strong Input Validation**
- **Regex (ISBN validation)**

---

## 🔧 Features

- ✅ Add, edit, delete, and retrieve books
- 📄 Store and manage book data using an XML file (no database)
- 🧪 Strong validation for all input fields
- 🔥 Custom exception handling via centralized middleware
- ❌ Smart handling for invalid routes (`RouteNotFound`)
- 🧾 ISBN-10 and ISBN-13 format validation using Regex

---
```

```markdown
## 📂 Project Structure

BooksCatalog/
└── Src/
    ├── Assets/
    │   └── Files/
    │       └── Books.xml
    │
    ├── Controllers/
    │   └── BookController.cs
    │
    ├── Middleware/
    │   ├── ExceptionHandlingMiddleware.cs
    │   └── RouteNotFoundMiddleware.cs
    │
    ├── Models/
    │   └── BookModel.cs
    │
    ├── Services/
    │   └── BookService.cs
    │
    ├── appsettings.json
    └── Program.cs
```
---

```
## 📘 BookModel Fields

| Field     | Type          | Description                                |
|-----------|---------------|--------------------------------------------|
| `Isbn`    | `string`      | ISBN-10 or ISBN-13 (validated)             |
| `Title`   | `string`      | Required (2-50 chars)                      |
| `Author`  | `List<string>`| Required (at least one non-empty string)   |
| `Category`| `string`      | Required (2-50 chars)                      |
| `Language`| `string`      | Optional                                   |
| `Cover`   | `string`      | Optional                                   |
| `Year`    | `int`         | Must be <= current year                    |
| `Price`   | `decimal`     | Must be > 0 and <= 500                     |
```
---
```
## 🧪 Validation Logic

All input data is strictly validated. If any rule fails, the API returns a 400 Bad Request with a clear message.
```
---
```
## 🔗 Endpoints Example

| Method | Route                      | Description             |
|--------|----------------------------|-------------------------|
| GET    | `/Book/GetAllBooks`        | Get all books           |
| GET    | `/Book/GetOneBook/{isbn}`  | Get a book by ISBN      |
| POST   | `/Book/AddBook`            | Add a new book          |
| PUT    | `/Book/EditBook`           | Edit an existing book   |
| DELETE | `/Book/DeleteBook/{isbn}`  | Delete book by ISBN     |

---

## ⚙️ Configuration

Set the file path for the XML storage inside `appsettings.json`:

```json
{
  "AppSettings": {
    "BooksFilePath": "Data/books.xml"
  }
}
```

---

## 🧱 Error Handling

Custom exceptions are thrown and captured by `ExceptionHandlingMiddleware`, which returns appropriate HTTP status codes and messages. For example:

```json
{
  "error": "Isbn 1234567890 does not exist."
}
```

Routes not matched are handled by `RouteNotFoundMiddleware`, returning a 404 with a helpful message.

---

## 🚀 Getting Started

1. Clone the repository
2. Configure `appsettings.json` with the XML file path
3. Run the project with `dotnet run`
4. Use tools like Postman or Swagger to test the endpoints

---

## 📞 Contact

Maintained by **Itamar Ben Ari** - [etamar234@gmail.com](mailto:etamar234@gmail.com)
Feel free to reach out for feedback or contributions.
```