using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTeorica.CSV
{
    public class TotalAmountByTypeAndPaymentMethod
    {
        public Type Type { get; set; }
        public FormPayment FormPayment { get; set; }
        public double Amount { get; set; }


        public static TotalAmountByTypeAndPaymentMethod GetAmountByTypeAndPaymentMethod(List<Procedure> procedures, string type, string formPayment)
        {
            TotalAmountByTypeAndPaymentMethod typeValorTotalPorPagamento = new();

            typeValorTotalPorPagamento.Type = (Type)Enum.Parse(typeof(Type), type, true);
            typeValorTotalPorPagamento.FormPayment = (FormPayment)Enum.Parse(typeof(FormPayment), formPayment, true);
            typeValorTotalPorPagamento.Amount = procedures.Where(f => f.Type.ToString() == type && f.FormOfPayment.ToString() == formPayment).Sum(f => f.Value);

            return typeValorTotalPorPagamento;
        }
    }


}
