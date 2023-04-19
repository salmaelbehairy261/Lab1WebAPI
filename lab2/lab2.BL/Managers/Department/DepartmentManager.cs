using lab2.BL.Dtos;
using lab2.BL.Dtos.Tickets;
using lab2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.BL.Managers.Department
{
    public class DepartmentManager : IDepartmentManager
    {
        private readonly IDepartmentRepo _departmentRepo;

        public DepartmentManager(IDepartmentRepo departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }
        public DepartmentDetailsDto GetDepartmentDetailsById(int id)
        {
            var department = _departmentRepo.GetDetailsById(id);
            if (department is null)
                return null;
            return new DepartmentDetailsDto
            {
                Id = id,
                Name = department.Name,
                Tickets = department.Tickets
                    .Select(t => new TicketDetailsDto
                    {
                        Id = t.Id,
                        Discription=t.Description,
                        DevelopersCount = t.Developers.Count
                    }).ToList()
            };
        }

    }
}
