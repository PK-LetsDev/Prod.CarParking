using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Prod.CarParking.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.Configure<IdentityOptions>(options => {

    options.Password.RequiredLength = 3;
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = false;

    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);

    options.SignIn.RequireConfirmedEmail = false;

});

builder.Services.ConfigureApplicationCookie(option => {
    option.LoginPath = "/Identity/Signin";
    option.AccessDeniedPath = "/Identity/AccessDenied";
    option.ExpireTimeSpan = TimeSpan.FromHours(10);
});

builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("MemberDep", p => {

        p.RequireRole("Member");
    });

    option.AddPolicy("AdminDep", p => {

        p.RequireRole("Admin");
    });
});
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
