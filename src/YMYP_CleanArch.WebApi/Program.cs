using YMYP_CleanArch.Application;
using YMYP_CleanArch.Infrastructure;
using YMYP_CleanArch.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

CreateFirstUserMiddleware.CreateFirstUser(app);

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
