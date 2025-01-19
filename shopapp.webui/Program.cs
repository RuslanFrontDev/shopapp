
var builder = WebApplication.CreateBuilder(args);

// MVC hizmetlerini ekle
builder.Services.AddControllersWithViews();

// IProductRepository bağımlılığı çözümlemesi
// builder.Services.AddScoped<IProductRepository, EfCoreProductRepository>();

// CORS ayarlarını ekle
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Statik dosyalar için middleware ekle
app.UseStaticFiles();

// CORS'u etkinleştir
app.UseCors();

// HTTP istek hattını yapılandır
app.UseRouting();

// Yetkilendirme middleware (gerekirse)
app.UseAuthorization();

// Varsayılan rota eşlemesini yapılandır
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// Uygulamayı çalıştır
app.Run();



// [ApiController]
// [Route("api/[controller]")]
// public class FilesController : ControllerBase
// {
//     [HttpGet("images/{filename}")]
//     public IActionResult GetImage(string filename)
//     {
//         var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", filename);
//         if (!System.IO.File.Exists(path))
//         {
//             return NotFound("File not found");
//         }
//         var fileBytes = System.IO.File.ReadAllBytes(path);
//         return File(fileBytes, "image/jpeg"); // Dosya türünü burada belirtebilirsiniz
//     }
// }
