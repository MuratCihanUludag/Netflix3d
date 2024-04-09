using Netflix3d.Persistence;
using Netflix3d.Mapper;
using Netflix3d.Application.Services;
using Netflix3d.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPersistenceService();

builder.Services.AddApplicationServices();

builder.Services.AddInfrastructureServices();

builder.Services.AddMapperService();


builder.Services.AddCors();

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("Allow", policy =>
    {
        policy.WithOrigins("http://localhost:5173").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ConfigureExpectionHandleingMiddleware();

app.UseHttpsRedirection();

app.UseCors("Allow");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
