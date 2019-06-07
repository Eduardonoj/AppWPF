using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AppWPF.View;

namespace AppWPF.ModelView
{
    public class MainViewModel : INotifyPropertyChanged, ICommand

    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;
        
        public MainViewModel Instancia { get; set; }

        public MainViewModel()
        {
            this.Instancia = this;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.Equals("Departments"))
            {
                new DepartmentView().ShowDialog();
            }
        }
    }
}
