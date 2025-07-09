using KioSchool.ViewModel.Cafe;
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

namespace KioSchool.View.Pages.CafePages
{
    /// <summary>
    /// CafeOrder.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CafeOrder : Page
    {
        public CafeOrder()
        {
            InitializeComponent();

            Loaded += CafeOrder_Loaded;
        }

        private void CafeOrder_Loaded(object sender, RoutedEventArgs e)
        {
            var navService = NavigationService.GetNavigationService(this);
            if (navService != null)
            {
                var basketVM = new BasketViewModel(navService);
                var drinkVM = new DrinkSelectionViewModel(basketVM);
                var categoryVM = new CategoryViewModel(drinkVM);

                this.DataContext = new OrderViewModel(basketVM, drinkVM, categoryVM);
            }
            else
            {
                // 예외 처리 또는 로그 출력 가능
                MessageBox.Show("NavigationService is null. This page may not be hosted in a Frame.");
            }
        }
    }
}
