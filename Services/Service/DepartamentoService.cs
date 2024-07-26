using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly AppDbContext _appDbContext;

        public DepartamentoService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Departamento>> GetAllAsync()
        {
            return await _appDbContext.Departamentos.ToListAsync();
        }

        public async Task AddAsync(Departamento departamento)
        {
            await _appDbContext.Departamentos.AddAsync(departamento);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Departamento> GetByIdAsync(int id)
        {
            return await _appDbContext.Departamentos.FirstOrDefaultAsync(e => e.IdDepartamento == id);
        }

        public async Task UpdateAsync(Departamento departamento)
        {
            _appDbContext.Departamentos.Update(departamento);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var departamento = await _appDbContext.Departamentos.FirstOrDefaultAsync(e => e.IdDepartamento == id);

            if (departamento != null)
            {
                _appDbContext.Departamentos.Remove(departamento);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
