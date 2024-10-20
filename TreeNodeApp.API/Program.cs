using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using System;
using TreeNodeApp.API.ExceptionService;
using TreeNodeApp.API.Mappings;
using TreeNodeApp.Application.Interfaces;
using TreeNodeApp.Application.Services;
using TreeNodeApp.Infrastructure.Data;
using TreeNodeApp.Infrastructure.Interfaces;
using TreeNodeApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddScoped<INodeService, NodeService>();
builder.Services.AddScoped<ITreeService, TreeService>();
builder.Services.AddScoped<IExceptionLogService, ExceptionLogService>();
builder.Services.AddScoped<IExceptionService, ExceptionService>();

builder.Services.AddScoped<INodeRepository, NodeRepository>();
builder.Services.AddScoped<ITreeRepository, TreeRepository>();
builder.Services.AddScoped<IExceptionLogRepository, ExceptionLogRepository>();

builder.Services.AddControllers(options => options.Filters.Add<ExceptionFilter>())
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAll");

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();

    await DbInitializer.InitializeAsync(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TreeNodeApp API v1"));
}

app.UseHttpsRedirection();

app.Run();
