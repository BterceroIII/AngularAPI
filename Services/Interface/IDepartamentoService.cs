using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IDepartamentoService
    {
        Task<List<Departamento>> GetAllAsync();
        Task AddAsync(Departamento departamento);
        Task<Departamento> GetByIdAsync(int id);
        Task UpdateAsync(Departamento departamento);
        Task DeleteAsync(int id);
    }
}
