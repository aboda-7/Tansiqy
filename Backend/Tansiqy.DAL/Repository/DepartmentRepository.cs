using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.DAL.Database;
using Tansiqy.DAL.Models;

namespace Tansiqy.DAL.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly TansiqyContext _context;
        public DepartmentRepository(TansiqyContext context)
        {
            _context = context;
        }
        public void Add(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void Delete(Department department)
        {
            _context.Departments.Remove(department);
            _context.SaveChanges();
        }

        public IQueryable<Department> GetAll()
        {
            return _context.Departments;
        }

        public Department GetById(int id)
        {
            return _context.Departments.Find(id);
        }

        public void Update(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
        }
    }
}
