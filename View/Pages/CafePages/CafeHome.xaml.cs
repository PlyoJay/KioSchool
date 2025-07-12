using KioSchool.Classes;
using KioSchool.Models;
using KioSchool.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
    /// CafeHome.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CafeHome : Page
    {
        public TrainingManager _trainingManager { get; }

        private readonly CafeHomeVIewModel _viewModel;
        private readonly OrderViewModel _orderViewModel;

        public CafeHome(TrainingManager trainingManager, CafeHomeVIewModel vm, OrderViewModel orderVM)
        {
            InitializeComponent();

            _trainingManager = trainingManager;
            _viewModel = vm;
            _orderViewModel = orderVM;
            this.DataContext = _viewModel;
        }

        private void btnCafeKiosk_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string tag = btn.Tag.ToString();

            if (_trainingManager != null)
            {
                string actionKey = $"SelectHow:{tag}";
                if (!_trainingManager.CheckAction(actionKey))
                    return;
            }

            CafeOrderType orderType = (CafeOrderType)Enum.Parse(typeof(CafeOrderType), tag);
            Enums.SetCafeOrderType(orderType);

            this.NavigationService?.Navigate(new CafeOrder(_orderViewModel));
        }
    }
}
