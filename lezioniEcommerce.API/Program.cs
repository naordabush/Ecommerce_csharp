using lezioniEcommerce.API.Controllers.DataModel;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using lezioniEcommerce.API.Repos.Interfaces;
using lezioniEcommerce.API.Repos.Classes;
using lezioniEcommerce.API.Services.Classes;
using lezioniEcommerce.API.Profiles;
using lezioniEcommerce.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Newtonsoft JSON configuration
builder.Services.AddMvc().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.PropertyNamingPolicy = null;
    o.JsonSerializerOptions.DictionaryKeyPolicy = null;
});

// Register DbContext
var serviceDBConnectionString = builder.Configuration.GetConnectionString("ServiceDB");
builder.Services.AddDbContext<DB_ECOMMERCEContext>(options =>
    options.UseSqlServer(serviceDBConnectionString)
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution), ServiceLifetime.Scoped);

// Register repositories
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
//builder.Services.AddScoped<IBrandsRepository, BrandsRepository>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<IProductsCategoriesRepository, ProductsCategoriesRepository>();
builder.Services.AddScoped<ICartsRepository, CartsRepository>();
builder.Services.AddScoped<ICartItemsRepository, CartItemsRepository>();

// Register services
builder.Services.AddScoped</*IUsersService,*/ UsersService>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IProductsCategoriesService, ProductsCategoriesService>();
//builder.Services.AddScoped<IBrandsService, BrandsService>();
builder.Services.AddScoped<ICartsService, CartsService>();
builder.Services.AddScoped<ICartItemsService, CartItemsService>();

// Configure AutoMapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new USERProfile());
    mc.AddProfile(new PRODUCTProfile());
    mc.AddProfile(new CATEGORYProfile());
    mc.AddProfile(new PRODUCTCATEGORYProfile());
    //mc.AddProfile(new BRANDProfile());
    mc.AddProfile(new CARTProfile());
    mc.AddProfile(new CARTITEMProfile());
});
IMapper mapper = mapperConfig.CreateMapper();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable CORS
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();

app.Run();

