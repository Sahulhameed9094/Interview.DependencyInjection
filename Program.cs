using Interview.DependencyInjection.InterfacesDI;
using Interview.DependencyInjection.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// new instance for per request
builder.Services.AddTransient<ITransientService, TransientService>();

// single instance for http request
builder.Services.AddScoped<IScopedService, ScopedService>();
builder.Services.Decorate<IScopedService, LogScopedService>();

//single instance for entire application
builder.Services.AddSingleton<ISingletonService, SingletonService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
