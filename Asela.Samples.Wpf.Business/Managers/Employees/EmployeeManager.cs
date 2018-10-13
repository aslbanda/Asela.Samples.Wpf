using Asela.Samples.Wpf.Definitions.ManagerDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asela.Samples.Wpf.Entities.Entities;
using System.Security.Principal;

namespace Asela.Samples.Wpf.Business.Managers.Employees
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly Repository.Repository<Employee> _repository;

        public EmployeeManager()
        {
            _repository = new Repository.Repository<Employee>();
        }

        public Employee AddEmployee(Employee employee)
        {
            if (employee == null)
                throw new NullReferenceException("Employee object cannot be null.");

            if (string.IsNullOrEmpty(employee.Name))
                throw new ArgumentNullException("Employee name cannot be null.");

            employee.CreatedDate = DateTime.Now;
            employee.CreatedBy = WindowsIdentity.GetCurrent().Name;

            var result = _repository.Add(employee);

            _repository.SaveAll();

            return result;
        }

        public Employee DeleteEmployee(Employee employee)
        {
            if (employee == null)
                throw new NullReferenceException("Employee object cannot be null.");

            if (employee.Id < 1)
                throw new ArgumentException("Employee ID is not defined for deletion.");

            var delEmp = _repository.GetBy(p => p.Id == employee.Id).FirstOrDefault();
            if(delEmp != null)
            {
                _repository.Delete(delEmp);
                _repository.SaveAll();
            }

            return delEmp;
        }

        public Employee[] GetAllEmployees()
        {
            Employee[] employees = _repository.GetAll().ToArray();

            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Employee ID must be greater than zero.");

            Employee emp = _repository.GetBy(p => p.Id == id).FirstOrDefault();

            return emp;
        }

        public Employee[] GetEmployeesByDepartment(int deptId)
        {
            if (deptId <= 0)
                throw new ArgumentException("Department ID must be greater than zero.");

            Employee[] employees = _repository.GetBy(p => p.DeptId == deptId).ToArray();

            return employees;
        }

        public void UpdateEmployee(Employee employee)
        {
            if (employee == null)
                throw new NullReferenceException("Employee object cannot be null.");

            if (employee.Id <= 0)
                throw new ArgumentException("Employee ID must be grater than zero.");

            var emp = _repository.GetBy(p => p.Id == employee.Id).FirstOrDefault();
            if(emp != null)
            {
                emp.Name = employee.Name;
                emp.AddressLine1 = employee.AddressLine1;
                emp.AddressLine2 = employee.AddressLine2;
                emp.AddressLine3 = employee.AddressLine3;
                emp.DeptId = employee.DeptId;

                emp.ModifiedDate = DateTime.Now;
                emp.ModifiedBy = WindowsIdentity.GetCurrent().Name;

                _repository.Update(emp);
                _repository.SaveAll();
            }
            else
            {
                throw new Exception("Requested employee is not found.");
            }
        }
    }
}
