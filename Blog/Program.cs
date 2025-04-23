using Blog.Data;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddControllers() //suporte a controllers
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true; //Desabilita o filtro padr�o que retorna 400 Bad Request quando o ModelState � inv�lido
    });
builder.Services.AddDbContext<BlogDataContext>(); //torna o banco de dados um recurso do ASP.NET

var app = builder.Build(); 
app.MapControllers(); //Faz o ASP.NET escutar e responder os endpoints definidos nos controller
//Um endpoint = rota + m�todo HTTP (GET, POST, PUT, DELETE).

app.MapGet("/", () => "C�digo Pendente...");

app.Run();
