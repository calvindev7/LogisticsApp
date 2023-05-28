using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add authentication
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:7078"; // URL del servidor de autenticación
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false // Si se debe validar el público objetivo del token
        };
    });

var connectionString = "Data Source=CalvinDevPro7;Initial Catalog=LogisticsApp;Integrated Security=True; TrustServerCertificate=True";
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));


// Add authorization
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

// Use authentication
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
