using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.BLL.Dtos.DegreeDtos;
using Tansiqy.DAL.Models;
using Tansiqy.DAL.Repository;

namespace Tansiqy.BLL.Manager
{
    public class DegreeManager : IDegreeManager
    {
        private readonly IDegreeRepository _degreeRepository;
        public DegreeManager(IDegreeRepository degreeRepository)
        {
            _degreeRepository = degreeRepository;
        }
        public void Add(DegreeAddDtos degree)
        {

            var degreeModel = new Degree
            {
                Name = degree.Name,
                Type = degree.Type,
            };
            _degreeRepository.Add(degreeModel);
        }

        public void Delete(int id)
        {
            var degreeModel = _degreeRepository.GetById(id);
            _degreeRepository.Delete(degreeModel);
        }

        public IEnumerable<DegreeReadDtos> GetAll()
        {
            var degreeModel = _degreeRepository.GetAll();
            var degreeDtos = degreeModel.Select(d => new DegreeReadDtos
            {
                Degid = d.ID,
                Name = d.Name,
                Type = d.Type,
            }).ToList();

            return degreeDtos;
        }

        public DegreeReadDtos GetById(int id)
        {

            var degreeModel = _degreeRepository.GetById(id);

            if (degreeModel == null)
            {
                throw new InvalidOperationException("Degree Not Found");
            }

            var degreeDtos = new DegreeReadDtos
            {
                Degid = degreeModel.ID,
                Name = degreeModel.Name,
                Type = degreeModel.Type,
            };
            return degreeDtos;
        }

        public void Update(int id, DegreeUpdateDtos degree)
        {
            var degreeModel = _degreeRepository.GetById(id);

            degreeModel.Name = degree.Name;
            degreeModel.Type = degree.Type;

            _degreeRepository.Update(degreeModel);
        }
    }
}
