using DataAccessObjects;
using DataAccessObjects.Commons;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration.Get<AppConfiguration>() ?? new AppConfiguration();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddInfrastructuresServices(configuration.DatabaseConnection);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
