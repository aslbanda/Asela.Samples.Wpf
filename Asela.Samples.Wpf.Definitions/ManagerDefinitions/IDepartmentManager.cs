using Asela.Samples.Wpf.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asela.Samples.Wpf.Definitions.ManagerDefinitions
{
    public interface IDepartmentManager
    {
        Department AddDepartment(Department department);

        Department[] GetAllDepartments();
    }
}
