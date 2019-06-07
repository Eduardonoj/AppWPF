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
using System.Windows.Shapes;
using AppWPF.ModelView;
using MahApps.Metro.Controls;

namespace AppWPF.View
{
    /// <summary>
    /// Lógica de interacción para DepartmentView.xaml
    /// </summary>
    public partial class DepartmentView : MetroWindow
    {
        public DepartmentView()
        {
            InitializeComponent();
            this.DataContext = new DepartmentViewModel();
        }
    }
}
