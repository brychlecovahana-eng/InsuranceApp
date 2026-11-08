using InsuranceApp.Data.Context;
using InsuranceApp.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InsuranceApp.Data.Repositories

{
    public class InsuredPersonRepository
    {
        private readonly AppDbContext _context;

        public InsuredPersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddInsuredPersonDB(InsuredPersonDbModel insuredPerson)
        {
            //Přístup k tabulce
            //.AddAsync(insuredPerson) --- Připraví nový záznam k vložení
            await _context.InsuredPersons.AddAsync(insuredPerson);
            //Provede SQL INSERT v databázi
            await _context.SaveChangesAsync();
        }

        public async Task<List<InsuredPersonDbModel>> GetInsuredPersonsDbModels()
        {
            // Logic to get List of Insured persons
            return await _context.InsuredPersons.ToListAsync();
            
        }

        public async Task<List<InsuredPersonDbModel>> GetInsuredPersonDbmodel(string firstName, string lastName)
        {
            // Logic to get insured person by name
            return await _context.InsuredPersons.Where(p => p.FirstName == firstName && p.LastName == lastName).ToListAsync();
        }

        public async Task<InsuredPersonDbModel?> GetInsuredPersonById(int id)
        {
            return await _context.InsuredPersons.FirstOrDefaultAsync(p => p.Id == id);


        }

        public async Task<bool> DeleteInsuredPerson(int id)
        {
            InsuredPersonDbModel? dataModel =
                await _context.InsuredPersons.FindAsync(id);

            if (dataModel == null)
                return false;

            _context.InsuredPersons.Remove(dataModel);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
