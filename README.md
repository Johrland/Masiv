# Prueba de Clean Code para Masivian | API Rest 
El objetivo de la prueba es desarrollar un API con cuatro Endpoints aplicando las 12 reglas minimas de Clean Code definidas por Masiv, ver [Masiv Masivian](https://masiv.com/) - Masiv.com

## Comenzando 🚀 

Puede Clonar este github para realizar pruebas y/o actualizar el codigo fuente, recuerde modificar la conexion al servidor REDIS


### Pre-requisitos 📋

1. Visual Studio 2017 o superior
2. Docker
3. Servidor Redis version 3.7 o superior

### Instalación 🔧

1. Instala Visual Studio desde la pagina de Microsoft | [Descarga Visual Studio](https://visualstudio.microsoft.com/es/free-developer-offers/) 
2. Instala Docker en una maquina virtual, ejemplo W10 | [Descarga Docker W10](https://docs.docker.com/docker-for-windows/install/)
3. Clona la imagen de Redis, o ejecuta el docker-compose ubicado en | [Imagen Redis Docker Hub](https://hub.docker.com/r/bitnami/redis) 

## Despliegue 📦

Con el objetivo de simplificar el despliegue se crea una imagen Docker con el publicado de la solucion de API en Docker Hub, de tal modo que se pueda clonar la imagen desde cual quier localidad. Adicionalmente en la ruta *** se almacena el archivo docker-compose.yml con el cual se despliega automaticamente el API y el servicio REDIS, ver [Docker Hub](https://hub.docker.com/r/johrland/apiroulette)

Se debe modificar el archivo docker-compose.yml en las lineas indicadas a continuacion para especificar los datos de la direccion IP y la contraseña del servidor 
```
services:
    apiroulette:
        environment:
            - REDIS_SERVER=IP_REDIS_SERVER:6379
            - REDIS_PASSWORD=PASSWORD_REDIS
 .
 .
 .
    redis:
        environment:
            - REDIS_PASSWORD=PASSWORD_REDIS
```
## Endponts

1. ListRoulettes - Lista todas las ruletas creadas sin discriminar el estado.
2. CreateRoulette - Crea una Ruleta (Por defecto se crea con estado Cerrada, el Id es autoincremental)
3. OpenRoulette - Abre las apuestas en una Ruleta, dejandola disponible para realizar apuestas (Si la ruleta se encuentra Cerrada y contiene apuestas las reinicia)
4. BidBet - Registra una apuesta en la ruleta indicada.
5. CloseRoulette - Cierra las apuestas en una Ruleta, inposibilitando el registro de nuevas apuestas y calcula las ganancias para los usuarios.

## Pruebas 

En la ruta *** se encuentra el archivo **Test.postman_collection.json** con el cual podra realizar las pruebas de todos los Endpoints implementados por el API

## Construido con 🛠️

* [.Net Core](https://docs.microsoft.com/en-us/dotnet/) - Framework .NetCore 2.1.1
* [Redis](https://redis.io/documentation) - Redis, Almacen Cache distribuido. 

## Autores ✒️

* **Johan Loaiza** - *Trabajo Inicial* - [Johrland](https://github.com/Johrland)

También puedes mirar la lista de todos los [contribuyentes](https://github.com/Masiv/graphs/contributors) quíenes han participado en este proyecto. 
  
