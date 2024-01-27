using CrudAPI_Sqlite.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados SQLite
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona os serviços necessários
builder.Services.AddControllers();

// Adiciona a configuração do Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Habilita o middleware do Swagger no pipeline de solicitação HTTP
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
