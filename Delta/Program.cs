using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Delta.Data;
using Delta.Middleware;
using Delta.Services.ApplicationService;
using Delta.Services.CompanyService;
using Delta.Services.EmailService;
using Delta.Services.PhotoAddition;
using Delta.Services.ReviewService;
using Delta.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => {
    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddControllersWithViews().AddNewtonsoftJson();

builder.Services.AddDbContext<DeltaDbContext>();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});


builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddTransient<IPhotoAddition, PhotoAddition>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AuthSettings:Token").Value!))
        };
    });
 
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
    pipeline.AddCssBundle("/css/add-company-bundle.css", 
        "/css/add-company.css");
    pipeline.AddCssBundle("/css/admin-bundle.css", 
        "/css/admin.css");
    pipeline.AddCssBundle("/css/review-bundle.css", 
        "/css/review.css");
    
    // js bundles
    pipeline.AddJavaScriptBundle("/js/layout-bundle.js", 
        "/js/phone-mask.js",
        "/js/api-request.js",
        "/js/loader.js",
        "/js/modal.js",
        "/js/helpers.js",
        "/js/form-request.js",
        "/js/layout.js",
        "/js/admin/layout.js");
    pipeline.AddJavaScriptBundle("/js/home-bundle.js",
        "/js/home.js");
    pipeline.AddJavaScriptBundle("/js/user-bundle.js",
        "/js/user.js");
    pipeline.AddJavaScriptBundle("/js/hematology-bundle.js",
        "/js/hematology.js");
    pipeline.AddJavaScriptBundle("/js/switch-in-products-bundle.js",
        "/js/switch-in-products.js");
    pipeline.AddJavaScriptBundle("/js/open-list-bundle.js",
        "/js/open-list.js");
    pipeline.AddJavaScriptBundle("/js/open-doc-bundle.js",
        "/js/open-doc.js"); 
    pipeline.AddJavaScriptBundle("/js/add-hover-class-bundle.js",
        "/js/add-hover-class.js"); 
    pipeline.AddJavaScriptBundle("/js/dropdown-bundle.js",
        "/js/dropdown.js"); 
    pipeline.AddJavaScriptBundle("/js/delete-item-dada-b-bundle.js",
        "/js/delete-item-dada-b.js"); 
    pipeline.AddJavaScriptBundle("/js/admin-review-bundle.js",
        "/js/admin/review.js");
});

var app = builder.Build();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<DeltaDbContext>();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
try
{
    context.Database.Migrate();
}
catch (Exception ex)
{
    logger.LogError(ex, "Problem with migration data");
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    
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
app.UseCors();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "area",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseUtm();

app.Run();

