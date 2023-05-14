using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayReminderApp
{
    public class Friend
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }

    public class BirthdayReminder
    {
        private List<Friend> friends;

        public BirthdayReminder()
        {
            friends = new List<Friend>();
        }

        public void AddFriend(string name, DateTime birthday)
        {
            Friend friend = new Friend { Name = name, Birthday = birthday };
            friends.Add(friend);
            Console.WriteLine("Friend added successfully.");
        }

        public void EditFriend(string name, DateTime newBirthday)
        {
            Friend friend = friends.Find(f => f.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (friend != null)
            {
                friend.Birthday = newBirthday;
                Console.WriteLine("Friend's birthday updated successfully.");
            }
            else
            {
                Console.WriteLine("Friend not found.");
            }
        }

        public void DeleteFriend(string name)
        {
            Friend friend = friends.Find(f => f.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (friend != null)
            {
                friends.Remove(friend);
                Console.WriteLine("Friend deleted successfully.");
            }
            else
            {
                Console.WriteLine("Friend not found.");
            }
        }

        public void ViewFriends()
        {
            Console.WriteLine("Friends List:");
            foreach (Friend friend in friends)
            {
                Console.WriteLine($"Name: {friend.Name}, Birthday: {friend.Birthday.ToShortDateString()}");
            }
        }

        public void CheckUpcomingBirthdays()
        {
            Console.WriteLine("Upcoming Birthdays:");
            foreach (Friend friend in friends)
            {
                if (IsUpcomingBirthday(friend.Birthday))
                {
                    Console.WriteLine($"Name: {friend.Name}, Birthday: {friend.Birthday.ToShortDateString()}");
                }
            }
        }

        private bool IsUpcomingBirthday(DateTime birthday)
        {
            DateTime today = DateTime.Today;
            DateTime upcomingBirthday = new DateTime(today.Year, birthday.Month, birthday.Day);
            if (upcomingBirthday < today)
            {
                upcomingBirthday = upcomingBirthday.AddYears(1);
            }
            return (upcomingBirthday - today).TotalDays <= 7;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BirthdayReminder reminder = new BirthdayReminder();

            Console.WriteLine("Birthday Reminder Application");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Add Friend");
                Console.WriteLine("2. Edit Friend's Birthday");
                Console.WriteLine("3. Delete Friend");
                Console.WriteLine("4. View Friends");
                Console.WriteLine("5. Check Upcoming Birthdays");
                Console.WriteLine("6. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter Friend's Name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Friend's Birthday (MM/DD/YYYY):");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime birthday))
                        {
                            reminder.AddFriend(name, birthday);
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format.");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Enter Friend's Name:");
                        string friendName = Console.ReadLine();
                        Console.WriteLine("Enter Friend's New Birthday (MM/DD/YYYY):");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime newBirthday))
                        {
                            reminder.EditFriend(friendName, newBirthday);
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format.");
                        }
                        break;
                }
            }
        }
    }
}