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
    // In production, use the exception handler and enforce HTTPS
    app.UseExceptionHandler("/Error");
    app.UseHsts(); // HTTP Strict Transport Security (HSTS)
}
else
{
    // For development, you may want to display detailed error messages
    app.UseDeveloperExceptionPage();
}

// Force HTTPS redirection
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Use Session middleware (must be placed before Authorization middleware)
app.UseSession(); // Ensure session is enabled before processing requests

app.UseAuthorization();

// Map Razor Pages
app.MapRazorPages();

// Run the application
app.Run();
