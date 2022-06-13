using DAL_Project2;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DAL_Project2.Entitys;
using System.Reflection;
using BLL_Project2.Interfaces;
using BLL_Project2.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BLL_Project2.Configurations;
using BLL_Project2;
using DAL_Project2.Interfaces;
using DAL_Project2.Repository;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using WEBAPI_Project2.Helpers;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMapper();

builder.Services.AddCors();

var migrationsAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;

builder.Services.AddDbContext<DBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<DBContext>()
    ;

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//                .AddJwtBearer(o =>
//                {
//                    o.RequireHttpsMetadata = false;
//                    o.SaveToken = false;
//                    o.TokenValidationParameters = new TokenValidationParameters
//                    {
//                        ValidateIssuerSigningKey = true,
//                        ValidateIssuer = true,
//                        ValidateAudience = true,
//                        ValidateLifetime = true,
//                        ClockSkew = TimeSpan.Zero,
//                        ValidIssuer = builder.Configuration["JWT:Issuer"],
//                        ValidAudience = builder.Configuration["JWT:Audience"],
//                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
//                    };
//                });

//var jwtSection = builder.Configuration.GetSection("JWT");
//builder.Services.Configure<JWT>(jwtSection);
//var JWT = jwtSection.Get<JWT>();
//var key = Encoding.ASCII.GetBytes(JWT.Key);

//builder.Services.AddAuthentication("OAuth").AddJwtBearer("OAuth",options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidIssuer = JWT.Issuer,
//        ValidAudience = JWT.Audience,
//        IssuerSigningKey = new SymmetricSecurityKey(key),
//    };
//});


builder.Services.AddTransient<IOrdersRepository, OrdersRepository>();
builder.Services.AddTransient<IOffersRepository, OffersRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddTransient<IIdentityService, IdentityService>();
builder.Services.AddTransient<IIdentity, Identity>();
builder.Services.AddTransient<IOffersService,OffersService>();
builder.Services.AddTransient<IOrdersService, OrdersService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddTransient<IValidatorFactory, ServiceProviderValidatorFactory>();
builder.Services.AddMvc(options =>
{
    options.EnableEndpointRouting = false;
}).AddFluentValidation(configuration =>
{
    configuration.RegisterValidatorsFromAssemblies(
        AppDomain.CurrentDomain.GetAssemblies());
});
                    //.AddFluentValidation(configuration =>
                    //{
                    //    configuration.RegisterValidatorsFromAssemblies(
                    //        AppDomain.CurrentDomain.GetAssemblies());
                    //});


builder.Services.AddIdentityCore<User>()
                    .AddRoles<IdentityRole>()
                    .AddSignInManager<SignInManager<User>>()
                    .AddDefaultTokenProviders()
                    .AddEntityFrameworkStores<DBContext>();

builder.Services.AddMvc();



builder.Services.AddControllers();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Title = "WebAPI",
//        Version = "v1"
//    });

//    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        Description = @"JWT Authorization header using the Bearer scheme.
//                                    Enter 'Bearer' [space] and then your token in the
//                                    text input below. Example: 'Bearer 12345abcdef'",
//        Name = "Authorization",
//        In = ParameterLocation.Header,
//        Type = SecuritySchemeType.ApiKey,
//        Scheme = "Bearer"
//    });

//    c.AddSecurityRequirement(new OpenApiSecurityRequirement
//                {
//                    {
//                        new OpenApiSecurityScheme
//                        {
//                            Reference = new OpenApiReference
//                            {
//                                Type = ReferenceType.SecurityScheme,
//                                Id = "Bearer"
//                            },
//                            Scheme = "oauth2",
//                            Name = "Bearer",
//                            In = ParameterLocation.Header,

//                        },
//                        new List<string>()
//                    }
//                });
//});


var app = builder.Build();

app.UseMiddleware<JwtMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseEndpoints(x => x.MapControllers());

app.MapControllers();


app.Run();
