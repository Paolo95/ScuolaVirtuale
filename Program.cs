using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScuolaVirtuale.Support;
using System.Net;

using Microsoft.IdentityModel.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddAuth0WebAppAuthentication(options => {
    var auth0Domain = builder.Configuration["Auth0:Domain"];
    var auth0ClientId = builder.Configuration["Auth0:ClientId"];

    if (!string.IsNullOrEmpty(auth0Domain) && !string.IsNullOrEmpty(auth0ClientId)) {
        options.Domain = auth0Domain;
        options.ClientId = auth0ClientId;
    }
});

builder.Services.ConfigureSameSiteNoneCookies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();
app.UseCookiePolicy();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
