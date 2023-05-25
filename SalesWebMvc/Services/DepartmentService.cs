using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcContext _context; //Impede que a dependência seja alterada
        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync() //Retorna lista com todos os vendedores do Banco de Dados
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync(); 
        }
    }
}
