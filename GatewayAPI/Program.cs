using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRateLimiter(options =>
{
    options.AddPolicy("ProductListPolicy", context =>
       RateLimitPartition.GetFixedWindowLimiter(
           partitionKey: context.Request.Path.ToString(),
           factory: key => new FixedWindowRateLimiterOptions
           {
               PermitLimit = 10,
               Window = TimeSpan.FromSeconds(10),
               QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
               QueueLimit = 5
           }));
});

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "http://localhost:5020"; 
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new()
        {
            ValidateAudience = false
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ProductUpdatePolicy", policy =>
    {
        policy.RequireAuthenticatedUser();
    });
});



builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRateLimiter();

app.UseAuthentication();
app.UseAuthorization();

app.MapReverseProxy();

app.MapControllers();

app.Run();
