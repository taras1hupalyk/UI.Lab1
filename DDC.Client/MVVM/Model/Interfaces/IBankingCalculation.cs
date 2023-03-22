using DDC.Client.MVVM.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDC.Client.MVVM.Model.Interfaces
{
    interface IBankingCalculation
    {


        public CalculationResult Calculate(decimal debtAmount, decimal interestRate, int months);
    }
}
