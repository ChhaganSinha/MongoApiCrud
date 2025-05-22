📦 ASP.NET 8 Web API with MongoDB using Entity Framework
🧾 Overview
This project is a RESTful Web API built using ASP.NET Core 8, integrated with MongoDB as the NoSQL database. It uses Entity Framework Core abstractions or services to interact with MongoDB through a structured, service-oriented architecture.

🔧 Project Configuration
1. Prerequisites
.NET 8 SDK

MongoDB (installed and running locally or remotely)

Visual Studio 2022+ or VS Code

Optional: Postman or Swagger for testing API endpoints

2. App Settings
Define MongoDB configuration in appsettings.json:

json
Copy
Edit
"MongoDbSettings": {
  "ConnectionString": "mongodb://localhost:27017",
  "DatabaseName": "YourDatabaseName"
}
These settings should be mapped to a strongly typed POCO class using IOptions<T>.

3. Folder Structure
bash
Copy
Edit
/YourProject
│
├── Controllers/        # API controllers
├── Models/             # Data models / documents
├── DataContext/               # MongoDB context or database service
├── Services/           # Business logic services
├── appsettings.json    # Configuration file
├── Program.cs          # Entry point and dependency injection
├── README.md           # Project documentation
4. Service Registration
Configure services like MongoDB context, custom services, and settings binding in Program.cs or Startup.cs (if used).

🚀 Getting Started
1. Clone the Repository
bash
Copy
Edit
git clone https://github.com/ChhaganSinha/MongoApiCrud.git
cd your-repo-name
2. Run MongoDB
Make sure MongoDB is running on the default port (27017) or update the connection string accordingly.

3. Update Configuration
Modify the appsettings.json file with your MongoDB URI and database name.

4. Run the Project
Use the following command:

bash
Copy
Edit
dotnet run
Once started, access Swagger UI at:

bash
Copy
Edit
https://localhost:<port>/swagger
🧪 API Endpoints (Sample)
Method	Endpoint	Description
GET	/api/items	Get all items
GET	/api/items/{id}	Get item by ID
POST	/api/items	Create a new item
PUT	/api/items/{id}	Update an item
DELETE	/api/items/{id}	Delete an item

📚 Future Enhancements
JWT Authentication

Role-based Authorization

Logging & Error Handling Middleware

Unit and Integration Tests

Docker Support

🧑‍💻 Author
Chhagan Sinha

📄 License
This project is licensed under the MIT License - see the LICENSE file for details.
