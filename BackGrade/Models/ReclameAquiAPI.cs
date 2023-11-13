using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BackGrade.Models
{
    public class ReclameAquiAPI
    {
        private readonly string _apiKey;
        private readonly string _apiUrl;
        private readonly HttpClient _httpClient;

        public ReclameAquiAPI(string apiKey, string apiUrl)
        {
            _apiKey = apiKey;
            _apiUrl = apiUrl;
            _httpClient = new HttpClient();
        }

        public async Task<List<ReclameAquiReview>> ObterAvaliacoesAsync(string produto)
        {
            try
            {
                // Simulando uma resposta da API com dados fictícios
                var avaliacoes = new List<ReclameAquiReview>
                {
                    new ReclameAquiReview { Comentario = "Bom produto!", Avaliacao = 5 },
                    new ReclameAquiReview { Comentario = "Ruim, não recomendo.", Avaliacao = 2 }
                };

                return avaliacoes;
            }
            catch (Exception ex)
            {
                // Lidar com exceções
                Console.WriteLine($"Erro: {ex.Message}");
                return new List<ReclameAquiReview>();
            }
        }
    }
}
