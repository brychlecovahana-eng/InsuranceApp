
using InsuranceApp.Services.Models;
using InsuranceApp.Data.Models;

namespace InsuranceApp.Services.Mappers
{
    public class InsuredPersonMapper
    {
        public static InsuredPerson MapToInsuredPerson(InsuredPersonDbModel dbModel)
        {
            return new InsuredPerson
            {
                Id = dbModel.Id,
                FirstName = dbModel.FirstName,
                LastName = dbModel.LastName,
                Age = dbModel.Age,
                Phone = dbModel.Phone
            };
        }
        public static InsuredPersonDbModel MapToInsuredPersonDbModel(InsuredPerson model)
        {
            return new InsuredPersonDbModel
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Phone = model.Phone
            };
        }
    }
}
