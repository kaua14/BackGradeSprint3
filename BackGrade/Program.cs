// Program.cs
using BackGrade;
using BackGrade.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Configurar a conexão com o banco de dados
builder.Services.AddDbContext<dbContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection"));
});

// Adicionar outros serviços
builder.Services.AddControllersWithViews();

// Registrar o serviço ReclameAquiAPI
builder.Services.AddScoped<ReclameAquiAPI>(provider =>
{
    // Você pode ajustar os parâmetros do construtor conforme necessário
    var apiKey = "sua-chave-de-api-reclame-aqui";
    var apiUrl = "https://api.reclameaqui.com.br/v1"; // Exemplo, ajuste conforme necessário

    return new ReclameAquiAPI(apiKey, apiUrl);
});

// Registrar o serviço ChatGPTAPI
builder.Services.AddScoped<ChatGPTAPI>(provider =>
{
    // Você pode ajustar os parâmetros do construtor conforme necessário
    var apiKey = "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";
    var apiUrl = "https://api.openai.com/v1/completions"; // Exemplo, ajuste conforme necessário

    return new ChatGPTAPI(apiKey, apiUrl);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Produto}/{action=Detalhes}/{id?}");


app.Run();