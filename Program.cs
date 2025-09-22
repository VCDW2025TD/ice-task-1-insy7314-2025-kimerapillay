using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

// Swagger & API explorer (handy for testing)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Force HTTPS for all requests
app.UseHttpsRedirection();

// HSTS only outside Development (best practice)
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

// Swagger UI when in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Simple test endpoint
app.MapGet("/ping", () =>
{
    return Results.Ok(new
    {
        ok = true,
        via = "https",
        now = DateTimeOffset.UtcNow
    });
});

app.Run();
