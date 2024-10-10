using MeuBolsoBackend;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços personalizados
builder.Services.AddCustomServices(builder.Configuration);

var app = builder.Build();

// Configura o pipeline de processamento de requisições
app.UseCustomConfiguration(app.Environment);

app.Run();