using lab2.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.DAL.Repos.Department
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly Context _context;

        public DepartmentRepo(Context context)
        {
            _context = context;
        }
        public Models.Department? GetDetailsById(int id)
        {
            return _context.Departments
                .Include(d => d.Tickets)
                .ThenInclude(t => t.Developers)
                .FirstOrDefault(d => d.Id == id) ;
        }
    }
}
