using Desafio_Audaz.Controller;
using Desafio_Audaz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Audaz
{
    class Program
    {
        static void Main(string[] args)
        {
            var fare = new Fare();
            fare.Id = Guid.NewGuid();

            Console.WriteLine("Informe o valor da tarifa a ser cadastrada:");
            var fareValueInput = Console.ReadLine();
            fare.Value = decimal.Parse(fareValueInput);

            Console.WriteLine("Informe o código da operadora para a tarifa:");
            Console.WriteLine("Exemplos: OP01, OP02, OP03...");
            var operatorCodeInput = Console.ReadLine();

            Console.WriteLine("Informe o periodo da tarifa:");
            Console.WriteLine("Exemplos: 1, 2, 3...");
            var period = Console.ReadLine();
            fare.Period = int.Parse(period);

            var fareController = new FareController();

            fareController.CreateFare(CreateFakeFare(), operatorCodeInput);

            fareController.CreateFare(fare, operatorCodeInput);

            Console.WriteLine("Tarifa cadastrada com sucesso!");
            Console.Read();
        }

        private static Fare CreateFakeFare ()
        {
            Fare fare = new Fare();
            fare.Id = Guid.NewGuid();
            fare.Period = 5;
            fare.Status = 1;
            fare.Value = 2.45M;
            var fareController = new FareController();
            return fare;
        }

    }
}
