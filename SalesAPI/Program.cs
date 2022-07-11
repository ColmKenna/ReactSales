using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:7001";
        options.TokenValidationParameters.ValidateAudience = false;
    });

builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("Sales API", policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireClaim("scope", "salesapi");
        });

        options.AddPolicy("ViewProducts", policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireClaim("canViewProducts", "true");
        });

        options.AddPolicy("ViewLocations", policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireClaim("canViewLocations", "true");
        });


        options.AddPolicy("EditProducts", policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireClaim("canEditProducts", "true");
        });

    }

);

builder.Services.AddCors(options =>
{
    // this defines a CORS policy called "default"
    options.AddPolicy("default", policy =>
    {
        policy.WithOrigins("https://localhost:7004")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("default");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers().RequireAuthorization("Sales API");

app.Run();






