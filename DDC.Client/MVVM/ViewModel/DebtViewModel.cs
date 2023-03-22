using DDC.Client.Core;
using DDC.Client.MVVM.Model;
using DDC.Client.MVVM.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DDC.Client.MVVM.ViewModel
{
    class DebtViewModel : BankingViewModel
    {
     

        public DebtViewModel()
        {
            CalculateCommand = new RelayCommand(new Action<object>(GetCalculationResults));
            _service = new CalculationService();
            _errorsViewModel.ErrorsChanged += ErrorsViewModel_ErrorsChanged;

            _errorsViewModel.ValidateNumeric(nameof(DebtAmount), DebtAmount);
            _errorsViewModel.ValidateNumeric(nameof(InterestRate), InterestRate);
            _errorsViewModel.ValidateNumeric(nameof(Months), Months);
            
            IsCalculatinMethodSelected = false;

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

            IsCalculatinMethodSelected = true;
            OnPropertyChanged();
        }


        public override string ToString()
        {
            return "Debt";
        }

        

    }
}



