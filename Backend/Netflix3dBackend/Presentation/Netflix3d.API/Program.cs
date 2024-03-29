using Netflix3d.Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPersistenceService();

builder.Services.AddCors();

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder =>
{
    builder.WithOrigins("").AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
