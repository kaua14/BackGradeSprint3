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
            _apiKey = "sk - liBfwWWupfOOPtbH7mZsT3BlbkFJMfqGndJsSs30SUawnNjV";
            _apiUrl = apiUrl;
            _httpClient = new HttpClient();
        } 

        public async Task<string> ObterRespostaAsync(string pergunta)
        {
            // Montar a solicitação para a API do ChatGPT
            var requestBody = new { prompt = pergunta, max_tokens = 50 }; // Exemplo, ajuste conforme necessário
            var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

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
                var respostaModel = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(respostaJson);
            return respostaModel.choices[0].text.ToString(); // Exemplo, ajuste conforme necessário
        }
            else
            {
                // Lidar com erros (lançar exceção, registrar, etc.)
                return "Erro ao obter resposta do ChatGPT";
            }
        }
    }


}
