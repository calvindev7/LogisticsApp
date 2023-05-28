# API de Clientes

Esta API permite realizar operaciones relacionadas con la gestión de clientes.

## Endpoints

### Obtener todos los clientes

**GET** `/api/clientes`

Retorna la lista de todos los clientes registrados.

Ejemplo de respuesta (Body):
```json
[
    {
        "id": 1,
        "nombre": "Juan Pérez",
        "email": "juan.perez@example.com"
    },
    {
        "id": 2,
        "nombre": "María López",
        "email": "maria.lopez@example.com"
    },
    {
        "id": 3,
        "nombre": "Carlos Gómez",
        "email": "carlos.gomez@example.com"
    }
]
```

### Obtener un cliente por ID

**GET** `/api/clientes/{id}`

Retorna los detalles de un cliente específico.

Ejemplo de respuesta (Body):
```json
{
    "id": 1,
    "nombre": "Juan Pérez",
    "email": "juan.perez@example.com"
}
```

### Crear un nuevo cliente

**POST** `/api/clientes`

Crea un nuevo cliente.

Ejemplo de solicitud (Body):
```json
{
    "nombre": "Laura Torres",
    "email": "laura.torres@example.com"
}
```

### Actualizar un cliente existente

**PUT** `/api/clientes/{id}`

Actualiza los datos de un cliente existente.

Ejemplo de solicitud (Body):
```json
{
    "nombre": "Laura Torres",
    "email": "laura.torres@example.com"
}
```

### Eliminar un cliente

**DELETE** `/api/clientes/{id}`

Elimina un cliente existente.

### Autenticación

La autenticación se realiza a través de OAuth 2.0. Debes incluir el token de acceso en el encabezado de autorización usando el esquema "Bearer".

# API de Productos

Esta API permite realizar operaciones relacionadas con la gestión de productos.

## Endpoints

### Obtener todos los productos

**GET** `/api/productos`

Retorna la lista de todos los productos registrados.

Ejemplo de respuesta (Body):
```json
[
    {
        "id": 1,
        "nombre": "Producto 1",
        "tipo": "Tipo 1"
    },
    {
        "id": 2,
        "nombre": "Producto 2",
        "tipo": "Tipo 2"
    },
    {
        "id": 3,
        "nombre": "Producto 3",
        "tipo": "Tipo 1"
    }
]
```

### Obtener un producto por ID

**GET** `/api/productos/{id}`

Retorna los detalles de un producto específico.

Ejemplo de respuesta (Body):
```json
{
    "id": 1,
    "nombre": "Producto 1",
    "tipo": "Tipo 1"
}
```

### Crear un nuevo producto

**POST** `/api/productos`

Crea un nuevo producto.

Ejemplo de solicitud (Body):
```json
{
    "nombre": "Producto 4",
    "tipo": "Tipo 2"
}
```

### Actualizar un producto existente

**PUT** `/api/productos/{id}`

Actualiza los datos de un producto existente.

Ejemplo de solicitud (Body):
```json
{
    "nombre": "Producto 1",
    "tipo": "Tipo actualizado"
}
```

### Eliminar un producto



**DELETE** `/api/productos/{id}`

Elimina un producto existente.

### Autenticación

La autenticación se realiza a través de OAuth 2.0. Debes incluir el token de acceso en el encabezado de autorización usando el esquema "Bearer".

# API de Envíos Terrestres

Esta API permite realizar operaciones relacionadas con la gestión de envíos terrestres.

## Endpoints

### Obtener todos los envíos terrestres

**GET** `/api/enviosterrestres`

Retorna la lista de todos los envíos terrestres registrados.

Ejemplo de respuesta (Body):
```json
[
    {
        "id": 1,
        "tipoProducto": "Producto 1",
        "cantidadProducto": 5,
        "fechaRegistro": "2023-05-01",
        "fechaEntrega": "2023-05-10",
        "bodegaEntrega": "Bodega 1",
        "precioEnvio": 100.00,
        "placaVehiculo": "ABC123",
        "numeroGuia": "1234567890",
        "clienteId": 1,
        "productoId": 1
    },
    {
        "id": 2,
        "tipoProducto": "Producto 2",
        "cantidadProducto": 3,
        "fechaRegistro": "2023-05-02",
        "fechaEntrega": "2023-05-11",
        "bodegaEntrega": "Bodega 2",
        "precioEnvio": 150.00,
        "placaVehiculo": "XYZ987",
        "numeroGuia": "0987654321",
        "clienteId": 2,
        "productoId": 2
    },
    {
        "id": 3,
        "tipoProducto": "Producto 1",
        "cantidadProducto": 8,
        "fechaRegistro": "2023-05-03",
        "fechaEntrega": "2023-05-12",
        "bodegaEntrega": "Bodega 1",
        "precioEnvio": 120.00,
        "placaVehiculo": "DEF456",
        "numeroGuia": "5432109876",
        "clienteId": 3,
        "productoId": 1
    }
]
```

### Obtener un envío terrestre por ID

**GET** `/api/enviosterrestres/{id}`

Retorna los detalles de un envío terrestre específico.

Ejemplo de respuesta (Body):
```json
{
    "id": 1,
    "tipoProducto": "Producto 1",
    "cantidadProducto": 5,
    "fechaRegistro": "2023-05-01",
    "fechaEntrega": "2023-05-10",
    "bodegaEntrega": "Bodega 1",
    "precioEnvio": 100.00,
    "placaVehiculo": "ABC123",
    "numeroGuia": "1234567890",
    "clienteId": 1,
    "productoId": 1
}
```

### Crear un nuevo envío terrestre

**POST** `/api/enviosterrestres`

Crea un nuevo envío terrestre.

Ejemplo de solicitud (Body):
```json
{
    "tipoProducto": "Producto 1",
    "cantidadProducto": 5,
    "fechaRegistro": "2023-05-01",
    "fechaEntrega": "2023-05

-10",
    "bodegaEntrega": "Bodega 1",
    "precioEnvio": 100.00,
    "placaVehiculo": "ABC123",
    "numeroGuia": "1234567890",
    "clienteId": 1,
    "productoId": 1
}
```

### Actualizar un envío terrestre existente

**PUT** `/api/enviosterrestres/{id}`

Actualiza los datos de un envío terrestre existente.

Ejemplo de solicitud (Body):
```json
{
    "tipoProducto": "Producto 1",
    "cantidadProducto": 10,
    "fechaRegistro": "2023-05-01",
    "fechaEntrega": "2023-05-12",
    "bodegaEntrega": "Bodega 2",
    "precioEnvio": 120.00,
    "placaVehiculo": "DEF456",
    "numeroGuia": "1234567890",
    "clienteId": 1,
    "productoId": 1
}
```

### Eliminar un envío terrestre

**DELETE** `/api/enviosterrestres/{id}`

Elimina un envío terrestre existente.

### Autenticación

La autenticación se realiza a través de OAuth 2.0. Debes incluir el token de acceso en el encabezado de autorización usando el esquema "Bearer".

# API de Envíos Marítimos

Esta API permite realizar operaciones relacionadas con la gestión de envíos marítimos.

## Endpoints

### Obtener todos los envíos marítimos

**GET** `/api/enviosmaritimos`

Retorna la lista de todos los envíos marítimos registrados.

Ejemplo de respuesta (Body):
```json
[
    {
        "id": 1,
        "tipoProducto": "Producto 1",
        "cantidadProducto": 5,
        "fechaRegistro": "2023-05-01",
        "fechaEntrega": "2023-05-10",
        "puertoEntrega": "Puerto 1",
        "precioEnvio": 200.00,
        "numeroFlota": "ABC1234A",
        "numeroGuia": "1234567890",
        "clienteId": 1,
        "productoId": 1
    },
    {
        "id": 2,
        "tipoProducto": "Producto 2",
        "cantidadProducto": 3,
        "fechaRegistro": "2023-05-02",
        "fechaEntrega": "2023-05-11",
        "puertoEntrega": "Puerto 2",
        "precioEnvio": 250.00,
        "numeroFlota": "XYZ9876B",
        "numeroGuia": "0987654321",
        "clienteId": 2,
        "productoId": 2
    },
    {
        "id": 3,
        "tipoProducto": "Producto 1",
        "cantidadProducto": 8,
        "fechaRegistro": "2023-05-03",
        "fechaEntrega": "2023-05-12",
        "puertoEntrega": "Puerto 1",
        "precioEnvio": 220.00,
        "numeroFlota": "DEF4567C",
        "numeroGuia": "5432109876",
        "clienteId": 3,
        "productoId": 1
    }
]
```

### Obtener un envío mar

ítimo por ID

**GET** `/api/enviosmaritimos/{id}`

Retorna los detalles de un envío marítimo específico.

Ejemplo de respuesta (Body):
```json
{
    "id": 1,
    "tipoProducto": "Producto 1",
    "cantidadProducto": 5,
    "fechaRegistro": "2023-05-01",
    "fechaEntrega": "2023-05-10",
    "puertoEntrega": "Puerto 1",
    "precioEnvio": 200.00,
    "numeroFlota": "ABC1234A",
    "numeroGuia": "1234567890",
    "clienteId": 1,
    "productoId": 1
}
```

### Crear un nuevo envío marítimo

**POST** `/api/enviosmaritimos`

Crea un nuevo envío marítimo.

Ejemplo de solicitud (Body):
```json
{
    "tipoProducto": "Producto 1",
    "cantidadProducto": 5,
    "fechaRegistro": "2023-05-01",
    "fechaEntrega": "2023-05-10",
    "puertoEntrega": "Puerto 1",
    "precioEnvio": 200.00,
    "numeroFlota": "ABC1234A",
    "numeroGuia": "1234567890",
    "clienteId": 1,
    "productoId": 1
}
```

### Actualizar un envío marítimo existente

**PUT** `/api/enviosmaritimos/{id}`

Actualiza los datos de un envío marítimo existente.

Ejemplo de solicitud (Body):
```json
{
    "tipoProducto": "Producto 1",
    "cantidadProducto": 10,
    "fechaRegistro": "2023-05-01",
    "fechaEntrega": "2023-05-12",
    "puertoEntrega": "Puerto 2",
    "precioEnvio": 220.00,
    "numeroFlota": "DEF4567C",
    "numeroGuia": "1234567890",
    "clienteId": 1,
    "productoId": 1
}
```

### Eliminar un envío marítimo

**DELETE** `/api/enviosmaritimos/{id}`

Elimina un envío marítimo existente.

### Autenticación

La autenticación se realiza a través de OAuth 2.0. Debes incluir el token de acceso en el encabezado de autorización usando el esquema "Bearer".