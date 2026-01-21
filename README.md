# Consumo.apis - JSONPlaceholder

API REST desarrollada con **C# 8.0 y ASP.NET Core** que implementa **Arquitectura Hexagonal** para consumir datos de la API pública **JSONPlaceholder** con fines académicos.

## 🎯 Propósito

Este proyecto demuestra cómo construir una aplicación escalable y mantenible siguiendo los principios de arquitectura hexagonal (puertos y adaptadores), consumiendo una API externa pública.

## 🏗️ Arquitectura

La solución está dividida en 4 capas bien definidas:

- **Domain** (Núcleo del negocio) - Entidades y puertos
- **Application** (Casos de uso) - Lógica de negocio
- **Infrastructure** (Adaptadores) - Implementaciones externas
- **API** (Presentación) - Controladores REST

## 📋 Requisitos

- .NET 8.0 SDK
- Visual Studio 2022 / VS Code
- (Opcional) Postman o Insomnia para pruebas

## 🚀 Inicio Rápido

```bash
# Clonar/abrir el proyecto
cd c:\Users\edrib\Documents\Repos\CSharp\Consumo.apis

# Restaurar dependencias
dotnet restore

# Compilar
dotnet build

# Ejecutar
dotnet run
```

La API estará disponible en: `https://localhost:5001`

## 📚 Documentación

- **[ARQUITECTURA.md](ARQUITECTURA.md)** - Explicación detallada de la arquitectura hexagonal
- **[USO_API.md](USO_API.md)** - Guía de uso con ejemplos de peticiones
- **[IMPLEMENTACION_RESUMIDA.md](IMPLEMENTACION_RESUMIDA.md)** - Resumen de lo implementado
- **[EJEMPLO_TESTS.cs](EJEMPLO_TESTS.cs)** - Referencia para crear tests unitarios

## 🔌 Endpoints Principales

### Posts

```
GET  /api/posts              # Todos los posts
GET  /api/posts/{id}         # Post específico
GET  /api/posts/user/{userId} # Posts de un usuario
```

### Usuarios

```
GET  /api/users              # Todos los usuarios
GET  /api/users/{id}         # Usuario específico
```

### Comentarios

```
GET  /api/comments/post/{postId} # Comentarios de un post
GET  /api/comments/{id}          # Comentario específico
```

## 📊 Estructura del Proyecto

```
consumo.apis/
├── consumo.apis.Api/           # Capa de Presentación
│   ├── Controllers/
│   │   ├── PostsController.cs
│   │   ├── UsersController.cs
│   │   └── CommentsController.cs
│   └── Program.cs              # Configuración e inyección de dependencias
│
├── consumo.apis.Application/   # Capa de Aplicación
│   ├── DTOs/                   # Data Transfer Objects
│   └── UseCases/               # Casos de uso
│
├── consumo.apis.Domain/        # Capa de Dominio
│   ├── Entities/               # Modelos de dominio
│   └── Ports/                  # Interfaces/Contratos
│
└── consumo.apis.Infrastructure/# Capa de Infraestructura
    ├── HttpClients/            # Cliente HTTP
    └── Repositories/           # Implementación de repositorios
```

## ✨ Características

✅ Arquitectura Hexagonal bien definida
✅ Inyección de Dependencias
✅ Operaciones Async/Await
✅ Documentación Swagger/OpenAPI
✅ Manejo robusto de errores
✅ Logging integrado
✅ DTOs para separación de datos
✅ Caso Insensitive JSON deserialization

## 🧪 Testing

El proyecto incluye un ejemplo de cómo crear tests unitarios en `EJEMPLO_TESTS.cs`.

Para implementar tests:

```bash
# Crear proyecto de tests
dotnet new xunit -n consumo.apis.Tests -f net8.0

# Agregar referencias
dotnet add consumo.apis.Tests reference consumo.apis.Application
dotnet add consumo.apis.Tests reference consumo.apis.Domain

# Instalar Moq
dotnet add consumo.apis.Tests package Moq

# Ejecutar tests
dotnet test
```

## 📝 Próximas Mejoras

- [ ] Agregar caché
- [ ] Implementar paginación
- [ ] Agregar validación de entrada
- [ ] Crear tests unitarios completos
- [ ] Agregar autenticación
- [ ] Implementar búsqueda y filtros
- [ ] Agregar endpoints POST/PUT/DELETE

## 📚 Referencia

- [JSONPlaceholder API](https://jsonplaceholder.typicode.com)
- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [Hexagonal Architecture](<https://en.wikipedia.org/wiki/Hexagonal_architecture_(software)>)

## 👨‍💻 Uso Educativo

Este proyecto es perfecto para:

- Aprender arquitectura hexagonal
- Entender inyección de dependencias
- Practicar consumo de APIs externas
- Dominar async/await en C#
- Aplicar buenas prácticas de desarrollo

## 📄 Licencia

Proyecto académico - Libre para uso educativo

---

**Desarrollado con fines académicos | Consumo de JSONPlaceholder API**
