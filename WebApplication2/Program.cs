

// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// builder.Services.AddRazorPages();

// // Cấu hình Session
// builder.Services.AddDistributedMemoryCache();  // Sử dụng bộ nhớ tạm thời cho Session
// builder.Services.AddSession(options =>
// {
//     options.IdleTimeout = TimeSpan.FromMinutes(30);  // Thời gian hết hạn của session
//     options.Cookie.HttpOnly = true;  // Chỉ có thể truy cập cookie từ phía server
//     options.Cookie.IsEssential = true;  // Đảm bảo cookie hoạt động trong các tình huống cần thiết
// });

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/Error");
//     app.UseHsts();
// }

// app.UseHttpsRedirection();
// app.UseStaticFiles();

// app.UseRouting();

// // Cấu hình sử dụng Session
// app.UseSession();  // Đảm bảo rằng Session được sử dụng trước khi các yêu cầu được xử lý

// app.UseAuthorization();

// app.MapRazorPages();

// app.Run();

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

