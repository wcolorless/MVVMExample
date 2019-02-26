using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVMExample
{
    public class Employee : IEmployee, INotifyPropertyChanged
    {
        private int _Age;
        private int _Fee;
        private string _FirstName;
        private string _LastName;
        private string _Role;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private Employee()
        {

        }

        private Employee(int Age, int Fee, string FirstName, string LastName, string Role)
        {
            this.Age = Age;
            this.Fee = Fee;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Role = Role;
        }

        public static IEmployee Create()
        {
            return new Employee();
        }

        public static IEmployee Create(int Age, int Fee, string FirstName, string LastName, string Role)
        {
            return new Employee(Age, Fee, FirstName, LastName, Role);
        }

        public int Age
        {
            get
            {
                return _Age;
            }

            set
            {
                if(_Age != value)
                {
                    _Age = value;
                    NotifyPropertyChanged("Age");
                }
            }
        }

        public int Fee
        {
            get
            {
                return _Fee;
            }

            set
            {
                if(_Fee != value)
                {
                    _Fee = value;
                    NotifyPropertyChanged("Fee");
                }
            }
        }

        public string FirstName
        {
            get
            {
                return _FirstName;
            }

            set
            {
                if(_FirstName != value)
                {
                    _FirstName = value;
                    NotifyPropertyChanged("FirstName");
                }
            }
        }

        public string LastName
        {
            get
            {
                return _LastName;
            }

            set
            {
                if(_LastName != value)
                {
                    _LastName = value;
                    NotifyPropertyChanged("LastName");
                }
            }
        }

        public string Role
        {
            get
            {
                return _Role;
            }

            set
            {
                if(_Role != value)
                {
                    _Role = value;
                    NotifyPropertyChanged("Role");
                }
            }
        }
    }
}
