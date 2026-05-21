using BookLibrary.Api.Books;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSingleton<IBookStore, InMemoryBookStore>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapBookEndpoints();

app.Run();

// Marker type so test projects can use WebApplicationFactory<Program>.
public partial class Program;

