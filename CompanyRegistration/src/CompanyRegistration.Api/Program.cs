using CompanyRegistration.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICompaniesService, CompaniesService>();

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var connectionString = builder.Configuration["CompaniesDatabase:ConnectionString"];
var databaseName = builder.Configuration["CompaniesDatabase:DatabaseName"];
var collectionName = builder.Configuration["CompaniesDatabase:CollectionName"];

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