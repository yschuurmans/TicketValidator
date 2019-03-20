using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketValidator.Domain
{
    public class Ticket
    {
        public string TicketId { get; set; }
        public string EventNaam { get; set; }
        public DateTime? ClaimedDateTime { get; set; }

    }
}
