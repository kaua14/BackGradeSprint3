using System.ComponentModel.DataAnnotations;

namespace BackGrade.Models
{
    public class ReclameAquiReview
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O comentário é obrigatório.")]
        public string Comentario { get; set; }

        [Range(1, 5, ErrorMessage = "A avaliação deve estar entre 1 e 5.")]
        public int Avaliacao { get; set; }

    }
}
