using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackGrade.Models
{
    public class Feedback
    {
        [Key]
        public int ID_FEEDBACK { get; set; }
        public int ID_CLIENTE { get; set; }
        public DateTime DT_FEEDBACK { get; set; }
        public string DESC_FEEDBACK { get; set; }
        public string ANALISE_FEEDBACK { get; set; }
        public int? NOTA_FEEDBACK { get; set; }
    }
}
