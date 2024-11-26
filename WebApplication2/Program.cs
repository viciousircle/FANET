var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configure Session
builder.Services.AddDistributedMemoryCache(); // Use in-memory cache for session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session expiration time
    options.Cookie.HttpOnly = true;  // Cookie accessible only by the server
    options.Cookie.IsEssential = true;  // Ensure cookie is sent in essential scenarios
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Use Session middleware
app.UseSession(); // Ensure session is enabled before processing requests

app.UseAuthorization();

app.MapRazorPages();

app.Run();

