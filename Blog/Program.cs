using System.Text;
using Blog;
using Blog.Data;
using Blog.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };

});

builder
    .Services
    .AddControllers() //suporte a controllers
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true; //Desabilita o filtro padrão que retorna 400 Bad Request quando o ModelState � inv�lido
    });
builder.Services.AddDbContext<BlogDataContext>(); //torna o banco de dados um recurso do ASP.NET
builder.Services.AddTransient<TokenService>();


var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers(); //Faz o ASP.NET escutar e responder os endpoints definidos nos controller
//Um endpoint = rota + método HTTP (GET, POST, PUT, DELETE).

app.MapGet("/", () => "Processando...");

app.Run();
