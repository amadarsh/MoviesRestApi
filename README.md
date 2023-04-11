# MoviesRestApi
Sample Rest API project with Mediatr Pattern and Clean Architecture

## Nuget packages used:
* EF core
* Pomelo EF core
* Automapper
* Mediatr
* Xunit
* Moq

## Project Details
1. Architecture: This code base incoporates clean architecture pattern, where the api project depends on the Core project abstractions.

2. Made use of the current industry standard CQRS ( Command Query Request Seggregation) pattern, and hence used Mediator pattern for implementation. 

3. Both clean architecture and CQRS  helps with design principles such as dependency inversion (allowing decoupling of modules), single responsibility, and separation of concerns.

4. EF Core with Mysql. Once the scaffolding was done, the Entities to the domain project, and kept it separate from the Persistence project, which helps with Persistence Ignorance. With minor changes, the same code can be used with a difference database.

5. All dependencies are on the abstractions, and that helps with loose coupling, scalability and effective maintenance.

6. The core application project has the bulk of the application logic. It has all the feature's (actor and film) command and query requests.
