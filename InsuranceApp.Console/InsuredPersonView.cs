
namespace InsuranceApp.Console
{
    using InsuranceApp.Services;
    using InsuranceApp.Services.Models;
    using System;

    public class InsuredPersonView
    {
        
        public InsuredPersonView()
        {

        }

        public void DisplayInsuredPeople(List<InsuredPerson> insuredPeople)
        {
            Console.WriteLine("Id FirstName LastName Age Phone");
            Console.WriteLine("---------------------------------");
            foreach (InsuredPerson person in insuredPeople)
            {
                Console.WriteLine(person.ToString());
            }
        }

        public void DisplayDeleteResult(bool isTrue)
        {
            if (isTrue)
            {
                Console.WriteLine("Pojištěný byl odstraněn.");
            }
            else
            {
                Console.WriteLine("Pojistený s zadaným Id nebyl nalezen.");
            }
        }

        public int ReadInsuredPersonId()
        {
            Console.WriteLine("Zadejte Id pojištěného:");
            int Id = Int32.Parse(Console.ReadLine() ?? string.Empty);
            return Id;
        }

        public string ReadInsuredPersonFirstName()
        {
            Console.WriteLine("Zadej jméno pojistného:");
            return Console.ReadLine() ?? string.Empty;
        }

        public string ReadInsuredPersonLastName()
        {
            Console.WriteLine("Zadej příjmení pojistného:");
            return Console.ReadLine() ?? string.Empty;
        }
    }
}
