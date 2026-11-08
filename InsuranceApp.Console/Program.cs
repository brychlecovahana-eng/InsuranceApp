namespace InsuranceApp.Console
{
    using InsuranceApp.Services;
    using InsuranceApp.Services.Models;
    using System;

    static class Program
    {
        private static int input;
        static void Main(string[] args)
        {
            InsuredPersonService insuredPersonService = new InsuredPersonService();

            do
            {
                Console.WriteLine("---------------------------------\n Evidence pojisťených\n---------------------------------\n");
                Console.WriteLine("Vyberte si akci:\n" +
                                    "1 - Přidat nového pojistného\n" +
                                    "2 - Vypsat všechny pojistné\n" +
                                    "3 - Vyhledat pojistného\n" +
                                    "4 - Odstranit pojistného pomocí Id\n" +
                                    "5 - Konec");

                string userInput = Console.ReadLine();

                if (Validation(userInput))
                {
                    input = Int32.Parse(userInput);

                    InsuredPersonView insuredPersonVeiw = new InsuredPersonView();

                    switch (input)
                    {
                        case 1:
                            //Přidání pojistného
                            AddInsuredPersonView addInsuredPersonController = new AddInsuredPersonView();
                            InsuredPerson insuredPerson = addInsuredPersonController.StartAddNewInsuredPerson();
                            insuredPersonService.AddInsuredPerson(insuredPerson);
                            break;

                        case 2:
                            //Vypsat pojistné
                            List<InsuredPerson> insuredPeopleData = insuredPersonService.GetInsuredPersons();
                            insuredPersonVeiw.DisplayInsuredPeople(insuredPeopleData);
                            break;

                        case 3:
                            //vyhledet pojistného

                            string firstName = insuredPersonVeiw.ReadInsuredPersonFirstName();
                            string lastName = insuredPersonVeiw.ReadInsuredPersonLastName();
                            List<InsuredPerson> insuredPersonData = insuredPersonService.GetInsuredPerson(firstName, lastName);
                            insuredPersonVeiw.DisplayInsuredPeople(insuredPersonData);
                            break;

                        case 4:
                            int Id = insuredPersonVeiw.ReadInsuredPersonId();
                            bool isTrue = insuredPersonService.DeleteInsuredPerson(Id);
                            insuredPersonVeiw.DisplayDeleteResult(isTrue);
                            break;

                        case 5:
                            Console.WriteLine("Děkujeme za použití naší konzolové aplikace.");
                            break;

                        default:
                            Console.WriteLine("Nesprávně zadaný input");
                            break;

                    }
                }
            } while (input != 5);
        }

        private static bool Validation(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Chyba: Vstup nesmí být prázdný!");
                Console.ResetColor();
                return false;
            }

            if (!int.TryParse(userInput, out input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Chyba: To nebylo platné číslo!");
                Console.ResetColor();

                Console.WriteLine("Zadej číslo znovu: ");
                return false;
            }

            return true;
        }
    }
}





