using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services.Service
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly AppDbContext _appDbContext;

        public EmpleadoService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }



        public async Task<List<Empleado>> GetAllAsync()
        {
         return await _appDbContext.Empleados.Include(p => p.DepartamentoReferencia).ToListAsync();   
        }

        public async Task AddAsync(Empleado empleado)
        {
            _appDbContext.Empleados.Add(empleado);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Empleado> GetByIdAsync(int id)
        {
            return await _appDbContext.Empleados.Include(p => p.DepartamentoReferencia).Where(e => e.IdEmpleado == id).FirstOrDefaultAsync();
        }
        
        public async Task UpdateAsync(Empleado empleado)
        {
            _appDbContext.Empleados.Include(p => p.DepartamentoReferencia);
            _appDbContext.Empleados.Update(empleado);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var empleado = await _appDbContext.Empleados.FirstOrDefaultAsync(e => e.IdEmpleado == id);

            if (empleado != null)
            {
                _appDbContext.Empleados.Remove(empleado);
                await _appDbContext.SaveChangesAsync();
            }
        }

    }
}
