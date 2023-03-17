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
    abstract class BankingViewModel : ObservableObject
    {
        public  RelayCommand CalculateCommand { get; set; }
        public RelayCommand ChooseMethodCommand { get; set; }

        protected CalculationService _service;
        protected decimal _debtAmount;

        public decimal DebtAmount
        {
            get { return _debtAmount; }
            set
            {
                _debtAmount = value;
                OnPropertyChanged();
            }
        }

        protected decimal _interestRate;

        public decimal InterestRate
        {
            get { return _interestRate; }
            set
            {
                _interestRate = value;
                OnPropertyChanged();
            }
        }

        protected int _months;

        public int Months
        {
            get { return _months; }
            set
            {
                _months = value;
                OnPropertyChanged();
            }
        }

        protected decimal _monthlyPayment;

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

        protected decimal _totalSum;

        public decimal TotalSum
        {
            get { return _totalSum; }
            set
            {
                _totalSum = value;
                OnPropertyChanged();
            }
        }



        public abstract void ChooseCalculationMethod();

        public void GetCalculationResults(object obj)
        {
            var result = _service.Calculate(DebtAmount, InterestRate, Months);

            this.MonthlyPayment = result.MonthlyPayment;
            this.TotalInterest = result.TotalInterest;
            this.TotalSum = result.TotalSum;
        }

        

        protected string _calculationMethod;
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
