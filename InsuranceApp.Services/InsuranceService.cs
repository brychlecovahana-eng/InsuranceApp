using InsuranceApp.Data.Repositories;
using InsuranceApp.Services.Models;
using InsuranceApp.Services.Mappers;

namespace InsuranceApp.Services
{
    public class InsuranceService
    {
        private readonly InsuranceRepository _repository;

        public InsuranceService(InsuranceRepository repository)
        {
            _repository = repository;
        }

        public async Task AddInsurance(Insurance insurance)
        {
            var dbModel = InsuranceMapper.MapToDatabase(insurance);

            await _repository.AddInsurance(dbModel);
        }

        public async Task<List<Insurance>> GetAllInsurances()
        {
            var dbModels = await _repository.GetAllInsurances();

            return dbModels.Select(InsuranceMapper.MapToBusiness).ToList();
        }

        public async Task<Insurance?> GetInsuranceById(int id)
        {
            var dbModel = await _repository.GetInsuranceById(id);

            if (dbModel == null)
                return null;

            return InsuranceMapper.MapToBusiness(dbModel);
        }

        public async Task<bool> UpdateInsurance(int id, Insurance insurance)
        {
            var dbModel = InsuranceMapper.MapToDatabase(insurance);

            dbModel.Id = id;

            return await _repository.UpdateInsurance(dbModel);
        }

        public async Task<bool> DeleteInsurance(int id)
        {
            return await _repository.DeleteInsurance(id);
        }

        

    }
}
