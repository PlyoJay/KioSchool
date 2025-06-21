using KioSchool.Models;
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
        public CafeHome()
        {
            InitializeComponent();
        }

        private void btnCafeKiosk_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string tag = btn.Tag.ToString();

            CafeOrderType orderType = (CafeOrderType)Enum.Parse(typeof(CafeOrderType), tag);
            Enums.SetCafeOrderType(orderType);

            this.NavigationService?.Navigate(new CafeOrder());
        }
    }
}
