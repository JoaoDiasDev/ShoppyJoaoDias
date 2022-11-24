using AutoMapper;
using BL;
using Interfaces.BL;
using Interfaces.Services;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IBankService, BankService>();
builder.Services.AddScoped<IBankInstallmentService, BankInstallmentService>();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderitemService, OrderitemService>();
builder.Services.AddScoped<IPageService, PageService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IProvinceService, ProvinceService>();
builder.Services.AddScoped<ISettingService, SettingService>();
builder.Services.AddScoped<IShippingService, ShippingService>();
builder.Services.AddScoped<IUnitService, UnitService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IResetPasswordService, ResetPasswordService>();
builder.Services.AddScoped<IWishlistService, WishlistService>();
builder.Services.AddControllersWithViews();

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperBL());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddScoped<IAddressBL, AddressBL>();
builder.Services.AddScoped<IAdminBL, AdminBL>();
builder.Services.AddScoped<IBankBL, BankBL>();
builder.Services.AddScoped<IBankInstallmentBL, BankInstallmentBL>();
builder.Services.AddScoped<IBasketBL, BasketBL>();
builder.Services.AddScoped<IBrandBL, BrandBL>();
builder.Services.AddScoped<ICategoryBL, CategoryBL>();
builder.Services.AddScoped<ICityBL, CityBL>();
builder.Services.AddScoped<IOrderBL, OrderBL>();
builder.Services.AddScoped<IOrderitemBL, OrderitemBL>();
builder.Services.AddScoped<IPageBL, PageBL>();
builder.Services.AddScoped<IPaymentBL, PaymentBL>();
builder.Services.AddScoped<IProductBL, ProductBL>();
builder.Services.AddScoped<IProductImageBL, ProductImageBL>();
builder.Services.AddScoped<IProvinceBL, ProvinceBL>();
builder.Services.AddScoped<ISettingBL, SettingBL>();
builder.Services.AddScoped<IShippingBL, ShippingBL>();
builder.Services.AddScoped<IUnitBL, UnitBL>();
builder.Services.AddScoped<IUserBL, UserBL>();
builder.Services.AddScoped<IResetPasswordBL, ResetPasswordBL>();
builder.Services.AddScoped<IWishlistBL, WishlistBL>();
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedFor | Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedProto;
});

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
    endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
        );
});

app.Run();
