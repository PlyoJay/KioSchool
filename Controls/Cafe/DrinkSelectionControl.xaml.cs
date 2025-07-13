using KioSchool.Helper;
using KioSchool.ViewModel.Cafe;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KioSchool.Controls.Cafe
{
    /// <summary>
    /// DrinkSelectionControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DrinkSelectionControl : UserControl
    {
        public DrinkSelectionControl()
        {
            InitializeComponent();

            Loaded += DrinkSelectionControl_Loaded;
        }

        private void DrinkSelectionControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                if (this.DataContext is MenuSelectionViewModel vm)
                {
                    vm.DrinkListUpdated += (s, count) =>
                    {
                        var uniformGrid = FindChildHelper.FindChild<UniformGrid>(this);
                        if (uniformGrid != null)
                        {
                            uniformGrid.Rows = (count <= 12) ? 4 : (int)Math.Ceiling(count / 3.0);
                        }
                    };

                    // 초기 진입 시에도 현재 DrinkList 기반으로 Rows 설정
                    int initialCount = vm.DrinkList?.Count ?? 0;
                    var grid = FindChildHelper.FindChild<UniformGrid>(this);
                    if (grid != null)
                    {
                        grid.Rows = (initialCount <= 12) ? 4 : (int)Math.Ceiling(initialCount / 3.0);
                    }
                }
            }), System.Windows.Threading.DispatcherPriority.Loaded);
        }

    }
}
