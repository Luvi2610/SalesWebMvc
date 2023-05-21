using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;


namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcContext _context; //Impede que a dependência seja alterada
        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Department> FindAll() //Retorna lista com todos os vendedores do Banco de Dados
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
