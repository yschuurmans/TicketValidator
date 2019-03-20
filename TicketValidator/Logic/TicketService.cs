using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketValidator.Domain;
using TicketValidator.Models;
using TicketValidator.Persistence;

namespace TicketValidator.Logic
{
    public class TicketService
    {
        private readonly ValidatorDbContext context;

        public TicketService(ValidatorDbContext _context)
        {
            context = _context;
        }

        public TicketValid ValidateTicket(Ticket ticket)
        {
            var foundTicket = context.Tickets.FirstOrDefault(x => x.TicketId == ticket.TicketId && x.EventNaam == ticket.EventNaam);
            if (foundTicket != null)
            {
                if (foundTicket.ClaimedDateTime == null)
                {
                    foundTicket.ClaimedDateTime = DateTime.Now;
                    context.SaveChanges();
                    return new TicketValid() { IsValid = true };
                }
                else
                {
                    TimeSpan timeDiff = DateTime.Now - (foundTicket.ClaimedDateTime??DateTime.Now);

                    return new TicketValid() { IsValid = false, ErrorMessage = $"Deze ticket is { timeDiff.Minutes } minuten geleden al geclaimed!" };

                }
            }

            return new TicketValid() { IsValid = false, ErrorMessage = $"Deze ticket heeft geen correcte code!" };
        }

        public bool CreateTickets(int ticketCount, string eventNaam)
        {
            List<Ticket> newTickets = new List<Ticket>();
            for (int i = 0; i < ticketCount; i++)
            {
                newTickets.Add(new Ticket()
                {
                    EventNaam = eventNaam,
                    TicketId = NewTicketId(8)
                });
            }

            context.Tickets.AddRange(newTickets);
            context.SaveChanges();

            WriteTicketsToFile(newTickets, eventNaam);

            return true;

        }

        private void WriteTicketsToFile(List<Ticket> tickets, string eventnaam)
        {
            List<string> allLines = new List<string>();

            foreach (var ticket in tickets)
            {
                allLines.Add($"https://stuffs.yschuurmans.nl/validator/{ticket.EventNaam}/{ticket.TicketId}");
            }

            File.WriteAllLines(eventnaam + ".txt", allLines.ToArray());
        }

        private string NewTicketId(int length = 8)
        {
            string alphabet = "0123456789ABCDEFGHKLMNPRSUVWXYZ";
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                sb.Append(alphabet[rnd.Next(0, alphabet.Length)]);
            }

            string result = sb.ToString();

            if (context.Tickets.Any(x => x.TicketId == result)) return NewTicketId(length);

            return result;
        }

    }
}
