using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace InsuranceApp.Services.Models
{
    public class InsuredPerson
    {
        //This class represent insured person.
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Age { get; set; }
        public string Phone { get; set; } = "";

        public InsuredPerson()
        {

        }

        public InsuredPerson(int id, string firstName, string lastName, int age, string phone)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Phone = phone;
        }

        public override string ToString()
        {
            return $@"{this.Id} {this.FirstName} {this.LastName} {this.Age} {this.Phone}";
        }

        public static ValidationModel ValidateFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                return new ValidationModel(false, "Chyba: Vstup nesmí být prázdný!");


            if (firstName.Length > 20)
                return new ValidationModel(false, "Chyba: Překročen maximalní počet znaku!");

            if (!char.IsUpper(firstName[0]))
                return new ValidationModel(false, "Chyba: První písmeno musí být velké.");

            if (!Regex.IsMatch(firstName, @"^\p{L}+$"))
                return new ValidationModel(false, "Chyba: Neplatný znak.");

            return new ValidationModel(true, string.Empty);
        }

        public static ValidationModel ValidateLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
                return new ValidationModel(false, "Chyba: Vstup nesmí být prázdný!");

            if (lastName.Length > 50)
                return new ValidationModel(false, "Chyba: Překročen maximalní počet znaku!");

            if (!char.IsUpper(lastName[0]))
                return new ValidationModel(false, "Chyba: První písmeno musí být velké.");

            if (!Regex.IsMatch(lastName, @"^\p{Lu}\p{L}*([ -]\p{Lu}\p{L}*)*$"))
                return new ValidationModel(false, "Chyba: Neplatný znak.");

            return new ValidationModel(true, string.Empty);
        }

        public static ValidationModel ValidateAge(string age)
        {
            if (string.IsNullOrWhiteSpace(age))
                return new ValidationModel(false, "Chyba: Vstup nesmí být prázdný!");

            if (!int.TryParse(age, out int ageValue))
                return new ValidationModel(false, "Chyba: Věk zadejte v číselné podobě!");

            if (ageValue < 0 || ageValue > 120)
                return new ValidationModel(false, "Chyba: Neplatná hodnota věku.");

            return new ValidationModel(true, string.Empty);
        }

        public static ValidationModel ValidatePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return new ValidationModel(false, "Chyba: Vstup nesmí být prázdný!");

            // Maximální délka telefonního čísla.
            if (phone.Length > 16)
                return new ValidationModel(false, "Chyba: Vstup nesmí obsahovat více než 16 znaků.");

            // Zakážeme mezery.
            if (phone.Contains(' '))
                return new ValidationModel(false, "Chyba: Nezadávejte mezery.");

            // Povolíme čísla a případně + na začátku.
            if (!Regex.IsMatch(phone, @"^\+?[0-9]+$"))
                return new ValidationModel(false, "Chyba: Neplatný znak");

            // Telefon musí obsahovat alespoň 9 číslic.
            int digitCount = phone.Count(char.IsDigit);

            if (digitCount < 9)
                return new ValidationModel(false, "Chyba: Neplatná délka tel. čísla!");

            return new ValidationModel(true, string.Empty);
        }
    }
}
