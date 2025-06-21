using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KioSchool.Models;

namespace KioSchool.ViewModel.Cafe
{
    class MenuSelectorViewModel
    {
        public ObservableCollection<Category> CategoryItems { get; set; }
    }
}
