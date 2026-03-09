# Todo API (Clean Architecture)

Controller-based ASP.NET Core Web API implementing:
- Clean architecture separation (Domain / Application / Infrastructure / WebApi)
- JWT authentication
- Global exception handling middleware
- FluentValidation validators and validation middleware handling

## Run
```bash
dotnet restore
dotnet run --project src/TodoApi.WebApi
```

## Endpoints
- `POST /api/auth/login`
- `GET /api/todos` (auth)
- `POST /api/todos` (auth)
- `PUT /api/todos/{id}` (auth)
- `DELETE /api/todos/{id}` (auth)
