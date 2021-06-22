using Aspose.Cells;
using ProvaTeorica.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProvaTeorica.CSV
{
    public static class Csv
    {
        public static List<Procedure> ReadCSV(string nameArchive)
        {
            // Get path solution
            string path = Path.Combine(GetPath() + "\\" + nameArchive);
            var reader = new StreamReader(File.OpenRead(path));


            List<Procedure> procedures = new();
            if (reader != null)
            {
                // get head (first line).
                string header = reader.ReadLine();
                List<string> headerValues = normalizeLine(header);
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    List<string> lineValues = normalizeLine(line);

                    Procedure procedure = new Procedure();
                    procedure.Proceeding = Int32.Parse(lineValues[0]);
                    procedure.Description = lineValues[1];
                    procedure.Type = GetType(lineValues[2]);
                    procedure.Value = GetValue(lineValues[3]);
                    procedure.FormOfPayment = GetFormPayment(lineValues[4]);

                    procedures.Add(procedure);
                }
            }

            return procedures;

        }
        


        public static string CreateCSV(List<TotalAmountByTypeAndPaymentMethod> totalAmountByTypeAndPaymentMethods)
        {
            try
            {
                StringBuilder csvContent = new StringBuilder();
                csvContent.AppendLine("Tipo;Forma de pagamento;Valor total");
                totalAmountByTypeAndPaymentMethods.ForEach(f => csvContent.AppendLine($"{f.Type.GetDescription()};{f.FormPayment.GetDescription()};R$ {f.Amount}"));
                string cvsPath = GetPath() + "\\Dash.csv";
                File.WriteAllText(cvsPath, csvContent.ToString(), Encoding.UTF8);
                
                return cvsPath;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        private static List<string> normalizeLine(string line)
        {
            return line.Split(';').Where(x => !string.IsNullOrEmpty(x)).ToList();
        }
        private static FormPayment GetFormPayment(string str)
        {
            
            FormPayment type = FormPayment.CD;
            if (!string.IsNullOrEmpty(str))
            {
                switch (str)
                {
                    case "Cartão de crédito":
                        type = FormPayment.CC;
                        break;
                    case "Cartão de débito":
                        type = FormPayment.CD;
                        break;
                    case "Dinheiro":
                        type = FormPayment.Dinheiro;
                        break;
                    default:                        
                        break;
                }
            }
            return type;
        }
        private static double GetValue(string v)
        {
            v = v.Replace("R$", "").Trim();
            double value = double.Parse(v);
            return value;
        }       
        private static Type GetType(string str)
        {
                        
            Type type = Type.Consulta;
            if (!string.IsNullOrEmpty(str))
            {
                switch (str)
                {
                    case "Consulta":
                        type = Type.Consulta;
                        break;
                    case "Exame":
                        type = Type.Exame;
                        break;
                    case "Cirurgia":
                        type = Type.Cirurgia;
                        break;
                    default:                        
                        break;

                }
            }
            return type;
        }
        public static string GetPath()
        {
            return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;

        }
    }
}
