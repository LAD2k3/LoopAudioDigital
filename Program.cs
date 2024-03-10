using LoopAudioDigital.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NuGet.Protocol.Core.Types;
using Microsoft.Extensions.Hosting;
using LoopAudioDigital.Services;
using LoopAudioDigital.Entity;
using Microsoft.Extensions.Hosting.Internal;
using LoopAudioDigital.Controllers;
using LoopAudioDigital.Services.implementation;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
builder.Services.AddScoped<ISongService,SongServices>();

builder.Services.AddScoped<IArtistService,ArtistServices>();

builder.Services.AddMvc();

builder.Services.AddControllers();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

/*builder.Services.AddIdentity<Artists,IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders(); */

//builder.Services.AddScoped<IService, Service>();

/*builder.Services.AddAuthentication()
   .AddGoogle(options =>
   {
       IConfigurationSection googleAuthNSection =
       config.GetSection("Authentication:Google");
       options.ClientId = googleAuthNSection["ClientId"];
       options.ClientSecret = googleAuthNSection["ClientSecret"];
   });*/
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Song/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseHttpsRedirection();

app.MapControllers();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Song}/{action=IndexSong}/{id?}");
app.MapRazorPages(
    
    );
app.Run();
