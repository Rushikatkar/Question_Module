# Question Management Module - Online Examination System

## 📌 Overview

This project is a **Question Management Module** for an **Online Examination System**, developed using **.NET Core MVC** and **Entity Framework Core**. The module allows administrators and teachers to manage exam questions, including creation, updating, deletion, and organization.

## 🎯 Features

- **CRUD Operations**: Create, Read, Update, and Delete questions.
- **Question Types**:
  - Multiple Choice Questions (MCQs) with multiple options.
  - True/False Questions.
  - Descriptive Questions with a model answer.
- **Categorization & Organization**:
  - Organize questions by **Subjects** and **Topics**.
  - Implement **tagging** for better searchability.
- **Answer & Options Handling**:
  - For MCQs, allow multiple options with correct answer selection.
  - For True/False, store correct answers.
  - For Descriptive, store a **model answer** for evaluation.
- **Database Integration**:
  - Uses **Entity Framework Core** with **SQL Server**.
  - Optimized database schema for scalability.
- **Frontend Development**:
  - Built using **ASP.NET Core MVC**.
  - Form validation for question creation and updates.
  - Integrated with backend API using AJAX.

## 📂 Folder Structure

```
📦 Question_Module
├── 📁 Controllers
│   ├── QuestionController.cs
├── 📁 Models
│   ├── QuestionViewModel.cs
│   ├── OptionViewModel.cs
├── 📁 Views
│   ├── Question
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   ├── Delete.cshtml
│   │   ├── Details.cshtml
├── 📁 wwwroot
│   ├── 📁 css
│   ├── 📁 js
├── appsettings.json
├── README.md
```

## 🚀 Setup & Installation

### Prerequisites

- **.NET 6.0 or later** installed
- **SQL Server**
- **Visual Studio 2022**
- **Postman** (optional for API testing)

### Steps to Run the Project

1. **Clone the Repository**
   ```sh
   git clone https://github.com/Rushikatkar/TenantSaaS.git
   cd Question_Module
   ```

2. **Configure the Database**
   - Open `appsettings.json` and update the database connection string.
   ```json
   "ConnectionStrings": {
      "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=QuestionDB;Trusted_Connection=True;"
   }
   ```

3. **Apply Migrations**
   ```sh
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

4. **Run the Application**
   ```sh
   dotnet run
   ```
   Open **http://localhost:5000** in your browser.

---

## 🔌 API Endpoints

| HTTP Method | Endpoint | Description |
|------------|----------|-------------|
| GET | `/api/Question` | Get all questions |
| GET | `/api/Question/{id}` | Get a question by ID |
| POST | `/api/Question` | Create a new question |
| PUT | `/api/Question/{id}` | Update a question |
| DELETE | `/api/Question/{id}` | Delete a question |

---

## 🖼️ Screenshots

### 🎯 Dashboard
![Dashboard](screenshots/dashboard.png)

### 📝 Create Question
![Create Question](screenshots/create-question.png)

### 📄 Question List
![Question List](screenshots/question-list.png)

### ✏️ Edit Question
![Edit Question](screenshots/edit-question.png)

---

## 👨‍💻 Developers

| Name | Role | Contact |
|------|------|---------|
| **Shivani Koli** | Backend Developer | 8624811988 |
| **Rushikesh Katkar** | Frontend Developer | 9146979348 |

## 📅 Project Images

![Home](https://github.com/user-attachments/assets/53dd11fd-4f06-4e82-9cd3-2bd99e1adfc1)

![Create](https://github.com/user-attachments/assets/9661cca7-526f-4cb9-834a-3506459f759b)

![Details](https://github.com/user-attachments/assets/0d8fc186-882f-4fe3-9d00-fde3c030cbb5)

![Edit](https://github.com/user-attachments/assets/135e361b-b409-4bae-bd45-c4e46555018d)

![Delete](https://github.com/user-attachments/assets/370bcf1c-ba9a-4356-b6e3-4987ecea025b)








---

## 📜 License

This project is **free to use** and open-source. Feel free to contribute!

