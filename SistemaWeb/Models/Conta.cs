namespace SistemaWeb.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPagamento { get; set; }
        public float Valor { get; set; }
        public DateTime DataVencimento { get; set; }

        public int TipoId { get; set; }
        public int ClassificacaoId { get; set; }

        public virtual Tipo Tipo { get; set; }
        public virtual Classificacao Classificacao { get; set; }

        public string IdUser { get; set; }

    }
}
