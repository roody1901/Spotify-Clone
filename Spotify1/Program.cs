using Spotify1.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IHomeRepository, HomeRepository>();

var app = builder.Build();

/* Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}*/

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapGet("/hello", () => {
    return new List<string>() {
        "Hello World!",
        "Hello Galaxy!",
        "Hello Universe!"
    };
});
app.MapDefaultControllerRoute();

app.Run();
