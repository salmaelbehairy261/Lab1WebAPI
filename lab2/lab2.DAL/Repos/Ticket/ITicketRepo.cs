using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using lab2.DAL.Models;
namespace lab2.DAL
{
    public interface ITicketRepo
    {
        IEnumerable<Ticket> GetAll();
        Ticket? GetById(int id);
        void Add(Ticket entity);
        void Update(Ticket entity);
        void Delete(Ticket entity);
        void SaveChanges(Ticket entity);

    }
}
