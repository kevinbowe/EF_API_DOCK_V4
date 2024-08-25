# Overview

# Running App locally
```
$ dotnet run
```
This will start a webserver that can be reached like this:
```
http://localhost:8080/WeatherForcast
```
The data will be displayed in a un-formatted form.

# Running different Docker Containers

## Build and Run Api

This is performed in the ROOT project folder.
```
$ docker image build --pull --file Dockerfile-Api_Test_04 --tag api-test-04:latest .

$ docker container run --rm -d -p 8080:8000 --name Api-Test-04-container api-test-04
```
This will generate an image and container that will support the WeatherForecast API
```
http://localhost:8080/WeatherForecast 
```

## Build and Run Database

This is performed in the ROOT project folder.
```
$  docker image build --pull --file Dockerfile-Db_Test_04 --tag db-test-04-image .

$  docker container run -e 'ACCEPT=Y' -e 'MSSQL_SA_PASSWORD=MyLong5ecureP!D' -p 1433:1433 --name db-test-04-container -d db-test-04-image
```
This will generate a Database image and container. 

The database and table will be visible in Azure Data Studio
```
Login with UID == SA
PID == MyLong5ecureP!D
URL == localhost   (no port)
```
## Compose Database

This is performed in the ROOT project folder.

```
$ docker compose -f docker-compose-Db_04.yaml up
```

This will generate a Database Image and Container in a Multi-Container project.
```
personsdb-project(container)
	personsdb-container-1  -->  personsdb-image
```

The database and table will be visible in Azure Data Studio
```
Login with UID == SA
PID == MyLong5ecureP!D
URL == localhost   (no port)
```
## Compose Database and API
```
$ docker compose up --build
```
This will generate a Multi-Container project, a Database Image and Container, and an Api Image and Container
```
ef_api-project(container)
	persondb-container-1  ---> personsdb-image
	api-container-1   ---> api-image
```

The database and table will be visible in Azure Data Studio
```
Login with UID == SA
PID == MyLong5ecureP!D
URL == localhost   (no port)
```
The API will be visible from a browser.
```
http://localhost:8080/WeatherForecast 
```
