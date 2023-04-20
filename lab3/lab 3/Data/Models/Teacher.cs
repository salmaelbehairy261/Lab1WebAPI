using Microsoft.AspNetCore.Identity;

namespace lab_3.Data.Models
{
    public class Teacher:IdentityUser
    {
        public decimal? Salary{ get; set; }
    }
}
