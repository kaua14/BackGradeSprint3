using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackGrade.Models
{
    public class Cliente
    {
        [Key]
        public int ID_CLIENTE { get; set; }
        public char TP_CLIENTE { get; set; }
        public string EMAIL_CLIENTE { get; set; }
        public string TELEFONE_CLIENTE { get; set; }
        public string SENHA_CLIENTE { get; set; }
        public string NM_CLIENTE_FISICO { get; set; }
        public long? CPF_CLIENTE_FISICO { get; set; }
        public string RZ_SOCIAL_CLIENTE_JURIDICO { get; set; }
        public long? CNPJ_CLIENTE_JURIDICO { get; set; }
    }
}
