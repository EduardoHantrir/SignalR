using SignalR_API;

var builder = WebApplication.CreateBuilder(args);

// 1) CORS: cria policy que permite o Angular dev server
var corsPolicyName = "AllowAngularDev";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName, policy =>
    {
        policy.WithOrigins("http://localhost:4200") // ou http://localhost:4200 se não usar HTTPS no Angular
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // importante para SignalR (cookies / WebSockets)
    });
});

// 2) SignalR
builder.Services.AddSignalR();

// 3) Controllers / Swagger (se quiser)
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

// IMPORTANTE: UseCors antes de MapHub/MapControllers
app.UseCors(corsPolicyName);

app.UseAuthorization();

app.MapControllers();

// Mapeia o hub no caminho /messageHub
app.MapHub<MessageHub>("/messageHub");

app.Run();
