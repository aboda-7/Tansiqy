using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.DAL.Database;
using Tansiqy.DAL.Models;

namespace Tansiqy.DAL.Repository
{
    public class FacultyRepository : IFacultyRepository
    {
        private readonly TansiqyContext _context;
        public FacultyRepository(TansiqyContext context) 
        {
            _context = context;
        }
        public void Add(Faculty faculty)
        {
            _context.Faculties.Add(faculty);
            _context.SaveChanges();
        }

        public void Delete(Faculty faculty)
        {
            _context.Remove(faculty);
            _context.SaveChanges();
        }

        public IQueryable<Faculty> GetAll()
        {
            return _context.Faculties;
        }

        public Faculty GetById(int id)
        {
            return _context.Faculties.Find(id);
        }

        public void Update(Faculty faculty)
        {
            _context.SaveChanges();
        }
    }
}
