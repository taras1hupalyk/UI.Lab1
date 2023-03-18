using DDC.Client.MVVM.Model.DTOs;
using DDC.Client.MVVM.Model.Interfaces;


namespace DDC.Client.MVVM.Model
{
    class DifferentialDebtCalculation : IBankingCalculation
    {
        public CalculationResult Calculate(decimal debtAmount, decimal interestRate, int months)
        {
            decimal monthlyPayment = debtAmount / months;
            decimal totalInterest = 0;
            decimal totalSum = 0;

            for (int i = 0; i < months; i++)
            {
                decimal interest = (debtAmount - (monthlyPayment * i)) * (interestRate / 100) / 12;
                totalInterest += interest;
                totalSum += monthlyPayment + interest;
            }

            return new CalculationResult
            {
                MonthlyPayment = monthlyPayment,
                TotalInterest = totalInterest,
                TotalSum = totalSum
            };
        }
    }

}

