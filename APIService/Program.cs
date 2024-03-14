using BusinessLogic.Concrete;
using DataAccess.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

NoteManager noteManager = new(new NoteDal());
UserManager userManager = new(new UserDal());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
