# Hospital Management System (HMS) - Code Modification Competency - .NET 8 Web API

A modern healthcare management backend built with **ASP.NET Core Web API**, following **Clean Architecture** principles and the **Generic Repository Pattern**. This system manages the complex relationships between Patients, Doctors, Departments, Appointments, and Medical Records.

## 🚀 Key Features

* **Patient Management**: Track medical history, multiple contact numbers, and appointment frequency.
* **Doctor & Department Analytics**: Advanced LINQ queries to monitor doctor workloads and department-wise statistics.
* **Appointment Scheduling**: Conflict-aware scheduling linked to specific doctors and patients.
* **Medical Records**: Secure tracking of diagnoses and treatments.
* **Advanced Data Analysis**:
    * **Active Patients**: Identify patients with visits in the last 30 days.
    * **Daily Summaries**: Aggregate appointment counts per calendar day.
    * **Departmental Overviews**: Real-time stats on doctor count and total appointments handled.

## 🏗️ Architecture & Patterns

The project is designed with scalability and maintainability in mind:
* **Generic Repository Pattern**: Standardized CRUD operations to reduce code duplication.
* **Dependency Injection (DI)**: Decoupled services for better testability.
* **DTOs (Data Transfer Objects)**: Secure data exposure using specialized Read/Create/Update models.
* **Fluent API**: Precise database relationship configuration (One-to-Many, One-to-One).
* **Value Converters**: Storing complex C# types (like Phone Lists) efficiently in SQL Server.

## 🛠️ Tech Stack

* **Framework**: .NET 8 / ASP.NET Core
* **Database**: Microsoft SQL Server
* **ORM**: Entity Framework Core
* **Documentation**: Swagger UI (OpenAPI)
* **Validation**: Data Annotations & Custom Validation Attributes

## 📊 Database Schema

The system implements a relational schema including:
- **Patients** (1:M) **PatientPhones**
- **Departments** (1:M) **Doctors**
- **Patients** (1:1) **MedicalRecords**
- **Doctors/Patients** (M:M via) **Appointments**

## 🚦 Getting Started

### Prerequisites
* .NET 8 SDK
* SQL Server (LocalDB or Express)

### Installation
1. **Clone the repository**
   ```bash
   git clone [https://github.com/yourusername/hospital-management-system.git](https://github.com/yourusername/hospital-management-system.git)
