using lab2.DAL;
using Microsoft.AspNetCore.Mvc;
using lab2.BL;
using lab2.BL.Dtos.Tickets;

namespace lab2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController:Controller
    {

        private readonly ITicketManager _ticketManager;
        public TicketController(ITicketManager ticketManager)
        {
            _ticketManager = ticketManager;
        }
        [HttpGet]
        public ActionResult<IEnumerable<TicketReadDto>> GetAll()
        {
            return _ticketManager.GetAll().ToList();
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<TicketReadDto> GetById(int id) 
        {
            var ticket= _ticketManager.GetById(id);
            return ticket;
        }
        [HttpPost]
        public ActionResult Addticket(TicketReadDto ticketReadDto)
        {
            _ticketManager.AddTicketDto(ticketReadDto);
            return Ok();
        }
        [HttpDelete]
        public ActionResult Deleteticket(TicketReadDto ticketReadDto)
        {
            _ticketManager.RemoveTicketDto(ticketReadDto);
            return NoContent();
        }
        [HttpPatch]
        public ActionResult UpdateTicket(TicketReadDto ticketReadDto)
        {
            _ticketManager.UpdateTicketDto(ticketReadDto);
            return NoContent();
        }

    }
}
