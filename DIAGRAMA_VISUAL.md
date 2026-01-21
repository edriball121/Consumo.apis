# Diagrama Visual de la Solución

## 🎯 Flujo de una Petición HTTP

```
┌──────────────────┐
│  Cliente HTTP    │
│  (Postman,       │
│   PowerShell,    │
│   cURL, etc)     │
└────────┬─────────┘
         │ GET /api/posts/1
         ▼
┌──────────────────────────────────────────────┐
│         consumo.apis.Api (Presentación)      │
│  ┌────────────────────────────────────────┐  │
│  │  PostsController.cs                    │  │
│  │  ├─ GET: GetAllPosts()                │  │
│  │  ├─ GET: GetPostById(id)              │  │
│  │  └─ GET: GetPostsByUserId(userId)     │  │
│  └────────────────┬─────────────────────┘   │
│                   │                          │
│  (Inyección de    │ Se invoca UseCase       │
│   Dependencias    │                          │
│   en Program.cs)  │                          │
└───────────────────┼──────────────────────────┘
                    │
         ┌──────────▼─────────────┐
         │  IGetPostsUseCase      │
         │  (Interfaz del negocio)│
         └──────────┬─────────────┘
                    │
         ┌──────────▼─────────────────────┐
         │  GetPostsUseCase.cs (Aplicación)
         │  ├─ ExecuteAsync()             │
         │  ├─ ExecuteByIdAsync(id)       │
         │  └─ ExecuteByUserIdAsync(uid)  │
         │         │                      │
         │         │ Mapea a DTOs         │
         └─────────┼──────────────────────┘
                   │
         ┌─────────▼──────────┐
         │ IPostRepository    │
         │ (Puerto/Interfaz)  │
         └─────────┬──────────┘
                   │
         ┌─────────▼──────────────────────┐
         │ PostRepository.cs              │
         │ (Implementación en Infra)      │
         │    └─ Usa HttpClient           │
         └─────────┬──────────────────────┘
                   │
         ┌─────────▼───────────────────────────┐
         │ JsonPlaceholderClient.cs            │
         │ └─ GetPostByIdAsync(id)             │
         │    └─ HttpClient.GetAsync("/posts/1")
         └─────────┬───────────────────────────┘
                   │
         ┌─────────▼──────────────────┐
         │  JSONPlaceholder API       │
         │  (https://json...)         │
         └────────────────────────────┘
                   │
         ┌─────────▼──────────────────┐
         │   {"userId":1,             │
         │    "id":1,                 │
         │    "title":"...",          │
         │    "body":"..."}           │
         └────────────────────────────┘

         (La respuesta recorre el camino inverso)

         ▼
    Serializa en DTO
    PostDto { userId, id, title, body }
         ▼
    Retorna 200 OK con JSON
         ▼
    Cliente recibe respuesta
```

## 📦 Distribución de Clases

### 🟦 consumo.apis.Domain

```
Domain/ (Sin dependencias externas)
├── Entities/
│   ├── Post.cs
│   ├── User.cs
│   └── Comment.cs
└── Ports/ (Interfaces - Contratos)
    ├── IPostRepository.cs
    ├── IUserRepository.cs
    └── ICommentRepository.cs
```

### 🟩 consumo.apis.Application

```
Application/ (Depende de Domain)
├── DTOs/
│   ├── PostDto.cs
│   ├── UserDto.cs
│   └── CommentDto.cs
└── UseCases/ (Orquestación de lógica)
    ├── IGetPostsUseCase.cs
    ├── GetPostsUseCase.cs
    ├── IGetUsersUseCase.cs
    ├── GetUsersUseCase.cs
    ├── IGetCommentsUseCase.cs
    └── GetCommentsUseCase.cs
```

### 🟨 consumo.apis.Infrastructure

```
Infrastructure/ (Depende de Domain + Application)
├── HttpClients/
│   └── JsonPlaceholderClient.cs (Adaptador HTTP)
└── Repositories/ (Implementaciones de Puertos)
    ├── PostRepository.cs
    ├── UserRepository.cs
    └── CommentRepository.cs
```

### 🟪 consumo.apis.Api

```
Api/ (Depende de todos - Capa presentación)
├── Controllers/
│   ├── PostsController.cs
│   ├── UsersController.cs
│   └── CommentsController.cs
├── Properties/
│   └── launchSettings.json
└── Program.cs (Inyección de Dependencias)
```

## 🔄 Ciclo de Vida de una Solicitud

```
1. ENTRADA
   ├─ Cliente HTTP → POST /api/posts/1

2. CAPA API (Presentación)
   ├─ PostsController.GetPostById(1)
   ├─ Log: "Obteniendo post con ID: 1"
   └─ Llamar a IGetPostsUseCase

3. CAPA APPLICATION (Casos de Uso)
   ├─ GetPostsUseCase.ExecuteByIdAsync(1)
   ├─ Llamar a IPostRepository
   └─ Mapear Entidad a DTO

4. CAPA INFRASTRUCTURE (Adaptadores)
   ├─ PostRepository.GetPostByIdAsync(1)
   ├─ Llamar a JsonPlaceholderClient
   └─ Hacer petición HTTP

5. API EXTERNA (JSONPlaceholder)
   ├─ GET https://jsonplaceholder.typicode.com/posts/1
   └─ Retorna: {"userId":1,"id":1,"title":"...","body":"..."}

6. VUELTA (Responses)
   ├─ JsonPlaceholderClient recibe JSON
   ├─ Deserializa a Post (Entity)
   ├─ PostRepository retorna Post
   ├─ GetPostsUseCase mapea a PostDto
   ├─ PostsController retorna 200 OK
   └─ Cliente recibe respuesta JSON

7. SALIDA
   └─ Cliente HTTP recibe PostDto serializado
```

## 💾 Flujo de Datos

```
          JSON externo
               │
               ▼
        JsonPlaceholderClient
               │
        Deserialize (System.Text.Json)
               │
               ▼
        Entity (Post/User/Comment)
               │ (Paso por repositorio)
               ▼
        Mapeo a DTO
        (PostDto/UserDto/CommentDto)
               │
        Serialize (System.Text.Json)
               │
               ▼
          JSON Response
```

## 🔌 Puertos y Adaptadores

### Puertos (Interfaces en Domain)

```
┌─────────────────────┐
│  IPostRepository    │  ← Define qué debe hacer
│  IUserRepository    │     (pero NO cómo hacerlo)
│  ICommentRepository │
└─────────────────────┘
```

### Adaptadores (Implementaciones en Infrastructure)

```
┌──────────────────────────────┐
│ PostRepository (implementa   │  ← Dice CÓMO hacerlo
│ IPostRepository)             │     (usa HttpClient)
│                              │
│ Usa: JsonPlaceholderClient   │
└──────────────────────────────┘
```

## 🎓 Ventajas de esta Estructura

```
┌─────────────────────────────────────────┐
│  SIN Arquitectura Hexagonal              │
│  ├─ Todo mezclado                       │
│  ├─ Difícil de testear                  │
│  ├─ Cambia BD = Reescribe todo          │
│  └─ Mantenimiento difícil               │
└─────────────────────────────────────────┘

┌─────────────────────────────────────────┐
│  CON Arquitectura Hexagonal (Este Proyecto)
│  ├─ Capas bien separadas ✓             │
│  ├─ Fácil de testear (mockear) ✓       │
│  ├─ Cambia BD = Solo Infrastructure ✓  │
│  ├─ Mantenimiento simple ✓             │
│  └─ Escalable y profesional ✓          │
└─────────────────────────────────────────┘
```

## 📊 Dependencias

```
API  ──────────┐
                │
Application ────┼─── ← Dependen de estos
                │
Domain ─────────┤

Infrastructure ─┴─── ← Depende de estos
```

Nota: Infrastructure puede depender de Domain y Application
pero Domain NUNCA depende de Infrastructure
(Regla clave de Arquitectura Hexagonal)
