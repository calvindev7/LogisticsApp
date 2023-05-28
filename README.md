# Logística App - Documentación del proyecto

Esta es la documentación del proyecto Logística App, una aplicación web desarrollada en .NET Core 6.0 con SQL Server como base de datos, IdentityServer4 para la autenticación y autorización, Bootstrap para el diseño de la interfaz de usuario, y JavaScript y Razor para la funcionalidad del frontend.

## Requisitos previos

Antes de ejecutar la aplicación, asegúrate de tener instalados los siguientes componentes:

- .NET Core 6.0 SDK: [Descargar e instalar .NET Core 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- SQL Server: [Descargar e instalar SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads)
- Visual Studio o Visual Studio Code (opcional): [Descargar e instalar Visual Studio](https://visualstudio.microsoft.com/es/downloads/) o [Descargar e instalar Visual Studio Code](https://code.visualstudio.com/download)

## Configuración

Sigue estos pasos para configurar y ejecutar la aplicación:

1. Clona el repositorio de GitHub en tu máquina local o descarga el código fuente en formato ZIP.
2. Abre el proyecto en tu entorno de desarrollo preferido (Visual Studio o Visual Studio Code).
3. Abre el archivo `appsettings.json` en la carpeta `LogisticaApp.API` y configura la cadena de conexión a tu base de datos SQL Server.
4. Ejecuta el siguiente comando en la terminal para instalar las dependencias del proyecto:

```shell
dotnet restore
```

5. Ejecuta el siguiente comando en la terminal para aplicar las migraciones y crear las tablas en la base de datos:

```shell
dotnet ef database update
```

6. Ejecuta el siguiente comando para iniciar la aplicación:

```shell
dotnet run --project LogisticaApp.API
```

7. La aplicación estará disponible en `https://localhost:7271`.

## Uso

La aplicación Logística App permite administrar la logística terrestre y marítima, registrando datos de clientes, tipos de productos, bodegas de almacenamiento terrestre y puertos marítimos. A continuación se detallan las funcionalidades principales:

### Autenticación y autorización

La aplicación utiliza IdentityServer4 para la autenticación y autorización. Debes registrarte como usuario para obtener un token de acceso que te permitirá acceder a las API RESTful.

### API RESTful

La aplicación proporciona las siguientes API RESTful:

- `POST /api/clientes`: Registra un nuevo cliente.
- `GET /api/clientes`: Obtiene todos los clientes.
- `GET /api/clientes/{id}`: Obtiene los detalles de un cliente específico.
- `PUT /api/clientes/{id}`: Actualiza los datos de un cliente específico.
- `DELETE /api/clientes/{id}`: Elimina un cliente específico.

- `POST /api/productos`: Registra un nuevo tipo de producto.
- `GET /api/productos`: Obtiene todos los tipos de productos.
- `GET /api/productos/{id}`: Obtiene los detalles de un tipo de producto específico.
- `PUT /api/productos/{id}`: Actualiza los datos de un tipo de producto específico.
- `DELETE /api/productos/{id}`: Elimina un tipo de producto específico.

- `POST /api/bodegas`: Registra una nueva bodega de almacenamiento terrest

re.
- `GET /api/bodegas`: Obtiene todas las bodegas de almacenamiento terrestre.
- `GET /api/bodegas/{id}`: Obtiene los detalles de una bodega de almacenamiento terrestre específica.
- `PUT /api/bodegas/{id}`: Actualiza los datos de una bodega de almacenamiento terrestre específica.
- `DELETE /api/bodegas/{id}`: Elimina una bodega de almacenamiento terrestre específica.

- `POST /api/puertos`: Registra un nuevo puerto marítimo.
- `GET /api/puertos`: Obtiene todos los puertos marítimos.
- `GET /api/puertos/{id}`: Obtiene los detalles de un puerto marítimo específico.
- `PUT /api/puertos/{id}`: Actualiza los datos de un puerto marítimo específico.
- `DELETE /api/puertos/{id}`: Elimina un puerto marítimo específico.

- `POST /api/EnviosTerrestres`: Registra un nuevo plan de entrega de logística terrestre.
- `GET /api/EnviosTerrestres`: Obtiene todos los planes de entrega de logística terrestre.
- `GET /api/EnviosTerrestres/{id}`: Obtiene los detalles de un plan de entrega de logística terrestre específico.
- `PUT /api/EnviosTerrestres/{id}`: Actualiza los datos de un plan de entrega de logística terrestre específico.
- `DELETE /api/EnviosTerrestres/{id}`: Elimina un plan de entrega de logística terrestre específico.

- `POST /api/EnviosMaritimos`: Registra un nuevo plan de entrega de logística marítima.
- `GET /api/EnviosMaritimos`: Obtiene todos los planes de entrega de logística marítima.
- `GET /api/EnviosMaritimos/{id}`: Obtiene los detalles de un plan de entrega de logística marítima específico.
- `PUT /api/EnviosMaritimos/{id}`: Actualiza los datos de un plan de entrega de logística marítima específico.
- `DELETE /api/EnviosMaritimos/{id}`: Elimina un plan de entrega de logística marítima específico.


## Contribución

Si deseas contribuir al proyecto, sigue estos pasos:

1. Haz un fork del repositorio.
2. Crea una rama para tu función o corrección de errores: `git checkout -b feature/feature-name` o `git checkout -b bugfix/bug-name`.
3. Realiza tus modificaciones

 y realiza commit de los cambios: `git commit -m "Descripción de los cambios"`.
4. Realiza push de la rama: `git push origin feature/feature-name`.
5. Abre un pull request en GitHub.

Agradecemos tu contribución al proyecto.

## Soporte

Si tienes alguna pregunta o problema, puedes encontrar mi información de contacto en el perfil
