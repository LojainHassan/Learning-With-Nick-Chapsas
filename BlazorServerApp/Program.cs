using BlazorServerApp.Data;
using BlazorServerApp.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddTransient<RandomService>();
//builder.Services.AddTransient<RandomService>();
builder.Services.AddScoped<RandomService>();
//To show the differencr=e between AddTransient and AddSingleton, you can uncomment the above line and comment the below line.
//Then you will see that the RandomService will be created only once for the entire application when using AddSingleton,
//while it will be created every time it is requested when using AddTransient.
//Guid is a unique identifier that is generated when the RandomService is created.
//In singelton, the same instance of RandomService will be used throughout the application, so the RandomGuid will remain the same.
//In transient, a new instance of RandomService will be created every time it is requested, so the RandomGuid will be different each time.
//In scoped, a new instance of RandomService will be created for each request, so the RandomGuid will be different for each request but the same for the same request.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
