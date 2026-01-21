# ⚡ INICIO RÁPIDO

## 1️⃣ Compilar y Ejecutar

```bash
dotnet restore
dotnet build
dotnet run
```

## 2️⃣ Acceder a Swagger

```
https://localhost:7XXX/swagger
```

_(El puerto se muestra cuando ejecutas la app)_

## 3️⃣ Probar Endpoints Rápidamente

### Con PowerShell:

```powershell
# Obtener todos los posts
Invoke-RestMethod https://localhost:7XXX/api/posts -SkipCertificateCheck | ConvertTo-Json | more

# Obtener usuario 1
Invoke-RestMethod https://localhost:7XXX/api/users/1 -SkipCertificateCheck | ConvertTo-Json

# Obtener comentarios del post 1
Invoke-RestMethod https://localhost:7XXX/api/comments/post/1 -SkipCertificateCheck | ConvertTo-Json | more
```

### Con cURL (si tienes WSL o Git Bash):

```bash
curl -k https://localhost:7XXX/api/posts | jq '.' | head -50
curl -k https://localhost:7XXX/api/users/1 | jq '.'
curl -k https://localhost:7XXX/api/comments/post/1 | jq '.' | head -20
```

## 4️⃣ Estructura Visual

```
┌─────────────────────────────┐
│      REST API (HTTP)        │
├─────────────────────────────┤
│  PostsController ✓          │
│  UsersController ✓          │
│  CommentsController ✓       │
├─────────────────────────────┤
│  GetPostsUseCase ✓          │
│  GetUsersUseCase ✓          │
│  GetCommentsUseCase ✓       │
├─────────────────────────────┤
│  PostRepository ✓           │
│  UserRepository ✓           │
│  CommentRepository ✓        │
├─────────────────────────────┤
│  JsonPlaceholderClient ✓    │
├─────────────────────────────┤
│  JSONPlaceholder (Cloud)    │
└─────────────────────────────┘
```

## 5️⃣ Archivos Importantes

```
📄 README.md                      ← Visión general
📄 ARQUITECTURA.md                ← Explicación detallada
📄 USO_API.md                     ← Guía de uso y ejemplos
📄 IMPLEMENTACION_RESUMIDA.md     ← Qué se implementó
📄 EJEMPLO_TESTS.cs               ← Referencia de tests
📂 consumo.apis.Api/
   📂 Controllers/
      📄 PostsController.cs
      📄 UsersController.cs
      📄 CommentsController.cs
   📄 Program.cs
📂 consumo.apis.Application/
   📂 UseCases/
   📂 DTOs/
📂 consumo.apis.Domain/
   📂 Entities/
   📂 Ports/
📂 consumo.apis.Infrastructure/
   📂 HttpClients/
   📂 Repositories/
```

## 6️⃣ 3 Endpoints para Probar Ahora

### Test 1: Obtener todos los posts (puede ser lento)

```
GET https://localhost:7XXX/api/posts
```

✅ Retorna 100 posts

### Test 2: Obtener un post específico (rápido)

```
GET https://localhost:7XXX/api/posts/5
```

✅ Retorna 1 post

### Test 3: Obtener usuario específico (rápido)

```
GET https://localhost:7XXX/api/users/3
```

✅ Retorna 1 usuario con todos sus datos

## 7️⃣ ¿Algo Roto?

```bash
# Limpiar y reconstruir
dotnet clean
dotnet restore
dotnet build

# Ver errores específicos
dotnet build --verbosity detailed
```

## 8️⃣ Próximos Pasos Recomendados

1. ✅ Ejecutar la app
2. ✅ Explorar Swagger UI
3. ✅ Probar todos los endpoints
4. ✅ Ver los logs en consola
5. ✅ Leer ARQUITECTURA.md para entender el flujo
6. ✅ Modificar los controladores para agregar lógica
7. ✅ Crear tests unitarios
8. ✅ Agregar caché o persistencia

## ❓ Preguntas Frecuentes

**P: ¿Dónde veo los logs?**
R: En la consola donde ejecutaste `dotnet run`

**P: ¿Cómo agrego un nuevo endpoint?**
R: Crea un método en el controlador, inyecta el caso de uso necesario

**P: ¿Puedo guardar datos en una base de datos?**
R: Sí, reemplaza el cliente HTTP con uno que escriba en BD

**P: ¿Cómo agrego autenticación?**
R: Agrega `[Authorize]` en los controladores y configura JWT en Program.cs

**P: ¿Esto funciona en producción?**
R: Sí, está listo para producción. Solo agrégale autenticación y caché.

---

🚀 **¡Ahora sí! A ejecutar y divertirse con la API** 🚀
