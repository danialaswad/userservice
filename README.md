# User Service Application with .NET core

User Service .Net core webapi that allows user to manipulate user information using the standard HTTP method (POST, GET, DELETE, PUT, PATCH). All information that is passed to the app will be stored in a built in microsoft sql server.

## How to run the app

The can be executed in 2 different ways, either you can use docker-compose to deploy the app and a fresh new microsoft sql, or you can deploy just the app a provide the necessary informationto connect to your existing DB.

### Deploy with docker-compose

To deploy both the app and a fresh microsoft sql db, execute the following command to create a container
```
$>docker-compose up
```
or
```
$>docker-compose up -d
```
to run in detach mode.

## Deploy standalone app

If you already have a microsoft sql server running, you can run this app in a standalone mode using the standard dotnet command
```bash
$>dotnet run DBPassword=<your_password>
```

 If you are using dotnet secret to host your db credentials, this app will look for it automatically. Here are the environment variables of the application to set the db

| var | Default value | Compulsory | 
| ----------- | ----------- | --------|
| DBSERVER | localhost | N |
| DBPORT | 1433 | N |
| DBCatalog | UserDB | N |
| DBUser | sa | N |
| DbPassword |  | Y |

Example execution:

```bash
$>dotnet run DBUser=john DBPassword=password DBCatalog=NewUserDB DBPORT=1430
```


## API Request example

The application is using REST API and the documentations can be found in the [swagger](swagger.json) file.

Here is a query example for one of the existing endpoint.

```
https://localhost:8081/api/users/
```

The query above will result in the following response

```json
[
    {
        "id": 1,
        "fullName": "JOHN WICK",
        "email": "john@test.com",
        "phone": "023455532",
        "age": 39
    },
    {
        "id": 2,
        "fullName": "DAVID BECKHAM",
        "email": "david@test.com",
        "phone": null,
        "age": 0
    },
    {
        "id": 3,
        "fullName": "ROSETTA STONE",
        "email": "rosetta@test.com",
        "phone": null,
        "age": 21
    },
    {
        "id": 4,
        "fullName": "NELSON MANDELA",
        "email": "nelson@test.com",
        "phone": "8723897443",
        "age": 0
    }
]
```