using System.Text;
using TrybeHotel.Repository;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TrybeHotel.Models;
using TrybeHotel.Services;
using System.Security.Claims;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;
=======
>>>>>>> faseC/leonardo-martins-trybe-hotel-c

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TrybeHotelContext>();
builder.Services.AddScoped<ITrybeHotelContext, TrybeHotelContext>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
<<<<<<< HEAD
=======
builder.Services.AddHttpClient<IGeoService, GeoService>();
>>>>>>> faseC/leonardo-martins-trybe-hotel-c

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddHttpClient();

<<<<<<< HEAD
=======
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.WithOrigins("https://nominatim.openstreetmap.org",
                                              "https://openstreetmap.org");
                      });
});

>>>>>>> faseC/leonardo-martins-trybe-hotel-c

builder.Services.Configure<TokenOptions>(
    builder.Configuration.GetSection(TokenOptions.Token)
);

var tokenOptions = builder.Configuration.GetSection(TokenOptions.Token);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenOptions.GetValue<string>("Secret")))
    };
});

builder.Services.AddAuthorization(options =>
{
<<<<<<< HEAD
    options.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Email).RequireClaim(ClaimTypes.Role, "admin"));
    options.AddPolicy("Client", policy => policy.RequireClaim(ClaimTypes.Email));
=======
    options.AddPolicy("Client", policy => policy.RequireClaim(ClaimTypes.Email));
    options.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Email).RequireClaim(ClaimTypes.Role, "admin"));
>>>>>>> faseC/leonardo-martins-trybe-hotel-c
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
<<<<<<< HEAD
=======
app.UseRouting();

// app.UseCors(MyAllowSpecificOrigins);
app.UseCors(c => c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
>>>>>>> faseC/leonardo-martins-trybe-hotel-c

app.UseAuthentication();

app.UseAuthorization();

<<<<<<< HEAD
app.UseCors(c => c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
=======
>>>>>>> faseC/leonardo-martins-trybe-hotel-c

app.MapControllers();

app.Run();

public partial class Program { }