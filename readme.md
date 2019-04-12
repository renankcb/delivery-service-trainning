# **DELIVERY SERVICE PROJECT**

A Delivery service to Company XPTO

## **TECHNOLOGIES USED:**
	- .NET Core 2.0
	- Dapper
	- ED Core
	- XUnit
	
## **STRUCTURE**
	DeliveryService.API
		- Controllers
		- Dto
		- Migrations
		- Model
		- Repository
			- Commands (Database writing)
			- Queries (Database reading)
		- Services (Domain Logic)
		
	DeliveryService.DL.Tets (DL = DomainLogic)
		- RouteTest

	
## **HOW TO RUN IT**
	- Clone project
	- Adjust 'connectionstring' on startup file
	- Run migrations
	- Run project
	
## **API**
### **POINTS CONNECTIONS**
/pointsConnection
	- GET -> get all registers
	- GET (/{id}) -> get specific register
	- PUT -> update specific register
	- POST -> save register
	- DELETE -> delete register
	
### **POINTS**
/point
	- GET -> get all registers from pointsConnection
	- GET (/{id}) -> get specific register from pointsConnection
	- PUT -> update specific register
	- POST -> save register
	- DELETE -> delete register
	
### ROUTE
/route
	- GET (/getRouteFromOriginToDestination?originId={id}&destinationId={id}) -> get all routes given a origin and destination
	
## **DATA**
There are some data in database:
A, B, C, D, E, F

A -> B
A -> D
A -> C
A -> f
B -> C
D -> E
E -> C
D -> F
F -> E

## **RESULT**
The response consists in:
Origin, Destination, All availlable routes, lowest time route, lowest cost route.
