using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace MVVMExample
{
    public class EmployeesAgregate : INotifyPropertyChanged
    {
        private IEmployee _SelectedEmployee = Employee.Create(18, 50000, "Иван", "Ивановский", "Программист");

        private Command _AddEmployeeCommand;
        private Command _RemoveEmployeeCommand;

        public Command AddEmployeeCommand
        {
            get
            {
                return _AddEmployeeCommand ?? (_AddEmployeeCommand = new Command(o => { var newEmpl = InitCollections.CreateRandomEmployee(); Employees.Add(newEmpl); SelectedEmployee = newEmpl; }));
            }
        }

        public Command RemoveEmployeeCommand
        {
            get
            {
                return _RemoveEmployeeCommand ?? (_RemoveEmployeeCommand = new Command(o => { IEmployee rmvEmpl = o as IEmployee; if(rmvEmpl != null) Employees.Remove(rmvEmpl); }, o => Employees.Count > 0));
            }
        }

        public ObservableCollection<IEmployee> Employees
        {
            get; set;
        } = InitCollections.Go();


        public IEmployee SelectedEmployee
        {
            get { return _SelectedEmployee; }
            set
            {
                if(_SelectedEmployee != value)
                {
                    _SelectedEmployee = value;
                    NotifyPropertyChanged("SelectedEmployee");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public EmployeesAgregate()
        {
            Employees.Add(SelectedEmployee);
        }
    }
}
