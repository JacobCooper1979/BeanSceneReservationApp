using Microsoft.Extensions.Logging;
using BeanSceneReservationApp.Models;
using BeanSceneReservationApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BeanSeanReservationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<BeanSeanReservationDbContext>();

builder.Services.AddScoped<IAreaServices, AreaServices>();


// Email sender configuration
builder.Services.AddTransient<IEmailSender, EmailSender>(i =>
    new EmailSender(
        "smtp.gmail.com", // SMTP server address
        587,              // SMTP port
        "jacobcooper2302@gmail.com",     // SMTP username
        "ygwxudbyhzubvwvw"       // SMTP password
    ));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Seeding roles and users
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

    try
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        var roles = new[] { "Member", "Staff", "Manager" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        // Seeding manager user
        await SeedUser(userManager, "Manager@gmail.com", "Password1234!", "John", "Doe", new DateTime(1990, 1, 1), "Manager");

        // Seeding staff user
        await SeedUser(userManager, "Staff@gmail.com", "Password1234!", "Jane", "Smith", new DateTime(1990, 1, 1), "Staff");

        // Seeding member user
        await SeedUser(userManager, "Member@gmail.com", "Password1234!", "Craig", "Keys", new DateTime(1990, 1, 1), "Member");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred during initialization.");
    }
}

app.Run();

async Task SeedUser(UserManager<ApplicationUser> userManager, string email, string password, string firstName, string lastName, DateTime dateOfBirth, string role)
{
    var user = await userManager.FindByEmailAsync(email);
    if (user == null)
    {
        user = new ApplicationUser
        {
            UserName = email,
            Email = email,
            EmailConfirmed = true,
            FirstName = firstName,
            LastName = lastName,
            DateOfBirth = dateOfBirth
        };
        var result = await userManager.CreateAsync(user, password);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, role);
            await userManager.AddClaimAsync(user, new System.Security.Claims.Claim("role", role));
        }
    }
}
