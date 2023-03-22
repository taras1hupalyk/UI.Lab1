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
    /// Interaction logic for DebtView.xaml
    /// </summary>
    public partial class DebtView : UserControl
    {
        public DebtView()
        {
            InitializeComponent();
            cbbMethod.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var vm = DataContext as DebtViewModel;
                vm.SaveToFile();
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
