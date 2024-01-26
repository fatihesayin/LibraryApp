using LibraryApp.Api;
using LibraryApp.Domain;
using LibraryApp.EntityFrameworkCore;
using LibraryApp.EntityFrameWorkCore;
using LibraryApp.Manager;
using LibraryApp.Utils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ApplicationContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddTransient<IGuidGenerator, GuidGenerator>();
builder.Services.AddTransient(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddTransient<IBookManager, BookManager>();
builder.Services.AddTransient<IFileManager, FileManager>();
builder.Services.AddTransient<IBorrowManager, BorrowManager>();
var scope = builder.Services.BuildServiceProvider().CreateScope();
scope.ServiceProvider.GetService<ApplicationContext>().Seed(scope.ServiceProvider.GetService<IGuidGenerator>()).GetAwaiter();
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.MapControllers();
app.UseMiddleware<UnitOfWorkMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
} else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Book}/{action=Index}/{id?}");
app.UseRouting();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.Run();