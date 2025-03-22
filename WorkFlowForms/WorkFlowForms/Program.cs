using WorkFlowForms.Service;
using WorkFlowForms.Service.Interface;
using Microsoft.Extensions.FileProviders;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add controllers
builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IDocService, DocService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable static files
app.UseStaticFiles();

// 配置额外的静态文件目录，确保可以访问webpack生成的文件
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "dist")),
    RequestPath = ""
});

// Enable routing
app.UseRouting();

// Enable authorization (if needed)
// app.UseAuthorization();

// Map controllers
app.MapControllers();

// 处理SPA路由
app.MapFallbackToFile("index.html");

app.Run();
