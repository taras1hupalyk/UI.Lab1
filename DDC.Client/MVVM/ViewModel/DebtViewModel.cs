using DDC.Client.Core;
using DDC.Client.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDC.Client.MVVM.ViewModel
{
    class DebtViewModel : BankingViewModel
    {
        public DebtViewModel()
        {
            CalculateCommand = new RelayCommand(new Action<object>(GetCalculationResults));
            _service = new CalculationService();
        }


        public override void  ChooseCalculationMethod()
        {
            switch (CalculationMethod)
            {
                case "System.Windows.Controls.ComboBoxItem: Аннуітетний":
                    _service.SetCalculationMethod(new AnnualDebtCalculation());
                    break;
                case "System.Windows.Controls.ComboBoxItem: Диференційований":
                    _service.SetCalculationMethod(new DifferentialDebtCalculation());
                    break;

                default:
                    break;
            }
        }


    }
}
