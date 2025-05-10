using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.DAL.Database;
using Tansiqy.DAL.Models;

namespace Tansiqy.DAL.Repository
{
    public class UniversityRepository : IUniversityRepository
    {
        private readonly TansiqyContext _context;
        public UniversityRepository(TansiqyContext context)
        {
            _context = context;
        }
        public void Add(University university)
        {
            _context.Universities.Add(university);
            _context.SaveChanges();
        }

        public void Delete(University university)
        {
            _context.Universities.Remove(university);
            _context.SaveChanges();
        }

        public IQueryable<University> GetAll()
        {
            return _context.Universities;
        }

        public University GetById(int id)
        {
            return _context.Universities.Find(id);
        }

        public void Update(University university)
        {
            _context.Universities.Update(university);
            _context.SaveChanges();
        }
    }
}
