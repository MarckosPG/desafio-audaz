using Desafio_Audaz.Model;
using Desafio_Audaz.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Audaz.Controller
{
    class FareController
    {
        private OperatorService _operatorService;
        private FareService FareService = new FareService();

        public FareController()
        {
            _operatorService = new OperatorService();
        }

        public void CreateFare(Fare fare, string operatorCode)
        {

            _operatorService.Create(new Operator() { Code = operatorCode, Id = Guid.NewGuid() });

            var selectedOperator = _operatorService.GetOperatorByCode(operatorCode);
            
            fare.OperatorId = selectedOperator.Id;

            if (FareAvailable(FareService.GetFares(), fare))
            {
                FareService.Create(fare);
            }
            else
            {
                throw new Exception("Já existe uma tarifa ativa dentro deste periodo com o mesmo valor!");
            }
        }

        private bool FareAvailable (List<Fare> fares, Fare fare)
        {
            bool available = true;

            string opFare = _operatorService.GetOperatorById(fare.OperatorId).Code;
            
            foreach(Fare f in fares)
            {
                string opF = _operatorService.GetOperatorById(f.OperatorId).Code;
                //Console.WriteLine($"FareID: {f.Id}, Code: {opF}, Value: {f.Value}, Period: {f.Period}, Status: {f.Status}");
                if (opFare == opF && f.Status == 1 && fare.Period <= 6 && f.Value == fare.Value)
                {
                    available = false;
                    break;
                }
            }
            return available;
        }

    }
}
