using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.BL.Dtos.Tickets
{
    public class TicketDetailsDto
    {
        public int Id { get; set; }
        public string? Discription { get; set; }
        public int DevelopersCount { get; set; }    
    }
}
