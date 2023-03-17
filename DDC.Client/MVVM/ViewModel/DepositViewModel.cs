using DDC.Client.Core;
using DDC.Client.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDC.Client.MVVM.ViewModel
{
    internal class DepositViewModel : BankingViewModel
    {
        public DepositViewModel()
        {
            CalculateCommand = new RelayCommand(new Action<object>(GetCalculationResults));
            _service = new CalculationService();
        }


        public override void ChooseCalculationMethod()
        {
            switch (CalculationMethod)
            {
                case "System.Windows.Controls.ComboBoxItem: Прості відсотки":
                    _service.SetCalculationMethod(new SimpleInterestCalculation());
                    break;
                case "System.Windows.Controls.ComboBoxItem: Складні відсотки":
                    _service.SetCalculationMethod(new CompoundInterestCalculation());
                    break;

                default:
                    break;
            }
        }
    }
}
