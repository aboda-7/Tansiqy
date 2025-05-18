using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.DAL.Models;

namespace Tansiqy.DAL.Repository
{
    public interface IFavouriteRepository
    {
        IQueryable<Favourite> GetAll();
        Favourite GetById(int id);
        void Add(Favourite fav);
        void Update(Favourite fav);
        void Delete(Favourite fav);
    }
}
