using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PdfSharp.Charting;
using TeklifPanel.Business.Abstract;
using TeklifPanel.Business.Concrete;
using TeklifPanel.Data.Abstract;
using TeklifPanel.Data.Concrete.EfCore;
using TeklifPanel.Entity;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TeklifPanelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnectionLocal")));
builder.Services.AddDbContext<TeklifPanelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnectionTest")));
//builder.Services.AddDbContext<TeklifPanelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<TeklifPanelContext>().AddDefaultTokenProviders();

builder.Services.AddSession();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.User.RequireUniqueEmail = true;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    //options.LoginPath = "/account/login"; // Eðer açýlabilmesi için login olmanýn zorunluu olduu bir sayfaya gireye çalýþýyorsa, yönlendirilecek login sayfasýna yönlendirir
    //options.LogoutPath = "/account/logout"; // çýkýþ yaptýktan sonra gidilecek sayfaya yönlendirir
    //options.AccessDeniedPath = "/account/accessdenied"; // yetkisiz giriþ sýrasýnda yönlendirilecek sayfa
    //options.SlidingExpiration = true; // çýkýþ için varsayýlan olan 20 dknýn her istekte sýfýrlanamsýný saðlýyoruz.
    options.ExpireTimeSpan = TimeSpan.FromMinutes(10); // varsayýlan olan 20 dk lýk süreyi bu kod ile 10 dk süreye düþürür.

});

//var sqlConnection = builder.Configuration.GetConnectionString("SqlServerConnection");
//builder.Services.AddDbContext<TeklifPanelContext>(options => options.UseSqlServer(sqlConnection));

builder.Services.AddScoped<IAddressRepository, EfCoreAddressRepository>();
builder.Services.AddScoped<ICategoryRepository,EfCoreCategoryRepository>();
builder.Services.AddScoped<ICompanyRepository,EfCoreCompanyRepository>();
builder.Services.AddScoped<IContactPersonRepository,EfCoreContactRepository>();
builder.Services.AddScoped<ICustomerRepository,EfCoreCustomerRepository>();
builder.Services.AddScoped<IImageRepository,EfCoreImageRepository>();
builder.Services.AddScoped<IOfferRepository,EfCoreOfferRepository>();
builder.Services.AddScoped<IProductRepository, EfCoreProductRepository>();
builder.Services.AddScoped<IUserRepository,EfCoreUserRepository>();
builder.Services.AddScoped<ICompanySettingsRepository,EfCoreCompanySettingsRepository>();
builder.Services.AddScoped<IIbanRepository, EfCoreIbanRepository>();
builder.Services.AddScoped<ILogRepository, EfCoreLogRepository>();

builder.Services.AddScoped<IAddressService, AddressManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICompanyService, CompanyManager>();
builder.Services.AddScoped<IContactPersonService, ContactPersonManager>();
builder.Services.AddScoped<ICustomerService, CustomerManager>();
builder.Services.AddScoped<IImageService, ImageManager>();
builder.Services.AddScoped<IOfferService, OfferManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<ICompanySettingsService, CompanySettingsManager>();
builder.Services.AddScoped<IIbanService, IbanManager>();
builder.Services.AddScoped<ILogService, LogManager>();

builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
