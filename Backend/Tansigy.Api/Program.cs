using Tansiqy.BLL.Manager;
using Microsoft.EntityFrameworkCore;
using Tansiqy.DAL.Database;
using Tansiqy.DAL.Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TansiqyContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sql => sql.MigrationsAssembly("Tansiqy.DAL")
    )
);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IUniversityManager, UniversityManager>();
builder.Services.AddScoped<IFacultyManager, FacultyManager>();
builder.Services.AddScoped<IDepartmentManager, DepartmentManager>();
builder.Services.AddScoped<IDegreeManager, DegreeManager>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUniversityRepository, UniversityRepository>();
builder.Services.AddScoped<IFacultyRepository, FacultyRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDegreeRepository, DegreeRepository>();
builder.Services.AddScoped<IFavouriteRepository, FavouriteRepository>();


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
