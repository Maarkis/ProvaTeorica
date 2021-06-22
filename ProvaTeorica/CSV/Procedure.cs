using System.ComponentModel;

namespace ProvaTeorica.CSV
{
    public class Procedure
    {
        public int Proceeding { get; set; }
        public string Description { get; set; }
        public Type Type { get; set; }
        public double Value { get; set; }
        public FormPayment FormOfPayment { get; set; }
    }

    public enum FormPayment
    {
        [Description("Cartão de débito")]
        CD,
        [Description("Dinheiro")]
        Dinheiro,
        [Description("Cartão de crédito")]
        CC,        
    }

    public enum Type
    {
        [Description("Consulta")]
        Consulta,
        [Description("Exame")]
        Exame,
        [Description("Cirurgia")]
        Cirurgia        
    }
}
