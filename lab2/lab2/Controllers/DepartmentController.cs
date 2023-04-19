using lab2.BL.Dtos;
using lab2.BL.Managers.Department;
using lab2.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController:Controller
    {
        private readonly IDepartmentManager _departmentManager;
        public DepartmentController(IDepartmentManager departmentManager)
        {
            _departmentManager = departmentManager;
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<DepartmentDetailsDto> GetDepartmentDetailsById(int id)
        {
            return _departmentManager.GetDepartmentDetailsById(id);
        }
    }
}
