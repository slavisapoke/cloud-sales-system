# ☁️ Cloud Sales System – Technical assignment

## 📝 Assignment Overview

This solution was developed as part of a technical assignment for Crayon. The goal was to implement a simplified **cloud sales system** that allows customers to manage software licenses offered by a Cloud Computing Provider (CCP).

### 📌 Functional Requirements

The system should enable customers to:
- 🔍 View a list of their own accounts
- 🛍 View available software services provided by CCP (mocked)
- 📦 Order software licenses for specific accounts (mocked CCP API)
- 📄 View purchased software licenses per account
- 🔁 Change the quantity of licenses in an active subscription
- ❌ Cancel a purchased software license
- 📆 Extend the validity of a license

---

## ⚙️ Technical Implementation

This solution was designed with microservice architecture principles using **.NET Core** and **Docker**. Here's a summary of the technical choices and structure:

### 🧱 Technology stack

- **.NET Core Web API**: *.NET CORE 8* Main gateway exposing REST endpoints to manage customers, accounts, products, and software licenses.
- **Microservices**: *.NET CORE 8* Separated concerns across services (e.g., account service, software service, licensing service, products service).
- **Component interaction - Choreography**: Used for clear separation of concerns and maintainable structure - implemented using *MassTransit with RabbitMQ*
- **Workers**: *.NET CORE 8* Heavy lifting components - currently not implemented but MUST be part of the system: DocumentProcessing, OrderProcessing, EmailProcessing, NotificationRouter)
- **Mocked External API**: CCP integration is simulated using in-memory responses to mimic real-world scenarios - implemented using MockHttpMessageHandler from nuget *RichardSzalay.MockHttp* 
- **Persistance**: Database of choice is *postgres*
- **Distributed caching** - Implmented using *redis/ZiggyCreatures.FusionCache*

### 📦 Containerization

- **Docker**: Each service is containerized. 

### 🧪 Testing

- **Integration tests** written using xUnit and WebApplicationFactory to test API endpoints.
- **Unit tests** Service mocking - implemented with *Moq*

🧰 Common Functionality & Reusable Libraries

In microservices architecture, several shared components should be extracted into a shared NuGet package or common library to improve reuse across services.

The following components are placed in separate Common library **Poke.CloudSalesSystem.Common** but are good candidates for extraction into separate libraries or NuGet package:
- **Cache** - Redis, FusionCache
- **Contract** - Common contracts used by each microservice
- **Database** - Db abstraction - base entities, base DbContext...
- **Healthcheck** - Healthckeck configuration and service extensions
- **Helpers** - Common help libraries (Validation, String manipulations...)
- **Message Bus** - Common configuration of message bus, service extensions, registrations
- **Logging/Trancint** - Common libs for logging, Logging pipelines...
- **Api response defs** - API response wrappers / result standardization
- **Exception handling** - Middleware stuff, Common Exceptions, Error codes...

---

## System Design (HLA)
For High Level Architecture overview please refer to [SYSTEM DESIGN](Docs/Solution/SystemOverview.docx)

---

### 🚀 How to Run

- Download and extract
- Make sure docker desktop is running (this build is tested on Windows 11 with Docker 4.28.0 with Engine: 25.0.3)
- Open powershell console and navigate to src folder
- execute ps script - start.ps1 or execute command 'docker compose up -d'
- Both commands do the same job. If there were no images already, command will build the images and eventually start

## Test the API endpoints
For testing purposes POSTMAN collection is provided:
- [POSTMAN 2.1](Docs/Solution/Cloud%20Sales%20System%20-%20CRAYON(2.0).postman_collection.json)
- [POSTMAN 2.0](Docs/Solution/Cloud%20Sales%20System%20-%20CRAYON(2.0).postman_collection.json)
- [POSTMAN ENVIRONMENT](Docs/Solution/CrayonEnv.postman_environment.json)

After importing env and collections, choosing environemnt in postman, you are ready to go!

Collection structure:
- GATEWAY - folder with gateway endpoints
- Customers - endpoints for Customer API microservice
- Accounts - endpoints for Account API microservice
- Licences - endpoints for Licence API microservice
- Products - endpoints for Products API microservice
- HEALTHCHECK - endpoint for system healthcheck


### ❌ How to Stop
- Powershell navigate into the same directory (src)
- execute ps script - stop.ps1, or execute command 'docker compose down'
- This will stop and remove all containers.

---

## HUGE TODOS

Due to time constraints the solution lacks of:
- Unit and integration tests — only a few example tests have been included to demonstrate the intended testing approach.
- Sofisticated exception handling (Middleware, ProblemDetails...)
- Better validation (Fluent if needed)
- Workers not implemented
- Auth done just as mock example (passing some info through custom request header)
- Microservices should be communicating via SSL
