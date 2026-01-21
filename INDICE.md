# 📑 ÍNDICE DE DOCUMENTACIÓN

## 🚀 Comienza Aquí

1. **[README.md](README.md)** ← Empieza aquí
   - Descripción general del proyecto
   - Estructura básica
   - Requisitos del sistema

2. **[INICIO_RAPIDO.md](INICIO_RAPIDO.md)** ← Para ejecutar inmediatamente
   - Comandos para compilar y ejecutar
   - Ejemplos de pruebas rápidas
   - Troubleshooting básico

## 🎓 Aprende la Arquitectura

3. **[DIAGRAMA_VISUAL.md](DIAGRAMA_VISUAL.md)** ← Visual y fácil de entender
   - Diagramas ASCII del flujo completo
   - Ciclo de vida de una petición
   - Distribución de clases

4. **[ARQUITECTURA.md](ARQUITECTURA.md)** ← Explicación detallada
   - Qué es arquitectura hexagonal
   - Por qué se usa
   - Ventajas de esta arquitectura
   - Próximos pasos para mejorar

5. **[GUIA_VISUAL.md](GUIA_VISUAL.md)** ← Más diagramas y flujos
   - Flores completas del proyecto
   - Detalles de implementación
   - Comparación con otras arquitecturas

## 🛠️ Usa la API

6. **[USO_API.md](USO_API.md)** ← Ejemplos de peticiones HTTP
   - Todos los endpoints disponibles
   - Respuestas de ejemplo
   - Ejemplos con cURL y PowerShell

## ✅ Verifica tu Implementación

7. **[CHECKLIST.md](CHECKLIST.md)** ← Validación completa
   - Verificaciones de compilación
   - Estructura de carpetas
   - Endpoints configurados
   - Estado final

## 📝 Referencia de Implementación

8. **[IMPLEMENTACION_RESUMIDA.md](IMPLEMENTACION_RESUMIDA.md)** ← Resumen
   - Qué se implementó
   - Endpoints disponibles
   - Buenas prácticas aplicadas
   - Sugerencias para mejorar

## 🧪 Tests

9. **[EJEMPLO_TESTS.cs](EJEMPLO_TESTS.cs)** ← Referencia para tests
   - Ejemplo de tests unitarios
   - Cómo mockear repositorios
   - Instrucciones para implementar tests

---

## 📊 Mapa de Contenido por Tipo de Usuario

### 👶 Soy Principiante

1. Lee **README.md**
2. Ve **DIAGRAMA_VISUAL.md**
3. Ejecuta **INICIO_RAPIDO.md**
4. Lee **ARQUITECTURA.md**
5. Juega con **USO_API.md**

### 👨‍💻 Soy Desarrollador Intermedio

1. Revisa **ARQUITECTURA.md**
2. Estudia **DIAGRAMA_VISUAL.md**
3. Explora los Controllers en la carpeta `Api/Controllers`
4. Lee los UseCases en `Application/UseCases`
5. Revisa los Repositories en `Infrastructure/Repositories`

### 🎯 Quiero Extender el Proyecto

1. Lee **IMPLEMENTACION_RESUMIDA.md**
2. Revisa **EJEMPLO_TESTS.cs** para crear tests
3. Modifica los Controllers según necesites
4. Agrega nuevos UseCases
5. Extiende el JsonPlaceholderClient si necesitas más endpoints

### 🔧 Necesito Debuggear

1. Lee **CHECKLIST.md**
2. Consulta **INICIO_RAPIDO.md** sección "¿Algo Roto?"
3. Revisa los logs en la consola
4. Prueba los endpoints en Swagger UI

---

## 🎯 Objetivos de Aprendizaje

Después de completar este proyecto, entenderás:

```
✅ Arquitectura Hexagonal (Puertos y Adaptadores)
✅ Separación de responsabilidades (SOLID)
✅ Inyección de Dependencias
✅ Async/Await en C#
✅ DTOs (Data Transfer Objects)
✅ Consumo de APIs REST externas
✅ Deserialization JSON
✅ Logging y manejo de errores
✅ RESTful API design
✅ Buenas prácticas de desarrollo
```

---

## 📋 Checklist de Lectura Recomendada

Para aprender en orden:

- [ ] README.md (5 min)
- [ ] INICIO_RAPIDO.md (5 min)
- [ ] Ejecuta `dotnet run` (2 min)
- [ ] Explora Swagger UI (5 min)
- [ ] DIAGRAMA_VISUAL.md (15 min)
- [ ] ARQUITECTURA.md (20 min)
- [ ] USO_API.md (10 min)
- [ ] Revisa el código en cada carpeta (30 min)
- [ ] EJEMPLO_TESTS.cs (15 min)
- [ ] Intenta crear tu propio caso de uso (30 min)

**Total: ~2.5 horas de aprendizaje**

---

## 🔗 Enlaces Rápidos

### Archivos de Configuración

- [Program.cs](consumo.apis.Api/Program.cs) - Inyección de dependencias

### Controladores

- [PostsController.cs](consumo.apis.Api/Controllers/PostsController.cs)
- [UsersController.cs](consumo.apis.Api/Controllers/UsersController.cs)
- [CommentsController.cs](consumo.apis.Api/Controllers/CommentsController.cs)

### Casos de Uso

- [GetPostsUseCase.cs](consumo.apis.Application/UseCases/GetPostsUseCase.cs)
- [GetUsersUseCase.cs](consumo.apis.Application/UseCases/GetUsersUseCase.cs)
- [GetCommentsUseCase.cs](consumo.apis.Application/UseCases/GetCommentsUseCase.cs)

### Repositorios

- [PostRepository.cs](consumo.apis.Infrastructure/Repositories/PostRepository.cs)
- [UserRepository.cs](consumo.apis.Infrastructure/Repositories/UserRepository.cs)
- [CommentRepository.cs](consumo.apis.Infrastructure/Repositories/CommentRepository.cs)

### Cliente HTTP

- [JsonPlaceholderClient.cs](consumo.apis.Infrastructure/HttpClients/JsonPlaceholderClient.cs)

### Entidades de Dominio

- [Post.cs](consumo.apis.Domain/Entities/Post.cs)
- [User.cs](consumo.apis.Domain/Entities/User.cs)
- [Comment.cs](consumo.apis.Domain/Entities/Comment.cs)

---

## 🎓 Recursos Externos

### Arquitectura Hexagonal

- [Hexagonal Architecture Pattern](<https://en.wikipedia.org/wiki/Hexagonal_architecture_(software)>)
- [Puertos y Adaptadores](https://blog.cleancoder.com)

### C# y ASP.NET Core

- [Microsoft Learn - C#](https://learn.microsoft.com/es-es/dotnet/csharp/)
- [ASP.NET Core Documentation](https://learn.microsoft.com/es-es/aspnet/core/)

### API

- [JSONPlaceholder - Fake API](https://jsonplaceholder.typicode.com)
- [REST API Best Practices](https://restfulapi.net)

### Testing

- [xUnit.net Documentation](https://xunit.net)
- [Moq - Mocking Library](https://github.com/moq/moq4)

---

## 💡 Tips Útiles

1. **Swagger es tu amigo** - Úsalo para explorar todos los endpoints
2. **Los logs son útiles** - Revísalos en la consola cuando algo falle
3. **Empieza simple** - No intentes agregar todo de una vez
4. **Lee el código** - El mejor aprendizaje es revisar cada clase
5. **Experimenta** - Modifica los casos de uso y ve qué pasa
6. **Prueba los endpoints** - Usa Postman o PowerShell para probar

---

## 🆘 Problemas Comunes

### ❌ "No se puede conectar a JSONPlaceholder"

→ Revisa tu conexión a internet

### ❌ "Error en Program.cs"

→ Asegúrate de que las referencias a Infrastructure están correctas

### ❌ "Swagger no muestra los endpoints"

→ Revisa que los controladores tengan `[ApiController]` y `[Route]`

### ❌ "El puerto 5001 está ocupado"

→ Cambia el puerto en `launchSettings.json`

---

## ✨ Siguientes Pasos

1. **Aprende** - Lee la documentación
2. **Ejecuta** - Compila y corre la aplicación
3. **Experimenta** - Modifica el código
4. **Extiende** - Agrega nuevas funcionalidades
5. **Comparte** - Muestra tu proyecto

---

**¡Bienvenido a tu viaje de aprendizaje! 🚀**

Si tienes dudas, revisa la documentación corresponiente.
Si la documentación no es clara, ¡intenta leer el código!
El mejor maestro es el experiencia.

---

_Última actualización: Enero 2026_
_Proyecto: Consumo.apis - Arquitectura Hexagonal_
