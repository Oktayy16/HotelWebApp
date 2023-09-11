using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IStaffDal, EfStaffDal>();   // Register'lar bu þekilde eklenmekte. Hafýzada 1 kere nesne örneði oluþtur bunu kullan(tipler bu nesne ömrünü belirler) / IServiceDal gördüðünde EFServiceDal kullan dedik
builder.Services.AddScoped<IStaffService, StaffManager>();  // Busines katmanýnda IStaffService gördüðünde StaffMAnager kullan dedik

builder.Services.AddScoped<IServicesDal, EfServiceDal>();  
builder.Services.AddScoped<IServiceService, ServiceManager>();

builder.Services.AddScoped<IRoomDal, EfRoomDal>();
builder.Services.AddScoped<IRoomService, RoomManager>();

builder.Services.AddScoped<ISubscribeDal, EfSubscribeDal>();
builder.Services.AddScoped<ISubscribeService, SubscribeManager>();

builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();

builder.Services.AddAutoMapper(typeof(Program));
// builder.Services.AddScoped

// Bir API'nin baþka kaynaklar tarafýndan tüketilmesini saðlayan metotdur
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("OtelApiCors", opts =>  // Bir isim veriyoruz(aþaðýda cors edilecek ismi verirken kullanýyoruz)
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();         //  Herhangi bir kaynaða izin ver demek.(Consume edilecek alanlar)
    });
});

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
app.UseCors("OtelApiCors");
app.UseAuthorization();

app.MapControllers();

app.Run();
