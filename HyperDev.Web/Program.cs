using HyperDev.Core.IUnitOfWork;
using HyperDev.Core.Repositories;
using HyperDev.Core.Services;
using HyperDev.Repository;
using HyperDev.Repository.Repositories;
using HyperDev.Repository.UnitOfWorks;
using HyperDev.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


/*builder.Services.AddDbContext<AppDbContext>(
           options => options.UseNpgsql("name=ConnectionStrings:DefaultConnection").UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)); */
builder.Services.AddDbContext<AppDbContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IServices<>), typeof(Service<>));
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dataContext.Database.Migrate();
}


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
