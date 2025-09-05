using BlazorWASM;
using BlazorWASM.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Diagnostics.Metrics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor(options =>
{
    options.RootComponents.RegisterForJavaScript<Count>(identifier: "counter");
});
builder.Services.AddRazorComponents().AddInteractiveWebAssemblyComponents().AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseWebAssemblyDebugging();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.MapRazorComponents<App>().AddInteractiveWebAssemblyRenderMode().AddInteractiveServerRenderMode();

app.Run();
