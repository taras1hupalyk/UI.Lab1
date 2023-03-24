using DDC.Client.MVVM.Model.DTOs;
using DDC.Client.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DDC.Client.MVVM.View
{
    /// <summary>
    /// Interaction logic for DepositView.xaml
    /// </summary>
    public partial class DepositView : UserControl
    {
        public DepositView()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var vm = DataContext as DepositViewModel;
                if (vm.DataGridContent == null)
                {
                    throw new ArgumentNullException("Please, make sure you have done the calculation");
                }
                var tableHeaders = String.Format("| {0,-10} | {1,-10} | {2,-10} |  {3, -10}",
                    "Month", "Deposit Body", "Monthly Interest", "Total");
                vm.SaveToFile(vm.DataGridContent.Select(x => x as PaymentInfo).ToList(), tableHeaders);

            }
            catch (ArgumentNullException ex)
            {

                MessageBox.Show(ex.ParamName, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
