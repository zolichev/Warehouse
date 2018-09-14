# Warehouse
Warehouse WebApi REST service.

### Run application
Clone or download https://github.com/zolichev/Warehouse. Open Warehouse.sln in Visual Studio 2017.
Rebuild solution then run, startup project is Warehouse.WebApi. Open http://localhost:51205/swagger/ui/index for Swagger UI of service.

Also application deployed on Azure service -  https://warehousewebapiservice.azurewebsites.net/swagger/ui/index.

Swagger has been installed in application as service documentator and service runner.

When authentification need please use builded user "test"/"" (password is empty string), or create new user through request "post  /api/store/Clients  Register new client".

### Available requests

Wares 

* "get  /api/store/Wares  Get all wares in store" 
* "get  /api/store/Wares/{id}  Get ware by id." 
* "post  /api/store/Wares  Add new ware in store"
* "delete  /api/store/Wares/{id}  Remove ware from store" 
* "delete  /api/store/Wares  Remove first expired ware from store"

Clients

* "get  /api/store/Clients  Get current client." 
* "post  /api/store/Clients  Register new client" 
* "put  /api/store/Clients  Update notifiable property of current client" 

Notifications 

* "get  /api/store/Notifications  Get all notifications." 
* "get  /api/store/Notifications/{id}  Get notification by id." 
* "delete  /api/store/Notifications/{id}  View and remove notification from client" 
* "post  /api/store/Notifications  View and make viewed next notification from client"  
* "delete  /api/store/Notifications  View and make viewed all notifications from client" 

### Application architecture

Application contains several layer implemented in different projects

* Warehouse.Model. Application model. Defining base entities of app. Areas: Wares, Clients, Notifications. This areas contain separate model. Here is no actions and functionality, except entity creation and model transforming. 

* Warehouse.Storage. Storing add data. Areas: Wares, Clients, Notifications. Used Entity Framework 6 Code First on localDB. Defined interfaces for ability replace store functionality.

* Warehouse.Service. Main app functionality. Areas: Wares, Clients, Notifications. Ready for separate in microservices. Entry point is ServiceLocator.

* Warehouse.Service.Tests. Service layer unit tests. Implements self data storage in memory for clear and fill data in db before every test run.

* Warehouse.WebApi. REST web api app. Used basic authentification. All requests, except client registration, need authentification. CORS is turned on for ability run request from other servers.

### Agreements and assumptions

Here is no good validation. Implement validation deeper.

Storage must be in real DB.

Implement DI container.

Basic authentification must be changed to token based authentification with support OAuth2.

Here is no authorization. Define roles and implement it.

It hasn't been made performance check. 

No UI present. Available different types of UI include web, desktop, mobile, etc.
