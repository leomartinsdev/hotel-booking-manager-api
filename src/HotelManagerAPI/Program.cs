using System.Text;
using HotelManagerAPI.Repository;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using HotelManagerAPI.Models;
using HotelManagerAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<HotelManagerAPIContext>();
builder.Services.AddScoped<IHotelManagerAPIContext, HotelManagerAPIContext>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddHttpClient<IGeoService, GeoService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    string file = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    string path = Path.Combine(AppContext.BaseDirectory, file);
    options.IncludeXmlComments(path);

    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Hotel Booking Manager API",
        Description = "Software de booking de várias redes de hóteis no formato de uma RESTful API com operações de CRUD.",
        Version = "v1"
    });
});
builder.Services.AddControllersWithViews()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddHttpClient();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://nominatim.openstreetmap.org",
                                              "https://openstreetmap.org");
                      });
});


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
    options.AddPolicy("Client", policy => policy.RequireClaim(ClaimTypes.Email));
    options.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Email).RequireClaim(ClaimTypes.Role, "admin"));
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
app.UseRouting();

// app.UseCors(MyAllowSpecificOrigins);
app.UseCors(c => c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthentication();

app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<HotelManagerAPIContext>();

    context.Database.Migrate();

    Seeder.SeedUserAdmin(context);
}

app.MapControllers();

app.Run();

public partial class Program { }