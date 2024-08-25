## EXPERIMENT 

##		REFERENCE
##		----------------------------------------------------------------
##		This will generate a new sql container (Current Version - WORKS)
docker run                 \
--name SqlDockerMac-exp-02  \
-e 'ACCEPT_EULA=Y'           \
-e 'SA_PASSWORD=L0ckandK#y'   \
-e 'MSSQL_PID=Developer'       \
-p 1433:1433                    \
-d                               \
sql.docker.mac-persondb:latest



docker network  create mytestnet

docker network ls
NETWORK ID     NAME         DRIVER    SCOPE
03b01a682cec   bridge       bridge    local
2fb3de9009cb   host         host      local
e1fdb31ee790   my-network   bridge    local
b362b202b7e6   mytestnet    bridge    local

##		This will generate a new sql container with --network = 'mytestnet'
##		This version works with local app build
docker run                   \
--name SqlDockerMac-exp-Test  \
-e 'ACCEPT_EULA=Y'             \
-e 'SA_PASSWORD=L0ckandK#y'     \
-e 'MSSQL_PID=Developer'         \
-p 1402:1433                      \
-d                                 \
--network mytestnet \
sql.docker.mac-persondb:latest
