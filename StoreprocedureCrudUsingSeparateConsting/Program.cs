var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
//new add
app.UseStaticFiles(new StaticFileOptions()
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Append("Cache-Control", "public,Max-age=600");
    }
});
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.Use((x, y) => x.Equals(y));
app.Use(async (context, next) =>
{
    var currentEndPoint = context.GetEndpoint();
    if (currentEndPoint == null)
    {
        await next(context);
        return;
    }
    Console.WriteLine($"Endpoint:{currentEndPoint.DisplayName}");
    if (currentEndPoint is RouteEndpoint routeEndpoint)
    {
        Console.WriteLine($"    -Rounte Pattern: {routeEndpoint.RoutePattern}");
    }
    foreach(var endpointMetadata in currentEndPoint.Metadata)
    {
        Console.WriteLine($"      -Metadata:{endpointMetadata }");

    }
    await next(context);
});
//app.MapGet("/", () => "Inspect Endpoint.");
//app.UseStaticFiles();
//app.UseRouting();
//app.MapGet("/", () => "Test123");
//app.MapGet("/hello/{name:alpha}", (string name) => $"Hello {name}!");
//app.UseAuthentication();
//app.UseAuthorization();

//app.MapHealthChecks("/healthz").RequireAuthorization();
app.Run();
