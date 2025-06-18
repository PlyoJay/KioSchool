using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KioSchool.Models
{
    public class MenuItemModel
    {
        public string IconKind { get; set; } = "";
        public string Label { get; set; } = "";
        public ICommand Command { get; set; } = null!;
    }
}
