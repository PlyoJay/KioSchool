using KioSchool.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KioSchool.ViewModel.Cafe
{
    public class PaymentPopupViewModel
    {
        public int TotalPrice { get; }
        public int TotalAmount { get; }

        public ICommand CancelCommand { get; }

        public PaymentPopupViewModel(int totalPrice, int totalAmount)
        {
            TotalPrice = totalPrice;
            TotalAmount = totalAmount;

            CancelCommand = new RelayCommand<Window>(w => Close(w, false), w => w != null);
        }

        private void Close(Window w, bool result)
        {
            w.DialogResult = result;
            w.Close();
        }
    }
}
