using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JahresUrlaub.Domain.Model;
using JahresUrlaub.Domain.Repositories;
using JahresUrlaub.Geschäftslogik.Context;
using JahresUrlaub.Repository.Context;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace JahresUrlaub.Repository.Core
{
    public class UrlaubRepository : IUrlaubRepository
    {

        public readonly ApplicationContext _context; 
        public UrlaubRepository(ApplicationContext context)
        {
            this._context = context; 
        }

        public void CreateAsync(Urlaub urlaub)
        {
            _context.Urlaubs.InsertOne(urlaub); 
            _context.
        }

        public void DeleteAsync(int id)
        {
            
        }

        public IList<Urlaub> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Urlaub GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(int id, Urlaub urlaub)
        {
            throw new NotImplementedException();
        }
    }
}
