using Blogger.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddDbContext <DatabaseContext>();

var app = builder.Build();


app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(x=> x.MapDefaultControllerRoute());

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Login}/{action=Index}/{id?}"
    );
});

app.Run();
