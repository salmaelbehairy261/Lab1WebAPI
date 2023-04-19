using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using lab2.DAL.Models;
namespace lab2.DAL
{
    public class TicketRepo : ITicketRepo
    {
        private readonly Context _context;

        public TicketRepo(Context context)
        {
            _context = context;
        }
        public void Add(Models.Ticket entity)
        {
            _context.Add(entity);
        }

        public void Delete(Models.Ticket entity)
        {
            _context.Remove(entity);
        }

        public IEnumerable<Models.Ticket> GetAll()
        {
            return _context.Set<Ticket>();
        }

        public Models.Ticket? GetById(int id)
        {
            return _context.Set<Ticket>().Find(id);
        }

        public void SaveChanges(Models.Ticket entity)
        {
            _context.SaveChanges();
        }

        public void Update(Models.Ticket entity)
        {
           
        }
    }
}
