![build](https://github.com/amlsantos/URLShortener/actions/workflows/build.yml/badge.svg)
![test](https://github.com/amlsantos/URLShortener/actions/workflows/test.yml/badge.svg)

# URL Shortener

URL Shortener is a simple web application that shortens long URLs into shorter, more manageable links. This project provides a convenient way to generate short URLs for sharing on social media, emails, or any other communication channels.

## Project Highlights

- **Design Patterns**: The solution incorporates the Strategy Design Pattern, Decorator Design Pattern, the IOptions pattern and the IConfigureOptions pattern to provide a flexible and extensible structure.
- **Architecture Test:**: The project includes architectural tests to verify that the codebase adheres to the clean architecture. These tests ensure that dependencies are properly inverted, layers are isolated, and business logic is separated from infrastructure concerns.
- **SOLID Principles**: The codebase adheres to SOLID principles, promoting maintainability, scalability, and a clean architecture.


## Architecture

The URL Shortener system follows the principles of Clean Architecture, which promotes separation of concerns and maintainability by organizing the codebase into distinct layers:

- **Presentation Layer (Client Interface)**: The front-end interface where users input long URLs and generate short URLs. This interface may include a web application, browser extension, or API.
- **Application Core (Application)**: Contains the business logic and use cases of the URL Shortener system. It encapsulates the application's behavior and is independent of external frameworks and infrastructure details. It follows the CQRS (Command Query Responsibility Segregation) pattern for separating read and write operations.
- **Persistence Layer (Client Interface)**: Responsible for persisting URLs and user-related data. It includes the necessary infrastructure for interacting with the database, such as data access objects and repositories.
- **Infrastructure Layer (Client Interface)**: Provides implementations for external dependencies such as authentication, authorization, and token generation. It includes adapters and gateways to interact with external systems.
- **Domain Layer**: Contains the core business logic and domain entities of the application. It encapsulates the behavior and rules that govern the application's functionality, ensuring separation of concerns and maintainability.

## System Design

## 1. Shortening Process:
- User submits a long URL to the UrlShortener Controller, through the client interface.
- The Shortening Service, located in the Application Core, executes the shortening use case by generating a unique identifier for the long URL and mapping it to a shorter URL.
- The Shortening Service interacts with the Persistence Layer to store the mapping.

## 2. Redirection Process:
- When a user accesses a short URL, the request is directed to the UrlShortener Controller.
- The Redirection Service, located in the Application Core, executes the redirection use case by looking up the short URL in the Persistence Layer to retrieve the associated long URL.
- The user is redirected to the original long URL.

![image](https://github.com/amlsantos/URLShortener/assets/6472330/a0a71e1c-558d-4680-85b9-8ae636e7c33f)
> Jovanović, M. (2024, January 30). How to build a URL shortener with .NET - Milan Jovanović - Medium. Medium. https://medium.com/@MilanJovanovicTech/how-to-build-a-url-shortener-with-net-7a351f51541c

## Security Considerations
To handle high traffic and scalability requirements, the URL Shortener system can be designed with the following considerations:

- Caching: Implement caching mechanisms to reduce database load and improve response times for frequently accessed URLs.
- Asynchronous Processing: Handle URL shortening and redirection asynchronously to improve system responsiveness and throughput.

### Caching
To improve performance and reduce database load, the URL Shortener system utilizes caching mechanisms. In particular, the system leverages IMemoryCache, a built-in caching library for .NET, to store frequently accessed data in memory:
- IMemoryCache: The IMemoryCache interface provided by .NET Core is used to cache mapping between short URLs and original long URLs. By caching this data in memory, the system can retrieve frequently accessed URLs more efficiently, reducing database queries and improving response times.

By strategically caching data, the URL Shortener system can optimize performance and provide a better user experience, especially for high-traffic scenarios where frequent access to short URLs is expected.

## Scalability Considerations
Security is a critical aspect of the URL Shortener system to prevent misuse and protect user data:

- Authentication and Authorization: Implemention of user authentication and authorization mechanisms to control access to URL shortening and administration functionalities. We are using json web tokens.
- Input Validation: Validate user input to prevent injection attacks and ensure data integrity. We are using FluentValidation, as a popular .NET library, to validate user input and prevent injection attacks and ensure data integrity.
- HTTPS Encryption: Use HTTPS encryption to secure communication between clients and the server, preventing eavesdropping and man-in-the-middle attacks.

## Monitoring and Analytics
Monitoring and analytics are essential for maintaining system health and optimizing performance:

- Logging: Log system events, errors, and user activities for troubleshooting and auditing purposes. We are using Watchdog. A .net logging library, to log system events, errors, and user activities for troubleshooting.

```plaintext
URLShortener/
│
├── src/
│   ├── Application/             # Application core layer
│   │   ├── UseCases/            # Use cases
│   │   │   ├── Users/           # Use cases (for the user aggregate root)
│   │   │   │   ├── Commands/    # Command handlers
│   │   │   │   ├── Queries/     # Query handlers
│   │   │   ├── Urls/            # Use cases (for the url aggregate root)
│   │   │   │   ├── .../         # ...
│   │   ├── Behaviors/           # MediatR behaviors
│   │   ├── Exceptions/          # Custom application exceptions
│   │   └── Interfaces/          # Application, infrastucture and persistence interfaces
│   │
│   ├── Domain/                  # Domain layer
│   │   ├── Urls/                # Domain url entities and value objects
│   │   ├── Users/               # Domain user entities and value objects
│   │
│   ├── Infrastructure/          # Infrastructure layer
│   │   ├── Exceptions/          # Custom infrastucture exceptions
│   │   ├── Behaviors/           # MediatR behaviors
│   │   ├── Loggers/             # Console logging configuration and utilities (eg: watchdog)
│   │   └── Users/               # Services for generating tokens
│   │
│   ├── Persistence/            # Persistence layer
│   │   ├── Migrations/         # Database migrations
│   │   ├── Urls/               # Urls and cached repository. Mappings for EF ORM
│   │   ├── Users/              # Users repository. Mappings for EF ORM
│   │
│   ├── Presentation/           # Presentation layer (Client Interface)
│   │   ├── Urls/               # Urls controller and data contracts
│   │   ├── Users/              # Users controller and data contracts
│   │   ├── Middlewares/        # Exception middleware
│   │   ├── Configurations/     # DI configurations (CorsOptions && SwaggerGenOptions)
│   │   ├── .../                # ...
│   │
│
├── tests/                      # Test projects and files
│   ├── Architecture.Tests/     # Architecture tests
│
└── README.md                   # Project documentation
```

## Future Enhancements

- Customization: Allow users to customize short URLs with their preferred aliases or keywords.
- Expiration Policies: Implement expiration policies for short URLs to automatically expire and invalidate after a certain period.
- Rate Limiting: Enforce rate limiting to prevent abuse and protect against denial-of-service attacks.
- Load Balancing: Distribute incoming traffic across multiple servers to prevent overload and improve performance.
- Horizontal Scaling: Scale the system horizontally by adding more servers to handle increased traffic and load.
- Integration testing && unit testing: No time
- Health checks

## Getting Started

### Prerequisites

Make sure you have the following installed on your machine:

- [.NET](https://dotnet.microsoft.com/download)

### Clone the Repository

```bash
git clone https://github.com/amlsantos/URLShortener.git
cd URLShortener
```

### Build and Run Tests
```bash
dotnet build
dotnet test
```

### Run App
```bash
dotnet run --project .\src\Presentation\Presentation.csproj
```

### Logging

Go to http://localhost:5018/watchdog to use the log viewer:

- username: `admin`
- password: `admin`

### Authentication
You can use the 'login' endpoint, to generate an access token: 'UsersController/Login'.
You will need to use an already registered users email:
- `username@email.com`

## Acknowledgments

- Jovanović, M. (2024, January 30). How to build a URL shortener with .NET - Milan Jovanović - Medium. Medium. https://medium.com/@MilanJovanovicTech/how-to-build-a-url-shortener-with-net-7a351f51541c
