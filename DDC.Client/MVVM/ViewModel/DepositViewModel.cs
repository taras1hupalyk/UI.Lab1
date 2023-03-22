using DDC.Client.Core;
using DDC.Client.MVVM.Model;
using DDC.Client.MVVM.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            _errorsViewModel.ErrorsChanged += ErrorsViewModel_ErrorsChanged;

            _errorsViewModel.ValidateNumeric(nameof(DebtAmount), DebtAmount);
            _errorsViewModel.ValidateNumeric(nameof(InterestRate), InterestRate);
            _errorsViewModel.ValidateNumeric(nameof(Months), Months);

            IsCalculatinMethodSelected = false;


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

            IsCalculatinMethodSelected = true;
            OnPropertyChanged();

        }


        public override string ToString()
        {
            return "Deposit";
        }
    }
}
