using lab2.BL.Dtos.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.BL.Dtos
{
    public class DepartmentDetailsDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<TicketDetailsDto> Tickets { get; init; } = new();

    }
}




//{
//● "Id": 1,
//● "Name": "Web App Development Department",
//● "Tickets": [
//● {
//● "Id": 10,
//● "Description": "Very cool ticket",
//● "DevelopersCount": 10
//● },
//● {
//● "Id": 20,
//● "Description": "weird bug",
//● "DevelopersCount": 5
//● }
//● ]
//● }
