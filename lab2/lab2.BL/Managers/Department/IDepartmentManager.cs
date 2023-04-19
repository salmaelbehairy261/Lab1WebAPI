using lab2.BL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.BL.Managers.Department
{
    public interface IDepartmentManager
    {
        DepartmentDetailsDto GetDepartmentDetailsById(int id);
    }
}
