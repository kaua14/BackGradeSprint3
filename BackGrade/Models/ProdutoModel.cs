using System.ComponentModel.DataAnnotations;

namespace BackGrade.Models
{
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        public string Nome { get; set; }

        public List<ReclameAquiReview> Avaliacoes { get; set; }

        [Range(1, 5, ErrorMessage = "A avaliação deve estar entre 1 e 5.")]
        public int NotaMedia => Avaliacoes.Count > 0 ? Avaliacoes.Sum(r => r.Avaliacao) / Avaliacoes.Count : 0;

        public string PerguntaChatGPT => $"Qual é a sua opinião sobre o produto {Nome} com uma nota média de {NotaMedia}?";

        [StringLength(500, ErrorMessage = "A resposta do ChatGPT deve ter no máximo 500 caracteres.")]
        public string RespostaChatGPT { get; set; }
    }
}
