using Identidad.IdentityPolicies;
using Identidad.Models;
using Identidad.PoliticaPersonalizada;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura los servicios
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

// Configura el DbContext
builder.Services.AddDbContext<IdentidadDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configura Identity
builder.Services.AddIdentity<AppUsuario, IdentityRole>()
    .AddEntityFrameworkStores<IdentidadDbContext>()
    .AddDefaultTokenProviders();


// Esta funcion esta asociada a la politica de contraseñas de identity
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireDigit = true;
    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
});

// Establecer la politica de password personalizada en clase PoliticaPassPersonalizada
builder.Services.AddTransient<IPasswordValidator<AppUsuario>, PoliticaPassPersonalizada>();
builder.Services.AddTransient<IUserValidator<AppUsuario>, PoliticaUsuarioEmailPersonalizada>();

// Ruta de autenticacion - Si se cambia debe hacerse manualmente
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = ".AspNetCore.identity.Application";
    // Se almacena durante 20 minutos en el navegador
    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    options.SlidingExpiration = true;
});


// Se establecen dos politicas de acuerdo a los Claims
// Politica 01
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Segundo Email", policy =>
    {
        policy.RequireRole("Administración");
        policy.RequireClaim("segundocorreo", "prueba10_jose@prueba.com");       // Si en el claim no aparece de esta manera no generara autorizacion de ingreso
    });
});


builder.Services.AddTransient<IAuthorizationHandler, ControladorPermitirUsuarios>();
builder.Services.AddTransient<IAuthorizationHandler, PermitirControladorPrivado>();

// Politica 02
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("PermitirUsuarios", policy =>
    {
        policy.AddRequirements(new PoliticaPermisosUsuario("espana"));
    });
});


// Politica 03
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AccesoPrivado", policy =>
    {
        policy.AddRequirements(new PoliticaPermitirPrivado());
    });
});


var app = builder.Build();

// Configura el pipeline de solicitudes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();