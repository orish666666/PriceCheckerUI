using PriceCheckerUI.Services;

var builder = WebApplication.CreateBuilder(args);

// Set Razor Pages root directory
builder.Services.AddRazorPages(options =>
{
    options.RootDirectory = "/Components/Pages";
});

builder.Services.AddHttpClient<ApiService, ApiService>(client =>
{
    client.BaseAddress = new Uri("http://127.0.0.1:6000");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.Run();