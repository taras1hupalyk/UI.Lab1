using DDC.Client.MVVM.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDC.Client.MVVM.Model
{
    class AnnualDebtCalculation : IBankingCalculation
    {
        public CalculationResult Calculate(decimal debtAmount, decimal interestRate, int months)
        {
            decimal monthlyInterestRate = interestRate / 100 / 12;
            decimal monthlyPayment = debtAmount * (monthlyInterestRate + (monthlyInterestRate / ((decimal)Math.Pow((double)(1 + monthlyInterestRate), months) - 1)));
            decimal totalInterest = monthlyPayment * months - debtAmount;
            decimal totalSum = debtAmount + totalInterest;

            return new CalculationResult
            {
                MonthlyPayment = monthlyPayment,
                TotalInterest = totalInterest,
                TotalSum = totalSum
            };
        }
    }
}
