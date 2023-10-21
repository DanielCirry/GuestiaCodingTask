using GuestiaCodingTask.Data;
using GuestiaCodingTask.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace GuestiaCodingTask.Services
{
    public class GuestsService
    {
        public static IEnumerable<Guest> GetGuests(bool withRegistrationDate = false)
        {
            var guests = GuestsRepository.GetGuests();

            var notRegisteredGuests = guests.Where(x => !withRegistrationDate && x.RegistrationDate == null);
            return notRegisteredGuests;
        }
        public static IEnumerable<Guest> GetNotRegisteredVipGuests()
        {
            var guests = GetGuests();

            var notRegisteredVipGuests = guests.Where(x => x.GuestGroup.Name == GuestGroupName.VIP.ToString());
            return notRegisteredVipGuests.OrderBy(x => x.LastName);
        }
        public static IEnumerable<Guest> GetNotRegisteredStandardGuests()
        {
            var guests = GetGuests();

            var notRegisteredStandardGuests = guests.Where(x => x.GuestGroup.Name == GuestGroupName.Standard.ToString());
            return notRegisteredStandardGuests.OrderBy(x => x.LastName);
        }
    }
}
