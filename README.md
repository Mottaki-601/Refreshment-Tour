<img width="1983" height="793" alt="cover" src="https://github.com/user-attachments/assets/2ce65df0-a72e-4afd-b151-c8c946619903" />

# 🛩️ Tour Management System

![.NET](https://img.shields.io/badge/.NET-ASP.NET%20Core-blue)
![EF Core](https://img.shields.io/badge/ORM-Entity%20Framework%20Core-5C2D91)
![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-red)
![Status](https://img.shields.io/badge/Status-Production--Ready-success)
![License](https://img.shields.io/badge/License-MIT-green)

A modern, production-ready **ASP.NET Core MVC web application** for managing **tour events, members, and expenses** with real-time financial tracking and clean UI.

---

## 🔍 Project Overview

This system allows users to:

- Create and manage tour events
- Add members with image upload
- Track payment status (Paid / Unpaid)
- Manage event-based costs
- View real-time financial summary (Collection, Cost, Balance)

---

## ✨ Key Features

- 📅 Event Management  
- 👥 Member Management (CRUD + Image Upload)  
- 💳 Payment Tracking System  
- 💸 Cost Management (Qty × Unit calculation)  
- 📊 Financial Dashboard (Total Collection, Cost, Net Balance)  
- 📈 Cost Analytics (Max, Min, Average)  
- 🔁 Event-wise Data Filtering  
- 🔐 Secure Form Handling (AntiForgeryToken)  

---

## 🧩 Tech Stack

- **Frontend:** HTML, CSS, Bootstrap  
- **Backend:** ASP.NET Core MVC (.NET)  
- **Database:** SQL Server  
- **ORM:** Entity Framework Core  
- **Database Logic:** Stored Procedures  

---

## 🏗️ Architecture

- MVC (Model-View-Controller) pattern  
- Clean separation of concerns  
- Relational database with foreign key constraints  

### Entity Relationship
- Event (1) ──── (Many) Members
- Event (1) ──── (Many) Costs

---

## ⚙️ Installation & Setup

### 1. Clone the repository:
 - ```bash
   git clone https://github.com/Mottaki-601/Refreshment-Tour.git
   cd Refreshment-Tour
   ```
### 2. Open the project in Visual Studio 
   - Open the solution file (.sln)
### 3. Configure database 
Update connection string in:
   - appsettings.json
### 4. Setup Database (Important)
   - 🔴*This project uses a hybrid approach (EF Core + Stored Procedures)*

### 5. Run migrations / ensure database is ready
 - ```bash
   Add-Migration ScriptA 
   Update-Database 
     ```
### 6. Run the following SQL files:
   - **`sp.sql`** (Stored Procedures)
### 7. Run the Application  
   - Press:
Ctrl + F5
     

---

## 🔁 Application Workflow

1. Create Event  
2. Open Event Details  
3. Add Members (linked with Event)  
4. Add Costs  
5. View Financial Summary  

---

## 🧠 Core Logic

- **Net Balance = Total Collection − Total Cost**
- **Cost Total = Quantity × Unit Price**
- Event-wise filtering ensures clean data separation

---

## 🛡️ Validation & Security

- Server-side validation using ModelState  
- Required field validation  
- Secure form submission using AntiForgeryToken  
- Image upload handling  

---

## 📸 Screenshots



---

## 📌 Future Improvements

- Authentication & Authorization  
- Dashboard charts (Chart.js)  
- Export to PDF / Excel  
- Advanced search & filtering  
- Mobile optimization  

---

## 👨‍💻 Author

**Mottaki Billah**    
GitHub: https://github.com/Mottaki-601  
Email: mottakib0@gmail.com  

---

## ⭐ For Recruiters

This project demonstrates:

- Strong ASP.NET Core MVC knowledge  
- Database design with relationships  
- Stored Procedure integration  
- Real-world problem solving  
- Clean UI/UX implementation  

---

## 📄 License

This project is licensed under the MIT License.

---

## ⭐ Support

If you like this project:

- Star ⭐ the repository  
