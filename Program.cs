using Microsoft.AspNetCore.Mvc;
using Payments.Authorizer.Responses;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.MapGet("/healtly", () => Results.Ok("Health"))
    .WithOpenApi();

app.MapPost("/payment-approval", ([FromBody] PaymentApprovalRequest request) =>
{
    bool isApproved = (request.Amount % 1 == 0);
   
    return Results.Ok(new PaymentApprovalResponse()
    {
        Amount = request.Amount,
        Approved = isApproved
    });
})
.WithName("PaymentAuthorizer")
.WithOpenApi();

app.Run();