using InsuranceApp.Data.Models;
using InsuranceApp.Services.Enums;
using InsuranceApp.Services.Models;

namespace InsuranceApp.Services.Mappers
{
    public static class InsuranceMapper
    {
        public static Insurance MapToBusiness(InsuranceDbModel model)
        {
            return new Insurance
            {
                Id = model.Id,
                InsuredPersonId = model.InsuredPersonId,
                InsuranceCategory = (InsuranceCategory)model.InsuranceCategory,
                Name = model.Name,
                ContractNumber = model.ContractNumber,
                ValidFrom = model.ValidFrom,
                ValidTo = model.ValidTo,
                Price = model.Price,
                Description = model.Description,
                
            };
        }

        public static InsuranceDbModel MapToDatabase(Insurance model)
        {
            return new InsuranceDbModel
            {
                InsuredPersonId = model.InsuredPersonId,
                InsuranceCategory = (int)model.InsuranceCategory,
                Name = model.Name,
                ContractNumber = model.ContractNumber,
                ValidFrom = model.ValidFrom,
                ValidTo = model.ValidTo,
                Price = model.Price,
                Description = model.Description,
            };
        }
    }
}
