using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.DAL.Database;
using Tansiqy.DAL.Models;

namespace Tansiqy.DAL.Repository
{
    public class FavouriteRepository : IFavouriteRepository
    {
        private readonly TansiqyContext _context;
        public FavouriteRepository(TansiqyContext context)
        {
            _context = context;
        }
        public void Add(Favourite fav)
        {
            _context.Favourites.Add(fav);
            _context.SaveChanges();
        }

        public void Delete(Favourite fav)
        {
            _context.Favourites.Remove(fav);
            _context.SaveChanges();
        }

        public IQueryable<Favourite> GetAll()
        {
            return _context.Favourites;
        }

        public Favourite GetById(int id)
        {
            return _context.Favourites.Find(id);
        }

        public void Update(Favourite fav)
        {
            _context.Favourites.Update(fav);
            _context.SaveChanges();
        }
    }
}
