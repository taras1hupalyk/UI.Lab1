using DDC.Client.Core;
using DDC.Client.MVVM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DDC.Client.MVVM.ViewModel
{
    internal class DebtViewModel : ObservableObject
    {
        public RelayCommand CalculateCommand { get; set; }
        public RelayCommand ChooseMethodCommand { get; set; }

        private CalculationService _service;
        private decimal _debtAmount;

        public decimal DebtAmount
        {
            get { return _debtAmount; }
            set
            {
                _debtAmount = value;
                OnPropertyChanged();
            }
        }

        private decimal _interestRate;

        public decimal InterestRate
        {
            get { return _interestRate; }
            set
            {
                _interestRate = value;
                OnPropertyChanged();
            }
        }

        private int _months;

        public int Months
        {
            get { return _months; }
            set
            {
                _months = value;
                OnPropertyChanged();
            }
        }

        private decimal _monthlyPayment;

        public decimal MonthlyPayment
        {
            get { return _monthlyPayment; }
            set
            {
                _monthlyPayment = value;
                OnPropertyChanged();
            }
        }

        private decimal _totalInterest;
        public decimal TotalInterest
        {
            get { return _totalInterest; }
            set
            {
                _totalInterest = value;
                OnPropertyChanged();
            }
        }

        private decimal _totalSum;

        public decimal TotalSum
        {
            get { return _totalSum; }
            set
            {
                _totalSum = value;
                OnPropertyChanged();
            }
        }

        public DebtViewModel()
        {
            CalculateCommand = new RelayCommand(new Action<object>(GetCalculationResults));
            _service = new CalculationService();
        }

        public void ChooseCalculationMethod()
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

        public void GetCalculationResults(object obj)
        {
            var result = _service.Calculate(DebtAmount, InterestRate, Months);

            this.MonthlyPayment = result.MonthlyPayment;
            this.TotalInterest = result.TotalInterest;
            this.TotalSum = result.TotalSum;
        }

        

        private string _calculationMethod;
        public string CalculationMethod 
        { 
            get =>  _calculationMethod;
            set
            {
                _calculationMethod = value;
                ChooseCalculationMethod();
                OnPropertyChanged();
            }
        }
        


    }
}
