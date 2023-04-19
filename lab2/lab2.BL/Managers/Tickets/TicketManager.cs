using lab2.BL.Dtos.Tickets;
using lab2.DAL;
using lab2.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.BL.Managers.Tickets
{
    public class TicketManager : ITicketManager
    {
        private readonly ITicketRepo _ticketRepo;

        public TicketManager(ITicketRepo ticketRepo)
        {
            _ticketRepo = ticketRepo;
        }
        public void AddTicketDto(TicketReadDto ticketReadDto)
        {
            Ticket ticket = new Ticket();
            ticket.Id = ticketReadDto.Id;
            ticket.Title = ticketReadDto.Title;
            ticket.Description = ticketReadDto.Description;
            _ticketRepo.Add(ticket);

        }

        public IEnumerable<TicketReadDto> GetAll()
        {
            var tickets=_ticketRepo.GetAll();
            return tickets.Select(t => new TicketReadDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
            });

        }

        public TicketReadDto GetById(int id)
        {
            var ticket = _ticketRepo.GetById(id);
            if (ticket == null) { return null; }
            return new TicketReadDto
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
            };
        }

        public void RemoveTicketDto(TicketReadDto ticketReadDto)
        {
            Ticket ticket=_ticketRepo.GetById(ticketReadDto.Id);
            _ticketRepo.Delete(ticket);
        }

        public void UpdateTicketDto(TicketReadDto ticketReadDto)
        {
            Ticket ticket = _ticketRepo.GetById(ticketReadDto.Id);
            _ticketRepo.Update(ticket);
        }
    }
}
