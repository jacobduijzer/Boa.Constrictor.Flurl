var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/", (string name) => $"Hello {name}!");

app.Run();

public partial class Program { }