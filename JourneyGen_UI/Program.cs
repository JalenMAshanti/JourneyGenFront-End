using Logic.API;
using Logic.Factories;
using Logic.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<LoginAPIService>();
builder.Services.AddScoped<MessagesAPIService>();
builder.Services.AddScoped<ExternalApiService>();
builder.Services.AddScoped<MessagesRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<BibleRepository>();
builder.Services.AddScoped<ImageRepository>();
builder.Services.AddScoped<EmailSenderRepository>();
builder.Services.AddSingleton<Random>();
builder.Services.AddScoped<ClientFactory>();

 

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
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
