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
$ docker image build --pull --file Dockerfile-Api --tag api-image:latest .

$ docker container run --rm -d -p 8080:8000 --name Api-container api-image
```
This will generate an image and container that will support the WeatherForecast API
```
http://localhost:8080/WeatherForecast 
```
### *Note - Test Persons database and data*
The Dockerfile-Db builds a database image. It also creates a [Persons] database and records. The TSQL that generates the table and records can be found here:

```
PersonDb/create-database.sql
```
This TSQL is executed when this file is executed at the end of the container.
```
CMD ["./PersonDb/entrypoint.sh"]
```
entrypoint.sh calls run-initialization.sh. 

run-initialization.sh handles SQL Database inconsistencies related to where /bin/sqlcmd is saved.

The Persons database will be regenerated EVERY TIME the container is rebuilt. Stoping and Starting the container will not destroy the database. Adding addition data to the database will persist as long as the container is NOT discarded.

Rebuilding the container will generate the ORIGINAL Persons database.


## Build and Run Database

This is performed in the ROOT project folder.
```
$  docker image build --pull --file Dockerfile-Db --tag personsdb-image .

$  docker container run -e 'ACCEPT=Y' -e 'MSSQL_SA_PASSWORD=<_your_Password_>' -p 1433:1433 --name db-container -d personsdb-image
```
This will generate a Database image and container. 

The database and table will be visible in Azure Data Studio
```
Login with UID == SA
PID == <_your_Password_>
URL == localhost   (no port)
```



## Compose Database and API
```
$ docker compose up --build
```
This will generate a Multi-Container project, a Database Image and Container, and an Api Image and Container
```
db_api_project_container
	persondb_container  ---> personsdb-image
	api_container-1   ---> api-image
```

The database and table will be visible in Azure Data Studio
```
Login with UID == SA
PID == <_your_Password_>
URL == localhost   (no port)
```
The API will be visible from a browser.
```
http://localhost:8080/WeatherForecast 
```
