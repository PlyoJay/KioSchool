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
using KioSchool.Classes;
using KioSchool.Models;

namespace KioSchool.View.Pages.CafePages
{
    /// <summary>
    /// CafeOrder.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MenuSelectionPage : Page
    {
        public MenuSelectionPage(MenuSelectionPageViewModel vm)
        {
            InitializeComponent();

            this.DataContext = vm;
            Loaded += MenuSelectionPage_Loaded;
        }

        private void MenuSelectionPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is MenuSelectionPageViewModel vm)
            {
                var nav = NavigationService.GetNavigationService(this);
                vm.BasketVM.NavigationService = nav;
            }
        }
    }
}
