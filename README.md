# CleaningServiceAPI

```bash
dotnet new webapi -n CleaningServiceAPI
cd CleaningServiceAPI
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Swashbuckle.AspNetCore
```

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```

```bash
 API Endpoints
Users (/api/users)

POST / - Create user
GET /{id} - Get user details
PUT /{id} - Update user
DELETE /{id} - Delete user

Bookings (/api/bookings)

POST / - Create booking
GET /user/{userId} - Get user bookings
GET /cleaner/{cleanerId} - Get cleaner schedule
POST /assign-cleaner - Assign cleaner to booking
POST /complete - Mark booking complete
GET /available-cleaners - Find available cleaners

Subscriptions (/api/subscriptions)

POST / - Create subscription
GET /user/{userId} - Get user subscriptions
PUT /{id}/status - Update subscription status
POST /{id}/generate-bookings - Generate recurring bookings
GET /plans - Get subscription plans
```
