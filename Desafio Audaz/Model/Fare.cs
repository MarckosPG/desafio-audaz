using Desafio_Audaz.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Audaz.Model
{
    class Fare : IModel
    {
        public Guid OperatorId { get; set; }
        public int Status { get; set; }
        public decimal Value { get; set; }
        public int Period { get; set; }
    }
}
