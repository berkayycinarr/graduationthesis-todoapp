using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<INoteService, NoteManager>();
builder.Services.AddSingleton<INoteDal, NoteDal>();
builder.Services.AddSingleton<IUserDal, UserDal>();
builder.Services.AddSingleton<IUserService, UserManager>();



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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=SignUp}/{id?}");

app.Run();
