using Library.Application.Features.Books.Commands.CreateBook;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Library.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// ���������� ���� ������ (SQLite ��� ��������, ����� �������� �� SQL Server)
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// ���������� �����������
builder.Services.AddScoped<IBookRepository, BookRepository>(); // �����������
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateBookCommand).Assembly));


builder.Services.AddValidatorsFromAssembly(typeof(CreateBookCommand).Assembly);


// ��������� ����������� � Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// �������� Swagger (������ ��� ������������ API)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

// ����-�������� (����� �� ����������� �������������)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
    dbContext.Database.Migrate();
}

app.Run();  