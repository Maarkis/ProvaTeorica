using ProvaTeorica.CSV;
using ProvaTeorica.TimeList;
using ProvaTeorica.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using Type = ProvaTeorica.CSV.Type;

namespace ProvaTeorica
{
    class Program
    {        

        static void Main(string[] args)
        {
            Program.Cpf();
            Console.WriteLine("\n");
            Program.Schedule();
            Console.WriteLine("\n");
            Program.CSV();
        }


        public static void Cpf()
        {
            string document = Console.ReadLine();

            bool result = ValidateCpf.IsCpf(document);

            if (!result)
                Console.WriteLine("CPF Inválido");
            else
                Console.WriteLine("CPF Válido");
        }

        public static void Schedule()
        {
            DateTime startTimeService = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 08, 00, 00);
            DateTime endTimeService = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 00, 00);

            List<Schedule> schedules = new List<Schedule>();
            schedules.Add(new Schedule()
            {
                Name = "Scheduling #1",
                StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 07, 00, 00),
                EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 08, 00, 00)

            });
            schedules.Add(new Schedule()
            {
                Name = "Scheduling #2",
                StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 08, 00, 00),
                EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 09, 00, 00)

            });
            schedules.Add(new Schedule()
            {
                Name = "Scheduling #3",
                StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 15, 00, 00),
                EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16, 00, 00)

            });
            schedules.Add(new Schedule()
            {
                Name = "Scheduling #4",
                StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 00, 00),
                EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 15, 00, 00)

            });
            schedules.Add(new Schedule()
            {
                Name = "Scheduling #5",
                StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 30, 00),
                EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 14, 30, 00)

            });
            schedules.Add(new Schedule()
            {
                Name = "Scheduling #6",
                StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16, 30, 00),
                EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 30, 00)

            });
            schedules.Add(new Schedule()
            {
                Name = "Scheduling #7",
                StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 00, 00),
                EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 30, 00)

            });
            schedules.Add(new Schedule()
            {
                Name = "Scheduling #8",
                StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 30, 00),
                EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 00, 00)

            });

            Scheduling scheduling = new Scheduling();
            schedules = scheduling.ValidateSchedulingTime(schedules, startTimeService, endTimeService);

            double occupancyRate = scheduling.ScheduleOccupancyRate(schedules, startTimeService, endTimeService);

            Console.WriteLine(occupancyRate + "% de ocupação.");
        }


        public static void CSV()
        {
            List<Procedure> procedures = Csv.ReadCSV(nameArchive: "proceedings.csv");

            List<TotalAmountByTypeAndPaymentMethod> totalAmountByTypeAndPaymentMethods = new();
            foreach(string type in Enum.GetNames(typeof(Type)))
            {

                foreach (string formPayment in Enum.GetNames(typeof(FormPayment)))
                {
                    totalAmountByTypeAndPaymentMethods.Add(TotalAmountByTypeAndPaymentMethod.GetAmountByTypeAndPaymentMethod(procedures, type, formPayment));
                }                
            }

            string result = Csv.CreateCSV(totalAmountByTypeAndPaymentMethods);
            if(result != null)
            {
                Console.WriteLine($"CVS Criado: {result}");
            }
        }
    }
}
