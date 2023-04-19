using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab2.DAL.Models;
namespace lab2.DAL
{
    public interface IDepartmentRepo
    {
        Department? GetDetailsById(int id);
    }
}
