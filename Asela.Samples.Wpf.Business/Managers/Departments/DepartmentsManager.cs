using Asela.Samples.Wpf.Definitions.ManagerDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asela.Samples.Wpf.Entities.Entities;
using System.Security.Principal;

namespace Asela.Samples.Wpf.Business.Managers.Departments
{
    public class DepartmentsManager : IDepartmentManager
    {
        private readonly Repository.Repository<Department> _repository;

        public DepartmentsManager()
        {
            _repository = new Repository.Repository<Department>();
        }

        public Department AddDepartment(Department department)
        {
            if (department == null)
                throw new NullReferenceException("Department object cannot be null.");

            if (string.IsNullOrEmpty(department.Name))
                throw new ArgumentNullException("Department name must be entered.");

            department.CreatedDate = DateTime.Now;
            department.CreatedBy = WindowsIdentity.GetCurrent().Name;

            var dept = _repository.Add(department);
            _repository.SaveAll();

            return dept;
        }

        public Department[] GetAllDepartments()
        {
            Department[] departments = _repository.GetAll().ToArray();

            return departments;
        }
    }
}
