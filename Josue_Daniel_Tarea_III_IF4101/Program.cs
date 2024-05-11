
using Microsoft.EntityFrameworkCore;
using Skill.BW.CU;
using Skill.BW.Interfaces.BW;
using Skill.BW.Interfaces.DA;
using Skill.DA.Acciones;
using Skill.DA.Contexto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddTransient<IGestionarProductoBW, GestionarProductoBW>();
builder.Services.AddTransient<IGestionarProductoDA, GestionarProductoDA>();
builder.Services.AddTransient<IGestionarListaDeseosBW, GestionarListaDeseosBW>();
builder.Services.AddTransient<IGestionarListaDeseosDA, GestionarListaDeseosDA>();

builder.Services.AddDbContext<Skill.DA.Contexto.TareaIIIContext>(options =>
{
    var connectionString = "Server=(LocalDB)\\LocalServerJosue;Database=PruebaTareaIII;Trusted_Connection=True;TrustServerCertificate=True";
    options.UseSqlServer(connectionString);
});
var app = builder.Build();

app.UseCors("AllowOrigin");
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TareaIIIContext>();
    context.Database.Migrate();
}


// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
