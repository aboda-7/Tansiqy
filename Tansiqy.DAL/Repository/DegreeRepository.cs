using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.DAL.Database;
using Tansiqy.DAL.Models;

namespace Tansiqy.DAL.Repository
{
    public class DegreeRepository : IDegreeRepository
    {
        private readonly TansiqyContext _context;
        public DegreeRepository(TansiqyContext context)
        {
            _context = context;
        }
        public void Add(Degree degree)
        {
            _context.Degrees.Add(degree);
            _context.SaveChanges();
        }

        public void Delete(Degree degree)
        {
            _context.Degrees.Remove(degree);
            _context.SaveChanges();
        }

        public IQueryable<Degree> GetAll()
        {
            return _context.Degrees;
        }

        public Degree GetById(int id)
        {
            return _context.Degrees.Find(id);
        }

        public void Update(Degree degree)
        {
            _context.Degrees.Update(degree);
            _context.SaveChanges();
        }
    }
}
