// Program.cs
using BackGrade;
using BackGrade.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Configurar a conex�o com o banco de dados
builder.Services.AddDbContext<dbContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection"));
});

// Adicionar outros servi�os
builder.Services.AddControllersWithViews();

// Registrar o servi�o ReclameAquiAPI
builder.Services.AddScoped<ReclameAquiAPI>(provider =>
{
    // Voc� pode ajustar os par�metros do construtor conforme necess�rio
    var apiKey = "sua-chave-de-api-reclame-aqui";
    var apiUrl = "https://api.reclameaqui.com.br/v1"; // Exemplo, ajuste conforme necess�rio

    return new ReclameAquiAPI(apiKey, apiUrl);
});

// Registrar o servi�o ChatGPTAPI
builder.Services.AddScoped<ChatGPTAPI>(provider =>
{
    // Voc� pode ajustar os par�metros do construtor conforme necess�rio
    var apiKey = "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";
    var apiUrl = "https://api.openai.com/v1/completions"; // Exemplo, ajuste conforme necess�rio

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