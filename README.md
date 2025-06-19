# Hexagonal Architecture Template

This project is a template demonstrating how `Hexagonal Architecture` can be structured and organized in .Net environment. It was created solely for
illustrative purposes and is not intended to represent real-world application patterns or business cases. Certain components are
either unimplemented or significantly simplified to keep the focus on architectural concepts rather than on domain logic or full 
application functionality.

Before reviewing the project structure, it's worth briefly introducing what Hexagonal Architecture is:

[Hexagonal Architecture](https://en.wikipedia.org/wiki/Hexagonal_architecture_(software)), also known as the Ports and Adapters pattern, is a software architectural style that emphasizes the 
separation of concerns between the core business logic and external systems. It promotes a clear distinction between the
application's domain and the infrastructure or user interfaces, making the system easier to maintain, test, and adapt to change.

Now we can move on.

### The project has the following folder structure:

```
+---src
|   +---ApplicationSetup
|   +---Core
|   |   +---Hexagonal.Application
|   |   |   +---Commands
|   |   |   +---Handlers
|   |   |   |   +---Commands
|   |   |   |   \---Queries
|   |   |   +---Mappings
|   |   |   +---Ports
|   |   |   |   +---Primary
|   |   |   |   \---Secondary
|   |   |   \---Queries
|   |   \---Hexagonal.Domain
|   |       +---Constants
|   |       +---Entities
|   |       +---Exceptions
|   |       +---obj
|   |       \---Options
|   +---Infrastructure
|   |   +---Hexagonal.Adapter.Auth
|   |   |   \---Services
|   |   +---Hexagonal.Adapter.DetailedNotification
|   |   |   \---Services
|   |   +---Hexagonal.Adapter.InMemory
|   |   |   +---Data
|   |   |   \---Repositories
|   |   +---Hexagonal.Adapter.Postgres
|   |   |   +---Data
|   |   |   \---Repositories
|   |   \---Hexagonal.Adapter.SimpleNotification
|   |       \---Services
|   \---UI
|       \---Hexagonal.Adapter.Rest
|           +---Endpoints
|           \---Properties
\---tests
    +---Core
    |   \---Hexagonal.Application.Tests
    +---Infrastructure
    |   +---Hexagonal.Adapter.Auth.Tests
    |   +---Hexagonal.Adapter.DetailedNotification.Tests
    |   +---Hexagonal.Adapter.InMemory.Tests
    |   +---Hexagonal.Adapter.Postgres.Tests
    |   \---Hexagonal.Adapter.SimpleNotification.Tests
    \---UI
        \---Hexagonal.Adapter.Rest.Tests
```
### Hexagonal Architecture Diagram
![](https://github.com/Nazg0r/KPI-3-Exam/blob/main/Docs/diagram.png)

This diagram illustrates the layers that make up the architecture and how they interact with each other. At the very center of the
system is the Domain layer. Surrounding it is the Application layer, which is also considered part of the core of the system.

The core communicates with the outside world through `ports` — abstractions that define how data flows in and out of the
application. There are two types of ports:  Primary and Secondary. `Primary Ports` (also known as driving ports), which are used by
the UI or external input adapters to trigger application behavior. `Secondary Ports` (also known as driven ports), which define
interfaces the application depends on to access external systems like databases, authentication providers, or messaging services.

Adapters are responsible for implementing these ports. They are positioned at the edges of the architecture and are categorized into two groups:

- On the left (UI side), we see adapters such as the `REST Adapter`, which interact with the application through primary ports. In this case, the primary port is the Mediator, which provides a universal contract for UI-facing adapters. Other adapters could include CLI, gRPC, or message consumers.
- On the right (Infrastructure side), we see adapters such as `Auth Adapter`, `InMemory Adapter`, `Postgres Adapter`, and `Notification Adapters`, which implement the secondary ports defined by the application to provide actual functionality.

### Patterns that can be used in Hexagonal Architecture

#### Adapter 
The Adapter pattern is fundamental to Hexagonal Architecture. It allows the application to interact with external systems through well-defined interfaces (ports).

#### Dependency Injection 
Dependency Injection is another foundational principle in Hexagonal Architecture. It allows the injection of dependencies into ports or use cases and this feature promotes testability, modularity, and the ability to easily swap adapters or implementations.

#### CQRS 
The CQRS pattern separates read and write operations into distinct models. Commands are used to change state, while queries are used to retrieve data. This fits naturally into the architecture by organizing use cases in the application layer and improving scalability, clarity, and separation of concerns.

#### Mediator 
The Mediator pattern acts as a centralized entry point for application logic. It allows adapters to invoke use cases through a unified interface, reducing direct dependencies and coupling between layers.

#### Repository 
The Repository pattern abstracts data access and is typically implemented within secondary adapters. It provides a consistent interface to the domain layer while hiding the underlying data source.

#### Unit of Work 
The Unit of Work pattern coordinates operations across multiple repositories within a single transaction. It ensures atomicity and consistency of data changes.

#### Factory 
The Factory pattern encapsulates object creation, often used in the domain or application layer. It can be helpful for creating complex or runtime-determined objects such as authentication strategies or validators.

#### Strategy 
The Strategy pattern is useful for defining and managing different implementations of external services.

#### Observer 
The Observer pattern enables event-driven communication. Components can subscribe to and react to domain events without tight coupling. 

The list of patterns presented here is not exhaustive, there are many other design patterns that can be applied within Hexagonal Architecture.
However, it's important to remember that patterns should not be used blindly. A good developer should always evaluate whether a specific pattern
addresses a real problem in the given context and provides meaningful value in terms of maintainability, clarity, or flexibility.
