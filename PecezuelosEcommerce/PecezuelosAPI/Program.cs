//using PecezuelosRepositorio.DBContext;
using PecezuelosUtilidades;
using Microsoft.EntityFrameworkCore;
using PecezuelosRepositorio.DBContext;
using PecezuelosRepositorio.Contrato;
using PecezuelosRepositorio.Implementacion;
using PecezuelosServicio.Contrato;
using PecezuelosServicio.Implementacion;





var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbpecezuelosContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
});

builder.Services.AddTransient(typeof(IGenericoRepositorio<>), typeof(GenericoRepositorio<>));
builder.Services.AddScoped<IVentaRepositorio, VentaRepositorio>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<IVentaServicio, VentaServicio>();
builder.Services.AddScoped<ICategoriaServicio, CategoriaServicio>();
builder.Services.AddScoped<IDashboardService, DashboardServicio>();
builder.Services.AddScoped<IProductoService, ProductoServicio>();
builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
