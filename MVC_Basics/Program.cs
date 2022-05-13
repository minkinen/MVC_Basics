

var builder = WebApplication.CreateBuilder(args);

// Add services to the container and needs to be done before builder.Build();.
builder.Services.AddMvc();

var app = builder.Build();

// For using files we want to store in wwwroot I think?
app.UseStaticFiles();

// A default routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();