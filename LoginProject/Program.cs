using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>(); 
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();


//builder.Services.AddTransient < IOrderService, Services.> ();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddControllers();
builder.Services.AddDbContext<MyStore_325950947Context>(option => option.UseSqlServer("Data Source=srv2\\PUPILS;Initial Catalog=MyStore_325950947;Trusted_Connection=True;TrustServerCertificate=True"));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();


builder.Services.AddControllers();


var app = builder.Build();


// Configure the HTTP request pipeline

if (app.Environment.IsDevelopment())

{

app.UseDeveloperExceptionPage();

}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();*/
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();  
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();




