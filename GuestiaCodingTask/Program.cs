using GuestiaCodingTask.Data;
using GuestiaCodingTask.Helpers;
using GuestiaCodingTask.Services;
using System;

namespace GuestiaCodingTask
{
    class Program
    {
        static void Main(string[] args)
        {
            DbInitialiser.CreateDb();

            var notRegisteredStandardGuests = GuestsService.GetNotRegisteredStandardGuests();
            var notRegisteredVipGuests = GuestsService.GetNotRegisteredVipGuests();

            Console.WriteLine("Not Registered Guests");
            Console.WriteLine("VIP:");
            foreach (var item in notRegisteredVipGuests)
            {
                Console.WriteLine(GetName(item));
            }
            Console.WriteLine();
            Console.WriteLine("Standard:");
            foreach (var item in notRegisteredStandardGuests)
            {
                Console.WriteLine(GetName(item));
            }
        }
        static string GetName(Guest guest)
        {
            switch (guest.GuestGroup.NameDisplayFormat)
            {
                case Helpers.NameDisplayFormatType.UpperCaseLastNameSpaceFirstName:
                    return $"{guest.LastName.FirstCharToUpper()}, {guest.FirstName.FirstCharToUpper()}";
                case Helpers.NameDisplayFormatType.LastNameCommaFirstNameInitial:
                    return $"{guest.LastName.FirstCharToUpper()}, {guest.FirstName.Substring(0, 1).FirstCharToUpper()}";
                default:
                    return string.Empty;
            }
        }
    }
}
