

var builder = WebApplication.CreateBuilder(args);

// Good for sessions I think
builder.Services.AddDistributedMemoryCache();

// Sessions configuration
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add services to the container and needs to be done before builder.Build();.
builder.Services.AddMvc();

var app = builder.Build();

// Will use a session
app.UseSession();

// For using files we want to store in wwwroot I think?
app.UseStaticFiles();

// So user only don't have to type in the full URL for FeverCheck
app.MapControllerRoute(
    name: "fevercheck",
    pattern: "FeverCheck",
    defaults: new { controller = "Doctor", action = "FeverCheck" }
    );
app.MapControllerRoute(
    name: "guessinggames",
    pattern: "GuessingGame",
    defaults: new { controller = "Games", action = "GuessingGame" }
    );

// A default routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();