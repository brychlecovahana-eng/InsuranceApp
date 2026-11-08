using InsuranceApp.Data.Context;
using InsuranceApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceApp.Data.Repositories
{
    public class InsuranceRepository
    {
        private readonly AppDbContext _context;

        public InsuranceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddInsurance(InsuranceDbModel insurance)
        {
            await _context.Insurances.AddAsync(insurance);
            await _context.SaveChangesAsync();
        }

        public async Task<List<InsuranceDbModel>> GetAllInsurances()
        {
            return await _context.Insurances
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<InsuranceDbModel?> GetInsuranceById(int id)
        {
            return await _context.Insurances
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateInsurance(InsuranceDbModel insurance)
        {
            var existing = await _context.Insurances
                .FindAsync(insurance.Id);

            if (existing == null)
                return false;

            existing.Name = insurance.Name;
            existing.Description = insurance.Description;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteInsurance(int id)
        {
            var insurance = await _context.Insurances
                .FindAsync(id);

            if (insurance == null)
                return false;

            bool isUsed = await _context.InsuredPersonInsurances
                .AnyAsync(x => x.InsuranceId == id);

            if (isUsed)
                return false;

            _context.Insurances.Remove(insurance);

            await _context.SaveChangesAsync();

            return true;
        }

       
    }
}