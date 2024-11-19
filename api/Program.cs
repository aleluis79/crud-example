using api.Services;
using Scalar.AspNetCore;

const string MyCustomPolicy = "_myCustomPolicy";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddSingleton<ITodoRepo, TodoRepo>();

builder.Services.AddControllers();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy(MyCustomPolicy, builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

//Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger(options => options.RouteTemplate = "/openapi/{documentName}.json");
app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "My API V1"));
app.MapScalarApiReference();
//}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(MyCustomPolicy);

app.Run();
