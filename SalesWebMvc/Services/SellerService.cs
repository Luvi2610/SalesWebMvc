using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context; //Impede que a dependência seja alterada
        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll() //Retorna lista com todos os vendedores do Banco de Dados
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id); //Procura o primeiro objeto que possua o id passado por parâmetro
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if(!_context.Seller.Any(x => x.Id == obj.Id)) //Verifica se o id do objeto passado existe no Banco
            {
                throw new NotFoundException("Id not Found");                    
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e) //Intercepta exceção de acesso a nível de dados
            {
                throw new DbConcurrencyException(e.Message); //Relança a nível de serviço
            }
        }
    }
}
