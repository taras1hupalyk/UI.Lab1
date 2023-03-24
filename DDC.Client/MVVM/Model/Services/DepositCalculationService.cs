using DDC.Client.MVVM.Model.DTOs;
using DDC.Client.MVVM.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDC.Client.MVVM.Model.Services
{
    class DepositCalculationService
    {
        private IDepositCalculation _calculationMethod;

        public void SetCalculationMethod(IDepositCalculation calculationMethod)
        {
            _calculationMethod = calculationMethod;
        }


        public DepositCalculationResult Calculate(decimal moneyAmount, decimal interestRate, int months)
        {
            return _calculationMethod.Calculate(moneyAmount, interestRate, months);
        }



    }
}
