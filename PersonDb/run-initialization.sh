# Wait to be sure that SQL Server came up
sleep 15s

### Run the setup script to create the DB and the schema in the DB
#
### Microsoft has changed the [ mssql-tools ] folder to [ mssql-tools18 ].
### Docker Compose is not properly recognizing this change yet (8/20/2024).
### 	Does not recognize [ mssql-tools18 ].
### 	Only recognizes [ mssql-tools ].
### Docker Image Build and Docker Container Run properly recognize [ mssql-tools18 ].
### The change below (HACK) to get around the problem.

if test -f /opt/mssql-tools18/bin/sqlcmd
then
	/opt/mssql-tools18/bin/sqlcmd -C -S localhost -U SA -P L0ckandK#y -d master -i /usr/src/app/PersonDb/create-database.sql
else
	/opt/mssql-tools/bin/sqlcmd -C -S localhost -U SA -P L0ckandK#y -d master -i /usr/src/app/PersonDb/create-database.sql
fi
