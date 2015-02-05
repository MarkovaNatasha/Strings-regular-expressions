using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Task7
{
    class Customer
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DayBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Passport { get; set; }
        public long CardNumber { get; set; }
        public DateTime CardDate { get; set; }

        public Customer()
        {
            Name = "";
            Surname = "";
            DayBirth = new DateTime();
            Phone = "";
            Email = "";
            Passport = "";
            CardNumber = 0;
            CardDate = new DateTime();
        }

        public Customer(string name, string surname, DateTime dayBirth, string phone, string email, string passport, long cardNumber, DateTime cardDate)
        {
            Name = name;
            Surname = surname;
            DayBirth = dayBirth;
            Phone = phone;
            Email = email;
            Passport = passport;
            CardNumber = cardNumber;
            CardDate = cardDate;
        }

        public void FoundSurname(string strPattern)
        {
            if (Regex.IsMatch(Surname, strPattern, RegexOptions.IgnoreCase))
            {
                Console.WriteLine("This surname is matching with pattern -> {0}",Surname);
            }
        }

        public void FoundName(string strPattern)
        {
            if (Regex.IsMatch(Name, strPattern, RegexOptions.IgnoreCase))
            {
                Console.WriteLine("This name is matching with pattern -> {0}", Name);
            }
        }

        public void Print()
        {
            Console.WriteLine("{0,7} | {1,10} | {2, 10} | {3,20} | {4,20} | {5,10} | " + 
                String.Format(new CustomFormatter(), "{0}", CardNumber) + " | {6,16}",
                Name, Surname, DayBirth.ToString("d", CultureInfo.CurrentCulture), Phone, 
                Email, Passport, CardDate.ToString("g", CultureInfo.CurrentCulture));           
        }

        public class SortBySurname : IComparer<Customer>
        {
            public int Compare(Customer x, Customer y)
            {
                return String.Compare(x.Surname, y.Surname);
            }
        }

        public class SortByDateBirth : IComparer<Customer>
        {
            public int Compare(Customer x, Customer y)
            {
                return DateTime.Compare(x.DayBirth, y.DayBirth);
            }
        }

        public class SortByPhone : IComparer<Customer>
        {
            public int Compare(Customer x, Customer y)
            {
                return String.Compare(x.Phone, y.Phone);
            }
        }

        public void ChangeIncorrectData()
        {
            if(!char.IsUpper(Name[0]))
            {
                Name = Name.Remove(1, Name.Length - 1).ToUpper() + Name.Remove(0,1);
            }
            if (!char.IsUpper(Surname[0]))
            {
                Surname = Surname.Remove(1, Surname.Length - 1).ToUpper() + Surname.Remove(0, 1);
            }
            if(Phone.Length > 17)
            {
                Phone = Phone.Remove(17);
            }
            if (Phone.Length < 17)
            {
                int dx = 17 - Phone.Length;
                var addStr = new string('x', dx);
                Phone = Phone.Replace(Phone, Phone + addStr);
            }
            if(Passport.Length > 9)
            {
                Passport = Passport.Remove(9);
            }
            if(Passport.Length < 9)
            {
                int dx = 9 - Passport.Length;
                var addStr = new string('0', dx);
                Passport = Passport.Insert(Passport.Length, addStr);
            }
        }

        public static bool CheckNameSurname(string name)
        {
            return Regex.IsMatch(name, @"^[A-Za-z]*");
        }

        public static bool CheckDate(string date)
        {
            return Regex.IsMatch(date, @"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d");
        }

        public static bool CheckPhone(string phone)
        {
            return Regex.IsMatch(phone, @"(\+380)\s(\d{2})\s(\d{3})\s(\d{2})\s(\d{2})");
        }

        public static bool CheckEmail(string email)
        {
            return Regex.IsMatch(email, @"([A-Z;a-z;0-9;\x2E;\x2D;_]+)?@([A-Z;a-z;0-9;\x2E;-;]+)?");
        }

        public static bool CheckPassport(string passport)
        {
            return Regex.IsMatch(passport, @"[A-Z]{2}\s(\d{6})");
        }
    }
}
