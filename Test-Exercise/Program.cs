using Test_Exercise.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient<HttpMapDataApi>(x =>
{
    x.BaseAddress = new Uri("https://nominatim.openstreetmap.org/search");
    x.DefaultRequestHeaders.Add("User-Agent", "Test-Exercise/1.0 (maxpotapnev2003@gmail.com)");
});


var app = builder.Build();

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles(new StaticFileOptions
    {
        ServeUnknownFileTypes = true,
    });
app.UseRouting();


app.MapControllerRoute(
name: "default",
pattern: "{controller=Base}/{action=Index}/{id?}"
);

app.Run();
