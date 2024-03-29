using Infrastructure.MtGCard_API;
using MagicRepositories;
using MagicRepositories.Extensions;
using MagicRepositories.Repositories;
using Microsoft.EntityFrameworkCore;
using MtgApiManager.Lib.Service;
using MtGCard_Service.Interface;
using MtGCard_Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PortalContext>();

builder.Services.AddTransient<IMagicCardRepository, MagicCardRepository>();
builder.Services.AddTransient<IMtGCardRepository, SearchForCard>();
builder.Services.AddTransient<IMtgServiceProvider, MtgServiceProvider>();

builder.Services.AddTransient<MagicQuizService>();
builder.Services.AddTransient<MagicCardService>();

builder.Services.AddRepositories();

// Add services to the container.

builder.Services.AddAuthorization();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<PortalContext>();
    await dbContext.Database.MigrateAsync();
}

app.Run();