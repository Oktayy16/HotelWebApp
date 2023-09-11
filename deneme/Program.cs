using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IStaffDal, EfStaffDal>();   // Register'lar bu �ekilde eklenmekte. Haf�zada 1 kere nesne �rne�i olu�tur bunu kullan(tipler bu nesne �mr�n� belirler) / IServiceDal g�rd���nde EFServiceDal kullan dedik
builder.Services.AddScoped<IStaffService, StaffManager>();  // Busines katman�nda IStaffService g�rd���nde StaffMAnager kullan dedik

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

// Bir API'nin ba�ka kaynaklar taraf�ndan t�ketilmesini sa�layan metotdur
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("OtelApiCors", opts =>  // Bir isim veriyoruz(a�a��da cors edilecek ismi verirken kullan�yoruz)
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();         //  Herhangi bir kayna�a izin ver demek.(Consume edilecek alanlar)
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
