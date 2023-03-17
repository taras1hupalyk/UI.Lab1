using DDC.Client.MVVM.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDC.Client.MVVM.Model
{
    class CompoundInterestCalculation : IBankingCalculation
    {
        public CalculationResult Calculate(decimal moneyAmount, decimal interestRate, int months)
        {
            var currentSum = moneyAmount;
            for (int i = 0; i < months; i++)
            {
                currentSum *= (1 + interestRate / 100 / 12);
            }

            return new CalculationResult
            {
                MonthlyPayment = currentSum / months,
                TotalInterest = currentSum - moneyAmount,
                TotalSum = currentSum
            };
        }
    }


}
