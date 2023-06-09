﻿using DDC.Client.MVVM.Model.DTOs;
using DDC.Client.MVVM.Model.Interfaces;
using System.Collections.Generic;


namespace DDC.Client.MVVM.Model
{
    class CompoundInterestCalculation : IDepositCalculation
    {
        public DepositCalculationResult Calculate(decimal moneyAmount, decimal interestRate, int months)
        {
            var currentSum = moneyAmount;
            var paymentHistory = new List<PaymentInfo>();
            for (int i = 0; i < months; i++)
            {
                var currentBody = currentSum;
                currentSum *= (1 + interestRate / 100 / 12);


                paymentHistory.Add(new PaymentInfo
                {
                    MonthNumber = i + 1,
                    Body = currentBody,
                    MoneyChanges = currentSum - currentBody,
                    CurrentTotal = currentSum
                });
            }

            return new DepositCalculationResult
            {
                MonthlyPayment = (currentSum -moneyAmount) / months,
                TotalInterest = currentSum - moneyAmount,
                PaymentHistory = paymentHistory,
                TotalSum = currentSum
            };
        }
    }


}
