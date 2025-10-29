using BugStore;
using BugStore.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependency(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapEndpoints();

app.Run();
