# Guía de Uso - API JSONPlaceholder

## Compilación y Ejecución

```bash
# Restaurar dependencias
dotnet restore

# Compilar
dotnet build

# Ejecutar
dotnet run
```

La API estará disponible en: `https://localhost:7XXX` (el puerto se muestra en la consola)

## Swagger UI

Accede a Swagger para explorar e interactuar con los endpoints:

```
https://localhost:7XXX/swagger
```

## Ejemplos de Peticiones HTTP

### Posts

#### 1. Obtener todos los posts

```http
GET https://localhost:7XXX/api/posts
```

**Respuesta (primeros 2 posts):**

```json
[
  {
    "userId": 1,
    "id": 1,
    "title": "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
    "body": "quia et suscipit suspendisse..."
  },
  {
    "userId": 1,
    "id": 2,
    "title": "qui est esse",
    "body": "est rerum tempore vitae sequi sunt..."
  }
]
```

#### 2. Obtener un post específico

```http
GET https://localhost:7XXX/api/posts/1
```

**Respuesta:**

```json
{
  "userId": 1,
  "id": 1,
  "title": "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
  "body": "quia et suscipit..."
}
```

#### 3. Obtener posts de un usuario específico

```http
GET https://localhost:7XXX/api/posts/user/1
```

**Respuesta:**

```json
[
  { "userId": 1, "id": 1, "title": "...", "body": "..." },
  { "userId": 1, "id": 6, "title": "...", "body": "..." },
  ...
]
```

### Usuarios

#### 1. Obtener todos los usuarios

```http
GET https://localhost:7XXX/api/users
```

**Respuesta (primer usuario):**

```json
[
  {
    "id": 1,
    "name": "Leanne Graham",
    "username": "Bret",
    "email": "Sincere@april.biz",
    "phone": "1-770-736-8031",
    "website": "hildegard.org"
  }
]
```

#### 2. Obtener un usuario específico

```http
GET https://localhost:7XXX/api/users/1
```

**Respuesta:**

```json
{
  "id": 1,
  "name": "Leanne Graham",
  "username": "Bret",
  "email": "Sincere@april.biz",
  "phone": "1-770-736-8031",
  "website": "hildegard.org"
}
```

### Comentarios

#### 1. Obtener comentarios de un post

```http
GET https://localhost:7XXX/api/comments/post/1
```

**Respuesta (primeros 2 comentarios):**

```json
[
  {
    "postId": 1,
    "id": 1,
    "name": "id labore ex et quam laborum",
    "email": "Eliseo@annie.ca",
    "body": "laudantium enim quasi est quidem magnam voluptate..."
  },
  {
    "postId": 1,
    "id": 2,
    "name": "quo vero reiciendis velit similique earum",
    "email": "Jayne_Langworth@betty.ca",
    "body": "est natus enim nihil est dolore..."
  }
]
```

#### 2. Obtener un comentario específico

```http
GET https://localhost:7XXX/api/comments/5
```

**Respuesta:**

```json
{
  "postId": 1,
  "id": 5,
  "name": "vero qui et eos iusto sed quo.",
  "email": "Hayden@althea.biz",
  "body": "harum non quasi et ratione tempore iure ex voluptates..."
}
```

## Prueba con cURL

```bash
# Obtener todos los posts
curl -X GET "https://localhost:7XXX/api/posts" -H "accept: application/json"

# Obtener post con ID 1
curl -X GET "https://localhost:7XXX/api/posts/1" -H "accept: application/json"

# Obtener posts del usuario 1
curl -X GET "https://localhost:7XXX/api/posts/user/1" -H "accept: application/json"

# Obtener todos los usuarios
curl -X GET "https://localhost:7XXX/api/users" -H "accept: application/json"

# Obtener usuario con ID 1
curl -X GET "https://localhost:7XXX/api/users/1" -H "accept: application/json"

# Obtener comentarios del post 1
curl -X GET "https://localhost:7XXX/api/comments/post/1" -H "accept: application/json"
```

## Prueba con PowerShell

```powershell
# Obtener todos los posts
Invoke-RestMethod -Uri "https://localhost:7XXX/api/posts" -Method Get

# Obtener post con ID 1
Invoke-RestMethod -Uri "https://localhost:7XXX/api/posts/1" -Method Get

# Obtener posts del usuario 1
Invoke-RestMethod -Uri "https://localhost:7XXX/api/posts/user/1" -Method Get

# Obtener todos los usuarios
Invoke-RestMethod -Uri "https://localhost:7XXX/api/users" -Method Get

# Obtener usuario con ID 1
Invoke-RestMethod -Uri "https://localhost:7XXX/api/users/1" -Method Get

# Obtener comentarios del post 1
Invoke-RestMethod -Uri "https://localhost:7XXX/api/comments/post/1" -Method Get
```

## Códigos de Estado HTTP

| Código | Significado                                  |
| ------ | -------------------------------------------- |
| 200    | OK - Solicitud exitosa                       |
| 404    | Not Found - Recurso no encontrado            |
| 500    | Internal Server Error - Error en el servidor |

## Notas Importantes

- La API consume datos de **JSONPlaceholder** que es un servidor falso para testing
- Todos los datos son ficticios
- Los datos se obtienen en tiempo real desde el servidor de JSONPlaceholder
- No hay persistencia de datos en esta aplicación
- Los errores de conexión se registran en los logs de la aplicación

## Próximas Mejoras

- Agregar caché para mejorar rendimiento
- Implementar paginación
- Agregar búsqueda y filtros
- Implementar autenticación
- Agregar validación de entrada
