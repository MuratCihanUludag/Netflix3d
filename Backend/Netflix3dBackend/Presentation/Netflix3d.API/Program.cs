using Netflix3d.Persistence;
using Netflix3d.Application;
using Netflix3d.Application.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPersistenceService();

builder.Services.AddApplicationServices(builder.Configuration);


builder.Services.AddCors();

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
