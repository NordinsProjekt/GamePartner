using Infrastructure.MtGCard_API;
using MagicRepositories;
using MagicRepositories.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using MtGCard_Service.Interface;
using MtGCard_Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<PortalContext>();
builder.Services.AddTransient <IMagicCardRepository,MagicCardRepository>();
builder.Services.AddTransient<IMtGCardRepository, SearchForCard>();
builder.Services.AddTransient<IMagicSetRepository, MagicSetRepository>();
builder.Services.AddTransient<ICardTypeRepository, CardTypeRepository>();
builder.Services.AddTransient<ISuperCardTypeRepository, SuperCardTypeRepository>();
builder.Services.AddTransient<IMagicAbilityRepository, MagicAbilityRepository>();
builder.Services.AddTransient<IMagicLegalityRepository, MagicLegalityRepository>();

// Register your service as transient
builder.Services.AddTransient<MagicCardService>();
// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddMicrosoftIdentityWebApi(builder.Configuration);
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
