using Library.Application.Features.Books.Commands.CreateBook;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Library.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Подключаем базу данных (SQLite для простоты, можно заменить на SQL Server)
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Подключаем зависимости
builder.Services.AddScoped<IBookRepository, BookRepository>(); // Репозиторий
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateBookCommand).Assembly));


builder.Services.AddValidatorsFromAssembly(typeof(CreateBookCommand).Assembly);


// Добавляем контроллеры и Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Включаем Swagger (удобно для тестирования API)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

// Авто-миграции (чтобы БД создавалась автоматически)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
    dbContext.Database.Migrate();
}

app.Run();  