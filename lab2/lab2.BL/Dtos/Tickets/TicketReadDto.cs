using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.BL.Dtos.Tickets
{
    public class TicketReadDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
