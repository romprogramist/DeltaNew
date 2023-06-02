using Microsoft.EntityFrameworkCore;
using Delta.Data;
using Delta.Middleware;
using Delta.Services.ApplicationService;
using Delta.Services.EmailService;
using Delta.Services.ReviewService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddNewtonsoftJson();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<IReviewService, ReviewService>();

builder.Services.AddWebOptimizer(pipeline =>
{
    //css bundles
    pipeline.AddCssBundle("/css/layout-bundle.css", 
        "/css/layout.css");
    pipeline.AddCssBundle("/css/home-bundle.css", 
        "/css/home.css");
    pipeline.AddCssBundle("/css/our-production-bundle.css", 
        "/css/our-production.css");
    pipeline.AddCssBundle("/css/product-category-bundle.css", 
        "/css/product-category.css");
    pipeline.AddCssBundle("/css/about-us-bundle.css", 
        "/css/about-us.css");
    pipeline.AddCssBundle("/css/partners-not-section-bundle.css", 
        "/css/partners-not-section.css");
    pipeline.AddCssBundle("/css/contact-us-bundle.css", 
        "/css/contact-us.css");
    pipeline.AddCssBundle("/css/one-product-description-bundle.css", 
        "/css/one-product-description.css");
    
    
    
    // js bundles
    pipeline.AddJavaScriptBundle("/js/layout-bundle.js", 
        "/js/phone-mask.js",
        "/js/api-request.js",
        "/js/loader.js",
        "/js/modal.js",
        "/js/helpers.js",
        "/js/form-request.js",
        "/js/layout.js");
    pipeline.AddJavaScriptBundle("/js/home-bundle.js",
        "/js/home.js");
    pipeline.AddJavaScriptBundle("/js/hematology-bundle.js",
        "/js/hematology.js");
    pipeline.AddJavaScriptBundle("/js/switch-in-products-bundle.js",
        "/js/switch-in-products.js");
    pipeline.AddJavaScriptBundle("/js/open-list-bundle.js",
        "/js/open-list.js");
    pipeline.AddJavaScriptBundle("/js/open-doc-bundle.js",
        "/js/open-doc.js");  
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    try
    {
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Problem with migration data");
    }
    
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    
    app.UseWebOptimizer();
}

// app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseUtm();

app.Run();