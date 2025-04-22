using Blog.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); //suporte a controllers
builder.Services.AddDbContext<BlogDataContext>(); //torna o banco de dados um recurso do ASP.NET

var app = builder.Build(); 
app.MapControllers(); //Faz o ASP.NET escutar e responder os endpoints definidos nos controller
//Um endpoint = rota + método HTTP (GET, POST, PUT, DELETE).

app.MapGet("/", () => "Hello World!");

app.Run();
