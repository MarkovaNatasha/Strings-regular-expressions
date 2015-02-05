using System;
using System.Collections.Generic;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = new List<Customer>
                                           {
                                               new Customer("olga", "popova", new DateTime(1991, 11, 24), "+380 98 345 35 64 78",
                                                            "popova@gmail.com", "AT 342546", 2345353546345634,
                                                            new DateTime(2011, 06, 23, 11,23,45)),
                                               new Customer("ivan", "Stepanov", new DateTime(1989, 01, 23), "+380 98 456 78 347",
                                                            "i.stepanov@i.ua", "TT 3445563", 4567345624576535,
                                                            new DateTime(2000, 01, 12, 14,11,7)),
                                               new Customer("Pavlo", "Kotov", new DateTime(1978, 04, 13), "+380 88 342 57",
                                                            "OKotov1201@info.com", "GH 4567876", 8976354687563546,
                                                            new DateTime(2012, 07, 11, 10,10,34)),
                                               new Customer("Maria", "leonova", new DateTime(1990, 08, 07), "+380 50 345 26 78",
                                                            "m.leon1990@gmail.com", "HJ 4567", 7675345634564656,
                                                            new DateTime(2013, 03, 23, 11, 34, 44)),
                                               new Customer("Stepan", "Luk", new DateTime(1988, 03, 05), "+380 66 343 54 56",
                                                            "jjuukk@mail.ru", "JK 4567765", 4563564575673456,
                                                            new DateTime(2011, 06, 11,12,13,13)),
                                           };

            object[] header = { "Name", "Surname", "Birth Day", "Phone", "Email", "Passport", "Card number", "Card date" };
            string strFormat = "{0,7} | {1,10} | {2, 10} | {3,20} | {4,20} | {5,10} | {6,19} | {7,16}";
            Console.WriteLine(strFormat, header);
            foreach (var customer in customers)
            {
                customer.Print();
            }
            Console.WriteLine();

            customers.Sort(new Customer.SortBySurname());

            foreach (var customer in customers)
            {
                customer.Print();
            }

            foreach (var customer in customers)
            {
                customer.FoundSurname("^l([a-z]*)");
                customer.FoundName("lg");
            }
            Console.WriteLine();

            Console.WriteLine("Enter name customer: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter surname customer: ");
            string surname = Console.ReadLine();
            Console.WriteLine("Enter day of birth customer: ");
            string dayBirth = Console.ReadLine();
            while (!Customer.CheckDate(dayBirth))
            {
                Console.WriteLine("Please! Enter correct day of birth customer: ");
                dayBirth = Console.ReadLine();
            }
            Console.WriteLine("Enter phone customer: ");
            string phone = Console.ReadLine();
            while (!Customer.CheckPhone(phone))
            {
                Console.WriteLine("Please! Enter correct phone customer: ");
                phone = Console.ReadLine();
            }
            Console.WriteLine("Enter email customer: ");
            string email = Console.ReadLine();
            while (!Customer.CheckEmail(email))
            {
                Console.WriteLine("Please! Enter correct email customer: ");
                email = Console.ReadLine();
            }
            Console.WriteLine("Enter passport customer: ");
            string passport = Console.ReadLine();
            while (!Customer.CheckPassport(passport))
            {
                Console.WriteLine("Please! Enter correct passport customer: ");
                passport = Console.ReadLine();
            }
            Console.WriteLine("Enter card number customer: ");
            string cardNumber = Console.ReadLine();
            Console.WriteLine("Enter card date customer: ");
            string cardDate = Console.ReadLine();
            while (!Customer.CheckDate(cardDate))
            {
                Console.WriteLine("Please! Enter correct card date customer: ");
                cardDate = Console.ReadLine();
            }

            customers.Add(new Customer(name, surname, Convert.ToDateTime(dayBirth), phone, 
                email, passport, Convert.ToInt64(cardNumber), Convert.ToDateTime(cardDate)));

            foreach (var customer in customers)
            {
                customer.ChangeIncorrectData();
                customer.Print();
            }

            Console.ReadKey();
        }
    }
}
