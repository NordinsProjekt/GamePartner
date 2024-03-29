using Infrastructure.MtGCard_API;
using MtGCard_API;
using GenerateGuid.Extensions;
using MtGCard_Service.Extensions;
using MtgApiManager.Lib.Service;
using MtGCard_Service.Interface;
using MtGCard_Service;
using MtGCard_Service.Services;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<IMtgServiceProvider, MtgServiceProvider>();
builder.Services.AddTransient<IMtGCardRepository, SearchForCard>();
builder.Services.AddTransient<IMtGQuizService, MtGQuizService>();
builder.Services.AddSingleton<IMtGSearchBuffer, SearchBuffer>();
builder.Services.AddSingleton<ICardSetBuffer, CardSetBuffer>();
builder.Services.AddTransient<IMagicCardService, MagicCardService>();
builder.Services.AddMtGBoardState();
builder.Services.AddSession();
builder.Services.AddGuidGenerator();

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
