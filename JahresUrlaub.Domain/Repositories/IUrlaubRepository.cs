using JahresUrlaub.Domain.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JahresUrlaub.Domain.Repositories
{
    /// <summary>
	/// Vacation repository interface.
	/// </summary>
    public interface IUrlaubRepository
    {
        IList<Urlaub> GetAllAsync();
        Urlaub GetByIdAsync(int id);
        public void CreateAsync(Urlaub urlaub);
        public void UpdateAsync(int id, Urlaub urlaub);
        public void DeleteAsync(int id);

    }
}
