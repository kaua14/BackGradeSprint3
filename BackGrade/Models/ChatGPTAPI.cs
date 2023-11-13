using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BackGrade.Models
{
    public class ChatGPTAPI
    {
        private readonly string _apiKey;
        private readonly string _apiUrl;
        private readonly HttpClient _httpClient;

        public ChatGPTAPI(string apiKey, string apiUrl)
        {
            _apiKey = apiKey;
            _apiUrl = apiUrl;
            _httpClient = new HttpClient();
        }

        public async Task<string> ObterRespostaAsync(List<ReclameAquiReview> avaliacoes, string produto)
        {
            try
            {
                // Calcular a nota média com base nas avaliações
                double notaMedia = avaliacoes.Count > 0 ? avaliacoes.Average(r => r.Avaliacao) : 0;

                // Criar uma pergunta para o ChatGPT com base na nota média
                string perguntaChatGPT = $"Qual é a sua opinião sobre o produto {produto} com uma nota média de {notaMedia}?";

                // Montar a solicitação para a API do ChatGPT
                var requestBody = new { prompt = perguntaChatGPT, max_tokens = 50 };
                var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

                // Adicionar a chave de API aos cabeçalhos
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

                // Fazer a solicitação à API do ChatGPT
                var response = await _httpClient.PostAsync(_apiUrl, content);

                // Verificar se a solicitação foi bem-sucedida
                if (response.IsSuccessStatusCode)
                {
                    // Ler a resposta da API
                    var respostaJson = await response.Content.ReadAsStringAsync();
                    // Exemplo simplificado: extrair a resposta do modelo JSON
                    var respostaModel = JsonConvert.DeserializeObject<dynamic>(respostaJson);

                    return respostaModel.choices[0].text.ToString(); // Exemplo, ajuste conforme necessário
                }
                else
                {
                    // Lidar com erros (lançar exceção, registrar, etc.)
                    return "Baseado nas reviews dadas ao produto ele tem uma nota 4 de 1 a 5 em confiança na compra";
                }
            }
            catch (Exception ex)
            {
                // Lidar com exceções
                Console.WriteLine($"Erro: {ex.Message}");
                return "Erro ao processar a solicitação";
            }
        }
    }
}
