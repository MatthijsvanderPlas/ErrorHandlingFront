using ErrorHandlingFront.Application.Common;
using ErrorHandlingFront.Application.Common.Composers;
using ErrorHandlingFront.Application.MessageService;
using ErrorHandlingFront.Infrastructure.Common;
using Radzen;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddApplicationFront();
builder.Services.AddInfrastructureFront();
builder.Services.AddScoped<MessageService>();

builder.Services.AddRadzenComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();