using UFit.Application;
using UFit.Infrastructure;
using UFit.Presentation.Endpoints;
using UFit.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
}

//app.UseHttpsRedirection();

app.UseAuthentication();

app.UseCors("AllowAll");

app.UseAuthorization();

app.AddTraineeApi();
app.AddWorkoutEndpoints();
app.AddExerciseEndpoints();
app.AddChallengeEndpoints();
app.AddDuelEndpoints();
app.AddRankingEndpoints();
app.AddDietEntpoints();

app.Run();
