using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Core.UnitOfWork;
using ZHT.Data.Models;
using ZHT.Repository;

namespace ZHT.Service
{
    public class MaterialService : IMaterialService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMaterialRepository _materialRepository;
        public MaterialService(IUnitOfWork unitOfWork, IMaterialRepository materialRepository)
        {
            _unitOfWork = unitOfWork;
            _materialRepository = materialRepository;
        }
        public void Delete(Material material)
        {
            _materialRepository.Delete(material);
            _unitOfWork.Commint();
        }


        public Material GetModelById(string id)
        {
            return _materialRepository.GetById(id);
        }

        public void InsertBaseTypes(Material material)
        {
            _materialRepository.Add(material);
            _unitOfWork.Commint();
        }

        public void Update(Material material)
        {
            _materialRepository.Update(material);
            _unitOfWork.Commint();
        }

        public List<Material> GetAllList()
        {
            return _materialRepository.Table.ToList();
        }
    }
}
