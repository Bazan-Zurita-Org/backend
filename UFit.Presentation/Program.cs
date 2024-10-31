using UFit.Application;
using UFit.Infrastructure;
using UFit.Presentation.Endpoints;
using UFit.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.AddTraineeApi();
app.AddWorkoutEndpoints();
app.AddExerciseEndpoints();

app.Run();
