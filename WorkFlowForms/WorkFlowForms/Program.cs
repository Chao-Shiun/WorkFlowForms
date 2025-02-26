using WorkFlowForms.Service;
using WorkFlowForms.Service.Interface;

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

// Enable routing
app.UseRouting();

// Enable authorization (if needed)
// app.UseAuthorization();

// Map controllers
app.MapControllers();

app.Run();
