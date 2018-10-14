using Asela.Samples.Wpf.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asela.Samples.Wpf.Ui.ViewModels
{
    class MainWindowVM : INotifyPropertyChanged
    {
        private Employee _activeEmployee;
        private List<Employee> _employeeList;
        private List<Department> _departmentList;
        private string _searchText;

        public MainWindowVM()
        {
        }

        public Employee ActiveEmployee
        {
            get
            {
                return _activeEmployee;
            }
            set
            {
                _activeEmployee = value;
                OnPropertyRaised("ActiveEmployee");
            }

        }

        public List<Employee> EmployeesList
        {
            get
            {
                return _employeeList;
            }
            set
            {
                _employeeList = value;
                OnPropertyRaised("EmployeesList");
            }
        }

        public List<Department> DepartmentList
        {
            get
            {
                return _departmentList;
            }
            set
            {
                _departmentList = value;
                OnPropertyRaised("DepartmentList");
            }
        }

        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                OnPropertyRaised("SearchText");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
