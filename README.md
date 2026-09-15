# LibraProject – POS Issue Tracking System

## Aim of the project

LibraProject is a web helpdesk application for tracking and managing technical problems on POS (Point of Sale) terminals.

Support staff can:

* **Manage POS terminals** – store information such as name, phone numbers, address, city, brand, model, connection type, opening hours and working days.
* **Report and manage issues** – create an issue for a POS terminal and classify it using a three-level hierarchy: **Type → Sub-type → Problem**.
* Set the issue priority to **Normal** or **Urgent**.
* Set the issue status to **New**, **Assigned**, **In progress** or **Pending**.
* Assign issues to a user group.
* Store a description, solution and memo for each issue.
* **View the audit log** – every issue creation or update generates a log entry visible in the issue details.
* **Manage users** – create, edit and view users with roles such as `admin` or `technical group`.
* **View the dashboard** – the home page displays the number of issues grouped by status.

Lists are displayed using server-side paginated, searchable and sortable **jQuery DataTables**.

Create, edit and details forms are loaded through AJAX and displayed inside Bootstrap modal dialogs.

## Technologies used

| Area                 | Technology                                                       |
| -------------------- | ---------------------------------------------------------------- |
| Language / Runtime   | C#, .NET Framework 4.8                                           |
| Web                  | ASP.NET MVC 5, Razor Views, IIS Express                          |
| Data Access          | Entity Framework 6.4, Code First, migrations, SQL Server LocalDB |
| Dependency Injection | Autofac 6.4 with Autofac.Mvc5                                    |
| Validation           | FluentValidation 8.6, FluentValidation.Mvc5, jQuery Validation   |
| Front End            | Bootstrap 3.4, jQuery 3.4, DataTables 2.0, Font Awesome          |

## Architecture

The solution follows a classic three-layer architecture:

```text
WebApp (Presentation)
        │
        ▼
BLL (Business Logic)
        │
        ▼
DAL (Data Access)
        │
        ▼
SQL Server
```

## Solution structure

```text
LibraProject2/
├── LibraProject.sln
│
├── DAL/
│   ├── ApplicationDbContext.cs
│   ├── Entities/
│   ├── Migrations/
│   ├── Common/
│   │   └── PasswordHasher.cs
│   └── App.config
│
├── BBL/
│   ├── Repositories/
│   ├── DTO/
│   │   ├── IssueDTO/
│   │   ├── PosDTO/
│   │   └── UserDTO/
│   ├── Common/
│   │   └── QueryPaginatedRequestDTO.cs
│   ├── Helpers/
│   │   └── DateTimeHelper.cs
│   └── ErrorHandlerService.cs
│
├── WebApp/
│   ├── Global.asax
│   ├── Global.asax.cs
│   ├── DIConfiguration.cs
│   ├── App_Start/
│   ├── Controllers/
│   ├── Helpers/
│   │   └── PaginationHelper.cs
│   ├── Views/
│   ├── Content/
│   ├── Scripts/
│   ├── fonts/
│   └── Web.config
│
├── Domain/
│
└── WebApplication1/
```
## Startup steps

### Prerequisites

* Windows
* Visual Studio 2019 or Visual Studio 2022
* ASP.NET and web development workload
* .NET Framework 4.8 Developer Pack
* SQL Server Express LocalDB or another SQL Server instance

## Demo users

### Administrator

```text
Login: crme1
Password: 1234
User type: admin
```

### Technical user

```text
Login: crme2
Password: 1234
User type: technical group
```

