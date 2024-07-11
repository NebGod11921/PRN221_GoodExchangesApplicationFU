using DataAccessObjects;
using DataAccessObjects.Commons;
using DataAccessObjects.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration.Get<AppConfiguration>() ?? new AppConfiguration();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();
builder.Services.AddInfrastructuresServices(configuration.DatabaseConnection);
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.Configure<CookiePolicyOptions>(opts =>
{
    opts.MinimumSameSitePolicy = SameSiteMode.None;
    opts.HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.None;

});
builder.Services.AddSingleton(x => new PaypalClient(
        builder.Configuration["PaypalOptions:AppId"],
        builder.Configuration["PaypalOptions:AppSecret"],
        builder.Configuration["PaypalOptions:Mode"]
    ));

builder.Services.AddSession(opts =>
{
    opts.IdleTimeout = TimeSpan.FromSeconds(20);
    opts.Cookie.HttpOnly = true;
    opts.Cookie.IsEssential = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();



app.UseSession();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
