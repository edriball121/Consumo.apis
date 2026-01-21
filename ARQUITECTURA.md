# Consumo de JSONPlaceholder con Arquitectura Hexagonal

## Descripción General

Este proyecto implementa una arquitectura **hexagonal** (también conocida como puertos y adaptadores) para consumir datos de la API pública **JSONPlaceholder** de forma académica.

## Estructura del Proyecto

```
consumo.apis.sln
├── consumo.apis.Api/              # Capa de presentación (Puertos de salida)
│   └── Controllers/               # Controladores REST
│       ├── PostsController.cs
│       ├── UsersController.cs
│       └── CommentsController.cs
│
├── consumo.apis.Application/      # Casos de uso (Lógica de negocio)
│   ├── DTOs/                      # Data Transfer Objects
│   │   ├── PostDto.cs
│   │   ├── UserDto.cs
│   │   └── CommentDto.cs
│   └── UseCases/                  # Implementación de casos de uso
│       ├── GetPostsUseCase.cs
│       ├── GetUsersUseCase.cs
│       └── GetCommentsUseCase.cs
│
├── consumo.apis.Domain/           # Entidades y puertos (núcleo del negocio)
│   ├── Entities/                  # Modelos de dominio
│   │   ├── Post.cs
│   │   ├── User.cs
│   │   └── Comment.cs
│   └── Ports/                     # Interfaces (Contratos)
│       ├── IPostRepository.cs
│       ├── IUserRepository.cs
│       └── ICommentRepository.cs
│
└── consumo.apis.Infrastructure/   # Adaptadores e implementaciones
    ├── HttpClients/               # Cliente HTTP para JSONPlaceholder
    │   └── JsonPlaceholderClient.cs
    └── Repositories/              # Implementación de repositorios
        ├── PostRepository.cs
        ├── UserRepository.cs
        └── CommentRepository.cs
```

## Arquitectura Hexagonal

La arquitectura hexagonal separa la aplicación en capas concéntricas:

### 1. **Domain (Núcleo)**

- Contiene las entidades de negocio (Posts, Users, Comments)
- Define los puertos (interfaces) que especifican los contratos
- **No tiene dependencias externas**

### 2. **Application (Casos de Uso)**

- Implementa la lógica de negocio
- Orquesta llamadas a repositorios
- Transforma datos entre DTOs y entidades
- Depende únicamente del Domain

### 3. **Infrastructure (Adaptadores)**

- Implementa los puertos del Domain
- Contiene el cliente HTTP para JSONPlaceholder
- Adapta datos externos a entidades de dominio
- Maneja las conexiones externas

### 4. **Api (Presentación)**

- Expone endpoints REST
- Llama a casos de uso
- Maneja errores y respuestas HTTP
- Inyecta dependencias en Program.cs

## Flujo de Datos

```
HTTP Request → Controller → UseCase → Repository → HttpClient → JSONPlaceholder
                    ↓
Dominio (Entity)   ← ← ← ← ← JsonPlaceholderClient
                    ↓
                DTO de Respuesta
                    ↓
HTTP Response
```

## Endpoints Disponibles

### Posts

- `GET /api/posts` - Obtener todos los posts
- `GET /api/posts/{id}` - Obtener un post por ID
- `GET /api/posts/user/{userId}` - Obtener posts de un usuario

### Users

- `GET /api/users` - Obtener todos los usuarios
- `GET /api/users/{id}` - Obtener un usuario por ID

### Comments

- `GET /api/comments/post/{postId}` - Obtener comentarios de un post
- `GET /api/comments/{id}` - Obtener un comentario por ID

## Ventajas de esta Arquitectura

✅ **Independencia de frameworks**: Si cambias de HttpClient a otra librería, solo modificas Infrastructure
✅ **Testabilidad**: Puedes mockear los puertos fácilmente en tests unitarios
✅ **Mantenibilidad**: Cada capa tiene responsabilidades claras
✅ **Escalabilidad**: Fácil agregar nuevas fuentes de datos
✅ **Reutilización**: Los casos de uso pueden usarse desde diferentes capas de presentación

## Buenas Prácticas Implementadas

1. **Inyección de Dependencias**: Registradas en Program.cs
2. **Logging**: Cada controlador registra operaciones
3. **Manejo de Errores**: Try-catch con respuestas HTTP apropiadas
4. **DTOs**: Separación entre modelos internos y respuestas externas
5. **Documentación**: Comentarios XML en controladores y puertos
6. **Async/Await**: Operaciones asincrónicas para mejor rendimiento

## Próximos Pasos (Extensiones)

Para mejorar y ampliar el proyecto:

- Agregar **caché** en los repositorios
- Implementar **validaciones** en los DTOs
- Crear **tests unitarios** para los casos de uso
- Agregar **endpoints POST/PUT/DELETE** con persistencia
- Implementar **paginación** en listados
- Agregar **filtros y búsqueda**
- Configurar **CORS** si es necesario
- Implementar **autenticación y autorización**

## Ejecución

1. Asegurate de tener .NET 8.0 instalado
2. Ejecuta: `dotnet build`
3. Ejecuta: `dotnet run`
4. Accede a Swagger en: `https://localhost:7XXX/swagger`
