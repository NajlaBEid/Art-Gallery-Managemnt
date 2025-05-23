using Art_Gallery_Management.Data;
using Art_Gallery_Management.Repositories.ArtistRepository;
using Art_Gallery_Management.Repositories.ArtWorkRepository;
using Art_Gallery_Management.Repositories.ExhibitionRepository;
using Art_Gallery_Management.Repositories.ManagerRepository;
using Art_Gallery_Management.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Serilog.Sinks.Elasticsearch;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//register 
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<IManagerRepository, ManagerRepository>();
builder.Services.AddScoped<IExhibitionRepository, ExhibitionRepository>();
builder.Services.AddScoped<IArtWorkRepository, ArtWorkRepository>();





Log.Logger = new LoggerConfiguration()
    .WriteTo.Console() // Logs to the console
    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://127.0.0.1:9200"))
    {
        AutoRegisterTemplate = true, // Automatically register index template
        IndexFormat = "logs", // Define index name format
        ModifyConnectionSettings = conn =>
            conn.BasicAuthentication("elastic", "elastic") // Replace <password> with your Elasticsearch password
    })
    .CreateLogger();

builder.Host.UseSerilog();


//Bind BasicAuth 
builder.Services.Configure<BasicAuthSeetings>(builder.Configuration.GetSection("BasicAuth"));             

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthMiddleware>("BasicAuthentication", null);

builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();

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
