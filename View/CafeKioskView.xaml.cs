using KioSchool.View.Pages.CafePages;
using KioSchool.ViewModel;
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

namespace KioSchool.View
{
    /// <summary>
    /// CafeKioskView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CafeKioskView : UserControl
    {
        public CafeKioskView()
        {
            InitializeComponent();

            Loaded += CafeKioskView_Loaded;
        }

        private void CafeKioskView_Loaded(object sender, RoutedEventArgs e)
        {
            //var vm = new CafeKioskViewModel();
            var vm = this.DataContext as CafeKioskViewModel;
            var cafeHome = new CafeHomePage(vm.TrainingManager, vm.CafeHomeVM, vm.MenuSelectionPageVM);
            CafeFrame.Navigate(cafeHome);
        }
    }
}
