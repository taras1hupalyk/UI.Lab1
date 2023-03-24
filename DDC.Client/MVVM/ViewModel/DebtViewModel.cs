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

        protected DebtCalculationService _service;



        public DebtViewModel()
        {
            CalculateCommand = new RelayCommand(new Action<object>(GetCalculationResults));
            _service = new DebtCalculationService();
            _errorsViewModel.ErrorsChanged += ErrorsViewModel_ErrorsChanged;

            _errorsViewModel.ValidateNumeric(nameof(DebtAmount), DebtAmount);
            _errorsViewModel.ValidateNumeric(nameof(InterestRate), InterestRate);
            _errorsViewModel.ValidateNumeric(nameof(Months), Months);
            
            IsCalculatinMethodSelected = false;

        }

        protected ObservableCollection<DebtPaymentInfo> _dataGridContent;
        public virtual ObservableCollection<DebtPaymentInfo> DataGridContent
        {
            get => _dataGridContent;
            set
            {
                _dataGridContent = value;
                OnPropertyChanged();
            }
        }


        public virtual void GetCalculationResults(object obj)
        {
            var result = _service.Calculate(decimal.Parse(DebtAmount), decimal.Parse(InterestRate), int.Parse(Months));

            this.MonthlyPayment = result.MonthlyPayment;
            this.TotalInterest = result.TotalInterest;
            this.TotalSum = result.TotalSum;
            this.DataGridContent = new ObservableCollection<DebtPaymentInfo>(result.PaymentHistory);
        }

        public override void  ChooseCalculationMethod()
        {
            switch (CalculationMethod)
            {
                case "System.Windows.Controls.ComboBoxItem: Annual":
                    _service.SetCalculationMethod(new AnnualDebtCalculation());
                    break;
                case "System.Windows.Controls.ComboBoxItem: Differential":
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



