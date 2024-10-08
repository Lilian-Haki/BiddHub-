using Microsoft.AspNetCore.Identity;
using BiddHub.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using BiddHub.Models.Authentication.Register;
using User.Management.Service.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

//builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
//For Entity Frameworks
//To configure database with DbContext that we just created. In the Program.cs add the database to builder.Services:
 var configuration = builder.Configuration;


// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//(Add Identity) Register Identity services
builder.Services.AddIdentity<RegisterUser,IdentityRole<Guid>>()
    .AddEntityFrameworkStores<ApplicationDbContext> ()
    .AddDefaultTokenProviders();

//Add JWT Authentication
//(AddIdentity: Sets up ASP.NET Identity services for user management.)(AddJwtBearer: Configures JWT-based authentication. The token validation parameters ensure that the JWT token is valid and hasn't been tampered with.)
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Add services to the container.
builder.Services.AddControllers();

//builder.Services.AddMvc();

//Register the service in the Program.cs file: Modify the Program.cs to configure dependency injection for EmailService and bind the SmtpSettings:
// Bind SmtpSettings from appsettings.json
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
builder.Services.AddTransient<IEmailService, EmailService>();// Register EmailService

// *If* you need access to generic IConfiguration this is **required**
builder.Services.AddSingleton<IConfiguration>(configuration);

// Add functionality to inject IOptions<T>
builder.Services.AddOptions();
var app = builder.Build();


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

//// Ensure your middleware and routes are configured properly

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
