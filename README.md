# 🏗️ Bidding Management System

The **Bidding Management System** is a web-based application that streamlines the tendering process by enabling secure and efficient management of tenders, bids, and evaluations. It supports role-based workflows for procurement officers, evaluators, and bidders.

---

## 🚀 Features

### 🔹 Tender Management
- Create, update, delete, and publish tenders.
- Upload and manage tender-related documents.

### 🔹 Bid Management
- Submit bids to published tenders.
- Attach supporting documents to each bid.
- Track bid submissions.

### 🔹 Evaluation
- Score bids using customizable evaluation criteria.
- Automatically calculate total scores from individual assessments.

### 🔐 Authentication & Authorization
- Role-based access control (RBAC) with four roles:
  - `Admin`: Assign roles to other users.
  - `ProcurementOfficer`: Manage tenders.
  - `Evaluator`: Evaluate and score bids.
  - `Bidder`: Submit bids and documents.
- JWT-based authentication for secure API access.

---

## 🛠️ Technologies Used

- **.NET 8.0** – ASP.NET Core Web API  
- **Entity Framework Core 9.0.3** – ORM with SQL Server  
- **CQRS** – Implemented using MediatR  
- **AutoMapper** – Object mapping between layers  
- **BCrypt.Net** – Secure password hashing  
- **Swagger (Swashbuckle)** – API documentation

---

## 🛆 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)  
- [SQL Server](https://www.microsoft.com/en-us/sql-server)  
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or compatible IDE  
- [Postman](https://www.postman.com/) (optional, for API testing)

---

## 🚧 Getting Started

### 1. 📥 Clone the Repository

```bash
git clone https://github.com/AbdulazizAlzamil/BiddingManagementSystem.git
cd BiddingManagementSystem
```

### 2. 🔧 Configure the Application

Open `appsettings.json` in the `BiddingManagementSystem.Api` project and update the following:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=BiddingManagementSystem;Trusted_Connection=True;MultipleActiveResultSets=true"
},
"Jwt": {
  "SecretKey": "YOUR_SECRETKEY",
  "Issuer": "https://localhost:7278/",
  "Audience": "https://localhost",
  "ExpireMinutes": 60
}
```

### 3. 🗒️ Set Up the Database

- Open **Package Manager Console**.
- Set the **default project** to `BiddingManagementSystem.Infrastructure` (using the dropdown at the top).
- Run the following command to apply migrations:

```powershell
Update-Database
```

### 4. 👤 Create Initial Admin User

> ⚠️ **Important:** You need to manually create the initial admin user in the database (e.g., via SQL Server Management Studio or a migration seed).
>
> The admin user should be inserted into the `Users` table with the role `Admin`.
>
> Once logged in, the admin can assign roles (`ProcurementOfficer`, `Evaluator`, `Bidder`) to other registered users through the provided API endpoints.

### 5. ▶️ Run the Application

Start the application from the `BiddingManagementSystem.Api` project in Visual Studio or use the .NET CLI:

```bash
dotnet run --project BiddingManagementSystem.Api
```

### 6. 🌐 Explore the API

Once the app is running, open your browser and navigate to:

```
https://localhost:7278/swagger
```

to access the Swagger UI and test available endpoints.

---

## 📌 Notes

- Ensure your SQL Server is running and accessible.
- You may use Postman or Swagger to test login and role-based endpoints.
- Each role has different access privileges.
- Admin users have the ability to manage roles for all other users.

---
