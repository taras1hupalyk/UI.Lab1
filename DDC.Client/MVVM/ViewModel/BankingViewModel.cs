using DDC.Client.Core;
using DDC.Client.MVVM.Model;
using DDC.Client.MVVM.Model.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DDC.Client.MVVM.ViewModel
{
    abstract class BankingViewModel : ObservableObject
    {
        public RelayCommand CalculateCommand { get; set; }
        public RelayCommand ChooseMethodCommand { get; set; }

        protected ObservableCollection<PaymentInfo> _dataGridContent;
        public ObservableCollection<PaymentInfo> DataGridContent
        {
            get => _dataGridContent;
            set
            {
                _dataGridContent = value;
                OnPropertyChanged();
            }
        }


        protected readonly ErrorsViewModel _errorsViewModel = new();

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorsViewModel.GetErrors(propertyName);
        }

        public bool CanCreate => !HasErrors && IsCalculatinMethodSelected;
        public bool HasErrors => _errorsViewModel.HasErrors;
        public EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        protected void ErrorsViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
            OnPropertyChanged(nameof(CanCreate));
        }



        protected CalculationService _service;
        protected string _debtAmount;

        public string DebtAmount
        {
            get { return _debtAmount; }
            set
            {
                _errorsViewModel.ClearErrors(nameof(DebtAmount));
                if (_errorsViewModel.ValidateNumeric(nameof(DebtAmount), value))
                {
                    if (decimal.Parse(value) <= 0)
                    {
                        _errorsViewModel.AddError(nameof(DebtAmount), "Сума кредиту не може бути меншою або дорівнювати нулю");
                    }
                }

                _debtAmount = value;
                OnPropertyChanged();
            }
        }

        protected string _interestRate;

        public string InterestRate
        {
            get { return _interestRate; }
            set
            {
                _errorsViewModel.ClearErrors(nameof(InterestRate));
                if (_errorsViewModel.ValidateNumeric(nameof(InterestRate), value))
                {
                    var parsed = decimal.Parse(value);
                    if (parsed <= 0)
                    {
                        _errorsViewModel.AddError(nameof(InterestRate), "Відсоткова ставка не може бути меншою або дорівнювати нулю");
                    }

                }
                _interestRate = value;
                OnPropertyChanged();
            }
        }

        protected string _months;

        public string Months
        {
            get { return _months; }
            set
            {
                _errorsViewModel.ClearErrors(nameof(Months));
                if (int.TryParse(value, out int parsed))
                {
                    if (parsed <= 0)
                    {
                        _errorsViewModel.AddError(nameof(Months), "Unable value less/equal  zero");
                    }
                }
                else
                {
                    _errorsViewModel.AddError(nameof(Months), "The value must be integer");

                }
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

        public virtual void GetCalculationResults(object obj)
        {
            var result = _service.Calculate(decimal.Parse(DebtAmount), decimal.Parse(InterestRate), int.Parse(Months));

            this.MonthlyPayment = result.MonthlyPayment;
            this.TotalInterest = result.TotalInterest;
            this.TotalSum = result.TotalSum;
            this.DataGridContent = new ObservableCollection<PaymentInfo>(result.PaymentHistory);
        }

        public virtual void SaveToFile()
        {


            var data = this.DataGridContent;

            if (data == null)
            {
                throw new ArgumentNullException("Please, make sure you have done the calculation");
            }


            string fileName = this.ToString() + " " + DateTime.Now.ToShortDateString() + "-" + DateTime.Now.AddMonths(int.Parse(Months)).ToShortDateString() + ".txt";
            using var sw = new StreamWriter(fileName);

            var fileHeader = this.ToString() + " calculation using " + data.First().CalculationMethod + "method: ";
            sw.WriteLine(fileHeader);

            sw.WriteLine("Monthly payment: " + this.MonthlyPayment.ToString("F2") + "(full payment for stable payment and without percentage part for unstable payments, because percentage part different every month ");
            sw.WriteLine("Total interest: " + this.TotalInterest.ToString("F2"));
            sw.WriteLine("Total sum: " + this.TotalSum.ToString("F2"));
            sw.WriteLine("Payment history: ");

            foreach (var item in data)
            {
                sw.WriteLine(item);
            }
            sw.Close();

            MessageBox.Show("File saved successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);





        }



        protected string _calculationMethod;
        public string CalculationMethod
        {
            get => _calculationMethod;
            set
            {
                _calculationMethod = value;
                ChooseCalculationMethod();
                OnPropertyChanged();
            }
        }



        protected bool _isCalculationMethodSelected;
        public bool IsCalculatinMethodSelected
        {
            get => _isCalculationMethodSelected;
            set
            {
                _isCalculationMethodSelected = value;
                OnPropertyChanged(nameof(CanCreate));
            }
        }



    }
}
