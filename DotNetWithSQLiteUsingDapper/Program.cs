using DotNetWithSQLiteUsingDapper;
using DotNetWithSQLiteUsingDapper.DbServices;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddSingleton<DataContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
{
    // serialize enums as strings in api responses (e.g. Role)
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

    // ignore omitted parameters on models to enable optional params (e.g. User update)
    x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddInfrastructure();
builder.Services.AddScoped(n =>
{
    string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sqlite");
    Directory.CreateDirectory(folderPath);
    //string filePath = Path.Combine(folderPath, builder.Configuration.GetSection("DbFileName").Value!);
    //string connectionString = $"Data Source={filePath};Version=3;";
    string connectionString = "Data Source=Blog.db;Version=3;";
    return new DataContext(connectionString);
});
var app = builder.Build();

//{
//    using var scope = app.Services.CreateScope();
//    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
//    await context.Init();
//}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
