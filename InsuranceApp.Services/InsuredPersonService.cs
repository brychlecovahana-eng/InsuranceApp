using InsuranceApp.Data.Models;
using InsuranceApp.Data.Repositories;
using InsuranceApp.Services.Mappers;
using InsuranceApp.Services.Models;

namespace InsuranceApp.Services
{
    public class InsuredPersonService
    {
        private InsuredPersonRepository InsuredPersonRepository;
        public InsuredPersonService(InsuredPersonRepository insuredPersonRepository)
        {
            InsuredPersonRepository = insuredPersonRepository;
        }

        public async Task AddInsuredPerson(InsuredPerson insuredPerson)
        {
            // Logic to add an insured person
            await InsuredPersonRepository.AddInsuredPersonDB(InsuredPersonMapper.MapToInsuredPersonDbModel(insuredPerson));
        }

        public async Task<List<InsuredPerson>> GetInsuredPersons()
        {
            // Logic to get list of insured persons
            var dbModels = await InsuredPersonRepository.GetInsuredPersonsDbModels();
            return dbModels.Select(p => InsuredPersonMapper.MapToInsuredPerson(p)).ToList();
        
        }

        public async Task<List<InsuredPerson>> GetInsuredPerson(string FirstName, string LastName)
        {
            // Logic to get insured person by name
            var people = await InsuredPersonRepository.GetInsuredPersonDbmodel(FirstName, LastName);
            return people.Select(p => InsuredPersonMapper.MapToInsuredPerson(p)).ToList();
        }

        public async Task<InsuredPerson?> GetInsuredPersonById(int id)
        {
            //logic to get insured person by Id
            InsuredPersonDbModel? DbModel = InsuredPersonRepository.GetInsuredPersonById(id).Result;
            //antierror
            if(DbModel != null)
                return InsuredPersonMapper.MapToInsuredPerson(DbModel);

            return null;
        }

        public async Task<bool> DeleteInsuredPerson(int id)
        {
            return await InsuredPersonRepository.DeleteInsuredPerson(id);
        }
    }
}
