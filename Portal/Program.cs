using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Infrastructure.MtGCard_API;
using Application.MtGCard_Service.Interface;
using MtGCard_Service;
using MtGCard_API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<IMtGCardRepository, SearchForCard>();
builder.Services.AddSingleton<IMtGSearchBuffer, SearchBuffer>();
//builder.Services.AddScoped(_ => new MtGCommanderService(new SearchForCard(), 4));
builder.Services.AddScoped<MtGCommanderService>();
builder.Services.AddSession();
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
