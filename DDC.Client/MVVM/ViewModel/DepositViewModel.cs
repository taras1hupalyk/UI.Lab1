using DDC.Client.Core;
using DDC.Client.MVVM.Model;
using DDC.Client.MVVM.Model.DTOs;
using DDC.Client.MVVM.Model.Services;
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
        private DepositCalculationService _service;

        public DepositViewModel()
        {
            CalculateCommand = new RelayCommand(new Action<object>(GetCalculationResults));
            _service = new DepositCalculationService();
            _errorsViewModel.ErrorsChanged += ErrorsViewModel_ErrorsChanged;

            _errorsViewModel.ValidateNumeric(nameof(DebtAmount), DebtAmount);
            _errorsViewModel.ValidateNumeric(nameof(InterestRate), InterestRate);
            _errorsViewModel.ValidateNumeric(nameof(Months), Months);

            IsCalculatinMethodSelected = false;


        }
        protected ObservableCollection<PaymentInfo> _dataGridContent;
        public virtual ObservableCollection<PaymentInfo> DataGridContent
        {
            get => _dataGridContent;
            set
            {
                _dataGridContent = value;
                OnPropertyChanged();
            }
        }

        public  void GetCalculationResults(object obj)
        {
            var result = _service.Calculate(decimal.Parse(DebtAmount), decimal.Parse(InterestRate), int.Parse(Months));

            this.MonthlyPayment = result.MonthlyPayment;
            this.TotalInterest = result.TotalInterest;
            this.TotalSum = result.TotalSum;
            this.DataGridContent = new ObservableCollection<PaymentInfo>(result.PaymentHistory);
        }


        public override void ChooseCalculationMethod()
        {
            switch (CalculationMethod)
            {
                case "System.Windows.Controls.ComboBoxItem: Simple Interest":
                    _service.SetCalculationMethod(new SimpleInterestCalculation());
                    break;
                case "System.Windows.Controls.ComboBoxItem: Compound Interest":
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
