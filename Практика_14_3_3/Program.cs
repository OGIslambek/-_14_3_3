﻿namespace Практика_14_3_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new List<Contact>();

            phoneBook.Add(new Contact("Анастасия", "Николаева", 79990000001, "anastasia@gmail.com"));
            phoneBook.Add(new Contact("Сергей", "Григорьев", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Барышкин", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Кондратьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Ферин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иван", "Бордодымов", 799900000013, "ivan@example.com"));


            var phoneBookSorted = phoneBook
                                  .OrderBy(s => s.Name)
                                  .ThenBy(s => s.LastName);



            while (true)
            {
                var input = Console.ReadKey().KeyChar;

                var parsed = Int32.TryParse(input.ToString(), out int pageNumber);

                if (!parsed || pageNumber < 1 || pageNumber > 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Страницы не существует");
                }
                else
                {
                    var pageContent = phoneBookSorted.Skip((pageNumber - 1) * 2).Take(2);
                    Console.WriteLine();

                    foreach (var entry in pageContent)
                        Console.WriteLine(entry.Name + " " + entry.LastName + ": " + entry.PhoneNumber);

                    Console.WriteLine();
                }
            }


        }

        public class Contact
        {
            public Contact(string name, string lastName, long phoneNumber, String email)
            {
                Name = name;
                LastName = lastName;
                PhoneNumber = phoneNumber;
                Email = email;
            }

            public String Name { get; }
            public String LastName { get; }
            public long PhoneNumber { get; }
            public String Email { get; }
        }
    }
}
