using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GuestiaCodingTask.Data
{
    public class GuestsRepository
    {
        public static IEnumerable<Guest> GetGuests()
        {
            var context = new GuestiaContext();
            var guests = context.Guests.Include(x => x.GuestGroup);

            return guests;
        }
    }
}
