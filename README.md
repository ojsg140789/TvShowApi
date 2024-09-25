# TvShow API

Esta es una API desarrollada con **ASP.NET Core 8** que permite gestionar una lista de `TvShows` (programas de televisión). La API incluye las operaciones básicas de **CRUD** (Create, Read, Update, Delete) y utiliza una arquitectura en capas para una mejor mantenibilidad y escalabilidad. También se implementa un middleware personalizado para el manejo centralizado de errores y se documenta el API usando **Swagger**.

## Tecnologías Usadas

- **.NET 8**
- **ASP.NET Core**
- **AutoMapper** para el mapeo entre entidades y DTOs.
- **Swagger** para la documentación de la API.
- **Inyección de Dependencias** (DI).
- **Arquitectura en Capas**.

## Estructura del Proyecto

El proyecto sigue una arquitectura en capas. A continuación se describe la estructura de los archivos principales:

```plaintext
/TvShowApi
│
├── /Domain
│   ├── /Entities
│   │   └── TvShow.cs
│   └── /Repositories
│       └── ITvShowRepository.cs
│
├── /Application
│   ├── /Services
│   │   └── TvShowService.cs
│   ├── /DTOs
│   │   ├── TvShowDto.cs
│   │   └── CreateTvShowDto.cs
│   ├── /Profiles
│   │   └── TvShowProfile.cs
│   └── /Interfaces
│       └── ITvShowService.cs
│
├── /Infrastructure
│   └── /Repositories
│       └── TvShowRepository.cs
│
├── /Presentation
│   └── /Controllers
│       └── TvShowsController.cs
│
└── Program.cs

## Requisitos Previos

Antes de ejecutar el proyecto, asegúrate de tener los siguientes elementos instalados en tu sistema:

- **.NET 8 SDK**: Puedes descargarlo desde [aquí](https://dotnet.microsoft.com/download/dotnet/8.0).
- Un editor de código, como:
  - **Visual Studio 2022** (Recomendado)
  - **Visual Studio Code**
- **Postman** o cualquier herramienta para realizar peticiones HTTP (opcional para probar la API).
- **Git** para clonar el repositorio (opcional).

## Instalación

1. **Clona el repositorio**:

   Abre una terminal y clona el proyecto desde el repositorio:

   ```bash
   git clone https://github.com/tuusuario/tvshow-api.git
   cd tvshow-api

2. **Restaura los paquetes NuGet**:

    En la carpeta raíz del proyecto, ejecuta el siguiente comando para restaurar las dependencias:

    ```bash
    cd TvShowApi.Api
    dotnet restore

3. **Construye el proyecto**:

    Ejecuta el siguiente comando para compilar el proyecto:

    ```bash
    cd TvShowApi.Api
    dotnet build

## Configuración

1. **Ejecuta la API localmente**:

   Para iniciar el servidor web, usa el siguiente comando:

    ```bash
    cd TvShowApi.Api
    dotnet run

    Esto iniciará la API en el entorno local. La API estará disponible en:
    http://localhost:5254

2. **Acceso a la documentación Swagger**:

   Una vez que la aplicación esté en ejecución, puedes acceder a la documentación Swagger generada automáticamente visitando:

    http://localhost:5254/swagger/index.html

## Endpoints    
A continuación se describen los principales endpoints que puedes utilizar en la API para gestionar TvShows.

- GET /api/tvshows
Obtiene una lista de todos los programas de televisión (TvShows).

Respuesta:
[
  {
    "id": 1,
    "name": "Breaking Bad",
    "favorite": true
  },
  {
    "id": 2,
    "name": "Stranger Things",
    "favorite": false
  }
]

- GET /api/tvshows/{id}
Obtiene un programa de televisión por su ID.

Respuesta:
{
  "id": 1,
  "name": "Breaking Bad",
  "favorite": true
}

- POST /api/tvshows
Crea un nuevo programa de televisión.

Petición:
{
  "name": "The Office",
  "favorite": true
}

- PUT /api/tvshows/{id}
Actualiza un programa de televisión existente por su ID.

Petición:
{
  "id": 1,
  "name": "Better Call Saul",
  "favorite": true
}

- DELETE /api/tvshows/{id}
Elimina un programa de televisión existente por su ID.

Respuesta Exitosa (204 No Content):
No se devuelve contenido en la respuesta.