using models_for_l12;
using Microsoft.EntityFrameworkCore;
using Lab12.Services;
using lab12.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавл€ем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<mobile_operator_Context>(options => options.UseSqlServer(connection));

builder.Services.AddTransient<lab12.Services.ICollection<users_tr>, SqlUsers>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapRazorPages();  // ƒобавл€ем маршрутизацию дл€ Razor Pages
// });

app.Run();