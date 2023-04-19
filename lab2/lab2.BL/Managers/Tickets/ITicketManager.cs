using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab2.BL.Dtos.Tickets;
using lab2.DAL.Models;
namespace lab2.BL
{
    public interface ITicketManager
    {
        IEnumerable<TicketReadDto> GetAll();
        TicketReadDto GetById(int id);
        void AddTicketDto(TicketReadDto ticketReadDto);
        void RemoveTicketDto(TicketReadDto ticketReadDto);
        void UpdateTicketDto(TicketReadDto ticketReadDto);
    }
}
