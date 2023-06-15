using Supabase;
var builder = WebApplication.CreateBuilder(args);

//Get Configuration
var url = builder.Configuration["supabase:URL"];
var key = builder.Configuration["supabase:KEY"];
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<Supabase.Client>(
	provider => new Supabase.Client(
		url,
		key,
		new Supabase.SupabaseOptions
		{
			AutoRefreshToken = true,
			AutoConnectRealtime = true,
		}
	)
);
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".Granary.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.IsEssential = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapRazorPages();

app.Run();
