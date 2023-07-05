using ProductManager;
using ProductManager.Services.Interface;
using ProductManager.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IProductRepository,ProductRepository>();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddRouting(options => options.ConstraintMap.Add("Positive",typeof(PositiveConstraint)));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
