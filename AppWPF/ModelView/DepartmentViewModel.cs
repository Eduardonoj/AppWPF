using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppWPF.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using System.Data.Entity;

namespace AppWPF.ModelView
{

    enum ACCION
    {
        NINGUNO,
        NUEVO,
        ACTUALIZAR,
        GUARDAR
    }
    public class DepartmentViewModel : INotifyPropertyChanged, ICommand
    {
        //Crear enlace a la base de datos
        private SchoolDataContext db = new SchoolDataContext();
        private ACCION accion = ACCION.NINGUNO;
        
        #region "Campos"
        private bool _IsReadOnlyName = true;
        private bool _IsReadOnlyBudget = true;
        private bool _IsReadOnlyAdmin = true;
        private bool _isEnableAdd = true;
        private bool _isEnableDelete = true;
        private bool _isEnableUpdate = true;
        private bool _isEnableSave = false;
        private bool _isEnableCancel = false;
        private string _Name;
        private string _Budget;
        private string _Admin;
        private Department _SelectDepartment;
        #endregion
        #region "Propiedades"
        public string Titulo { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public bool IsEnableAdd
        {
            get
            {
                return _isEnableAdd;
            }
            set
            {
                this._isEnableAdd = value;
                ChangeNotify("IsEnableAdd");
            }

        }

        public bool IsEnableDelete
        {
            get
            {
                return _isEnableDelete;
            }
            set
            {
                this._isEnableDelete = value;
                ChangeNotify("IsEnableDelete");
            }

        }

        public bool IsEnableUpdate
        {
            get
            {
                return _isEnableUpdate;
            }
            set
            {
                this._isEnableUpdate = value;
                ChangeNotify("IsEnableUpdate");
            }

        }

        public bool IsEnableSave
        {
            get
            {
                return _isEnableSave;
            }
            set
            {
                this._isEnableSave = value;
                ChangeNotify("IsEnableSave");
            }

        }

        public bool IsEnableCancel
        {
            get
            {
                return _isEnableCancel;
            }
            set
            {
                this._isEnableCancel = value;
                ChangeNotify("IsEnableCancel");
            }

        }

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                this._Name = value;
                ChangeNotify("Name");
            }
        }

        public string Budget
        {
            get
            {
                return _Budget;
            }
            set
            {
                this._Budget = value;
                ChangeNotify("Budget");
            }
        }

        public string Admin
        {
            get
            {
                return _Admin;
            }
            set
            {
                this._Admin = value;
                ChangeNotify("Admin");
            }
        }

        private DepartmentViewModel _Instancia;

      

        private ObservableCollection<Department> _Department;


        public DepartmentViewModel Instancia
        {
            get
            {
                return this._Instancia;
            }
            set
            {
                this._Instancia = value;
            }
        }

        public Boolean IsReadOnlyName
        {
            get
            {
                return this._IsReadOnlyName;
            }
            set
            {
                this._IsReadOnlyName = value;
                ChangeNotify("IsReadOnlyName");
            }
        }
        public Boolean IsReadOnlyBudget
        {
            get
            {
                return this._IsReadOnlyBudget;
            }
            set
            {
                this._IsReadOnlyBudget = value;
                ChangeNotify("IsReadOnlyBudget");
            }
        }
        public Boolean IsReadOnlyAdmin
        {
            get
            {
                return this._IsReadOnlyAdmin;
            }
            set
            {
                this._IsReadOnlyAdmin = value;
                ChangeNotify("IsReadOnlyAdmin");
            }
        }

        public Department SelectDepartment
        {
            get
            {
                return this._SelectDepartment;
            }
            set
            {
                if (value != null)
                {

                    this._SelectDepartment = value;
                    this.Name = value.Name;
                    this.Budget = value.Budget.ToString();
                    this.Admin = value.Administrator.ToString();
                    ChangeNotify("SelectDepartment");
                }
            }
        }
        public ObservableCollection<Department> Departments
        {
            get {
                if(this._Department ==null)
                {
                    this._Department = new ObservableCollection<Department>();
                    foreach(Department elemento in db.Departments.ToList())
                        {
                        this._Department.Add(elemento);
                    }
                }
                return this._Department;
            }

            set { this._Department = value; }
        }
        #endregion
        #region "Constructores"
        public DepartmentViewModel() //esto es un constructor
        {
            this.Titulo = "Lista de Departamentos";
            this.Instancia = this;
        }
        #endregion
        #region "Metodos o Funciones"
        public void ChangeNotify(string propertie)
        {
        
            if (PropertyChanged != null) { 
                PropertyChanged(this, new PropertyChangedEventArgs(propertie));
        }}
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.Equals("Add"))
            {
                this.IsReadOnlyName = false;
                this.IsReadOnlyBudget = false;
                this.IsReadOnlyAdmin = false;
                this.accion = ACCION.NUEVO;
                this.IsEnableAdd = false;
                this.IsEnableDelete = false;
                this.IsEnableUpdate = false;
                this.IsEnableSave = true;
                this.IsEnableCancel = true;
            }
            if (parameter.Equals("Save"))
            {
                switch (this.accion)
                {
                    case ACCION.NUEVO:
                        Department nuevo = new Department();
                        nuevo.Name = this.Name;
                        nuevo.Budget = Convert.ToDecimal(this.Budget);
                        nuevo.Administrator = Convert.ToInt16(this.Admin);
                        nuevo.StartDate = DateTime.Now;
                        db.Departments.Add(nuevo);
                        db.SaveChanges();
                        this.Departments.Add(nuevo);
                        MessageBox.Show("Registro almacenado");
                        break;
                    case ACCION.ACTUALIZAR:
                        try
                        {
                            int posicion = this.Departments.IndexOf(this.SelectDepartment);
                            var updateDepartment = this.db.Departments.Find(this.SelectDepartment.DepartmentID);
                            updateDepartment.Name = this.Name;
                            updateDepartment.Budget = Convert.ToDecimal(this.Budget);
                            updateDepartment.Administrator = Convert.ToInt16(this.Admin);
                            this.db.Entry(updateDepartment).State = EntityState.Modified;
                            this.db.SaveChanges();
                            this.Departments.RemoveAt(posicion); 
                            this.Departments.Insert(posicion, updateDepartment);
                            MessageBox.Show("Registro actualizado!!!");
                        }
                        catch(Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                        break;
                }
                this.IsEnableAdd = true;
                this.IsEnableDelete = true;
                this.IsEnableUpdate = true;
                this.IsEnableSave = false;
                this.IsEnableCancel = false;
                this.IsReadOnlyName = true;
                this.IsReadOnlyBudget = true;
                this.IsReadOnlyAdmin = true;


            }

            else if (parameter.Equals("Update"))
            {
                this.accion = ACCION.ACTUALIZAR;
                this.IsReadOnlyName = false;
                this.IsReadOnlyBudget = false;
                this.IsReadOnlyAdmin = false;
                this.IsEnableAdd = false;
                this.IsEnableDelete = false;
                this.IsEnableUpdate = false;
                this.IsEnableSave = true;
                this.IsEnableCancel = true;

            }
            else if (parameter.Equals("Delete"))
            {
                if (this.SelectDepartment != null)
                {
                    var respuesta = MessageBox.Show("Esta seguro de elminar el registro?", "Eliminar", MessageBoxButton.YesNo);

                    if (respuesta == MessageBoxResult.Yes)
                    {
                        try
                        { 
                        db.Departments.Remove(this.SelectDepartment);
                        db.SaveChanges();
                        this.Departments.Remove(this.SelectDepartment);
                       
                         }
                        catch(Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                        MessageBox.Show("Registro eliminado correctamente!!!");

                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un registro", "Eliminar", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (parameter.Equals("Cancel"))
            {
                this.IsEnableAdd = true;
                this.IsEnableDelete = true;
                this.IsEnableUpdate = true;
                this.IsEnableSave = false;
                this.IsEnableCancel = false;
                this.IsReadOnlyName = true;
                this.IsReadOnlyBudget = true;
                this.IsReadOnlyAdmin = true;
            }
        }
        #endregion
    }
}
