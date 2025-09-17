using Dal_Book;
using Dal_Book.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ✅ 1. Ensure appsettings.json is loaded (it loads by default in ASP.NET Core)
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// ✅ 2. Get the connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' is missing in appsettings.json.");
}

// ✅ 3. Register the DbContext with the connection string
builder.Services.AddDbContext<BookContext>(options =>
    options.UseSqlServer(connectionString));

// ✅ 4. Register your BookService for Dependency Injection
builder.Services.AddScoped<IBookService, BookService>();

// ✅ Add controllers and views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ✅ Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ✅ Set the default route to Book Controller
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Book}/{action=Index}/{id?}");

app.Run();
