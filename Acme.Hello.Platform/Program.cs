using Acme.Hello.Platform.Generic.Domain.Model.Entities;
using Acme.Hello.Platform.Generic.Interfaces.REST.Assemblers;
using Acme.Hello.Platform.Generic.Interfaces.REST.Resources;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.MapGet("/", () => "Hello World!");

// Greetings endpoint 
app.MapGet("/greetings", (string? firstName, string? lastName) =>
{
    var developer = !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName)
        ? new Developer(firstName, lastName)
        : null;
    var response = GreetDeveloperAssembler.ToResponseFromEntity(developer);
    return Results.Ok(response);
})
.WithName("GetGreetings")
.WithOpenApi();

app.MapPost("/greetings", (GreetDeveloperRequest? request) =>
{
    var developer = DeveloperAssembler.ToEntityFromRequest(request);
    var response = GreetDeveloperAssembler.ToResponseFromEntity(developer);
    return Results.Created("/greetings", response);
})
.WithName("CreateGreetings")
.WithOpenApi();

app.UseHttpsRedirection();

app.Run();