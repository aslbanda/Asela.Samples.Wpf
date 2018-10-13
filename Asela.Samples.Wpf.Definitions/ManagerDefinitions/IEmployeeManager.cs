using Asela.Samples.Wpf.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asela.Samples.Wpf.Definitions.ManagerDefinitions
{
    public interface IEmployeeManager
    {
        Employee AddEmployee(Employee employee);

        void UpdateEmployee(Employee employee);

        Employee DeleteEmployee(Employee employee);

        Employee[] GetAllEmployees();

        Employee GetEmployeeById(int id);

        Employee[] GetEmployeesByDepartment(int deptId);
    }
}
