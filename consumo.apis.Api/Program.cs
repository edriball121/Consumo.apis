using consumo.apis.Application.UseCases;
using consumo.apis.Domain.Ports;
using consumo.apis.Infrastructure.HttpClients;
using consumo.apis.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Consumo APIs - JSONPlaceholder",
        Version = "v1",
        Description = "API para consumir datos desde JSONPlaceholder usando arquitectura hexagonal"
    });
});

// Registrar controladores
builder.Services.AddControllers();

// Registrar HttpClient para JSONPlaceholder
builder.Services.AddHttpClient<JsonPlaceholderClient>();

// Registrar Puertos (Interfaces del Dominio)
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

// Registrar Casos de Uso (Aplicaci�n)
builder.Services.AddScoped<IGetPostsUseCase, GetPostsUseCase>();
builder.Services.AddScoped<IGetUsersUseCase, GetUsersUseCase>();
builder.Services.AddScoped<IGetCommentsUseCase, GetCommentsUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Consumo APIs v1");
    });
}

app.UseHttpsRedirection();

// Mapear controladores
app.MapControllers();

app.Run();
