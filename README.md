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

#### 🔶   Home Page
> <img width="1418" height="949" alt="Home Page" src="https://github.com/user-attachments/assets/3b22a4a1-505b-4669-9502-3aefffb759d9" />

#### 🔶   Events Dashboard
> <img width="1392" height="950" alt="Event Dashboard" src="https://github.com/user-attachments/assets/70bc9e80-c5c1-4c2f-bc20-cf88e2e52474" />

#### 🔶   Create New Event
> <img width="976" height="669" alt="Create New event" src="https://github.com/user-attachments/assets/7a80f976-cc55-4ef3-a604-c0fc29470748" />

#### 🔶   Single Event Details
> <img width="1327" height="940" alt="Single Event" src="https://github.com/user-attachments/assets/018ed1bc-0d63-4890-b99e-a5a56f827a54" />
> <img width="1343" height="934" alt="Seperate Event details" src="https://github.com/user-attachments/assets/ea1b8e42-6932-4f60-a8d2-32c6b7ab0e74" />

#### 🔶   Create New Member
> <p align="center">
>  <img src="https://github.com/user-attachments/assets/cb835ae3-ad33-4d03-bf21-7bb78f59eefa" width="500"/>
> </p>

#### 🔶   Add Cost Items
> <img width="1386" height="937" alt="Add Cost Item" src="https://github.com/user-attachments/assets/d9882ede-3545-4f04-9ec1-fb0f59d59dd0" />

#### 🔶   All Events Details
> <img width="1354" height="942" alt="All Event total Member and details" src="https://github.com/user-attachments/assets/0ef9d030-ad21-44ad-a6b6-5112c06b04f3" />

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
