using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Project.BLL.Mapper;
using Project.BLL.Repository;
using Project.BLL.Services;
using Project.DAL.ConnectionData;
using Project.PL.Languages;
using System.Globalization;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddControllersWithViews()
//        .AddNewtonsoftJson(options =>
//            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});



// Resources
builder.Services.AddMvc()
       .AddDataAnnotationsLocalization(options =>
       {
           options.DataAnnotationLocalizerProvider = (type, factory) =>
               factory.Create(typeof(SharedResource));
       });

// Add connection string 
var connectionstring = builder.Configuration.GetConnectionString("ApplicationConnection");

// Add dbcontext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(connectionstring));


// Add Automapper  
builder.Services.AddAutoMapper(mapper => mapper.AddProfile(new DomainProfile()));


// Add Scoped for appling DI
builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();

builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();

builder.Services.AddScoped<IDistrictRepo, DistrictRepo>();

builder.Services.AddScoped<ICityRepo, CityRepo>();

builder.Services.AddScoped<ICountryRepo, CountryRepo>();

builder.Services.Configure<RequestLocalizationOptions>(option =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("ar-EG"),
    };

    option.DefaultRequestCulture = new RequestCulture("en-US");
    option.SupportedCultures = supportedCultures;
    option.SupportedUICultures = supportedCultures;
    option.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                new QueryStringRequestCultureProvider(),
                new CookieRequestCultureProvider()
                };
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

var localizationoptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;
app.UseRequestLocalization(localizationoptions);

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
