using DDC.Client.MVVM.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDC.Client.MVVM.Model
{
    class CalculationService
    {
        private IBankingCalculation _calculationMethod;

        public void SetCalculationMethod(IBankingCalculation calculationMethod)
        {
            _calculationMethod = calculationMethod;
        }


        public CalculationResult Calculate(decimal moneyAmount, decimal interestRate, int months)
        {
            return _calculationMethod.Calculate(moneyAmount, interestRate, months);
        }


        
    }
}
