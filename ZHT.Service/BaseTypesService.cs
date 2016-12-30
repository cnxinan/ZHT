using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Core.UnitOfWork;
using ZHT.Data.DbFactory;
using ZHT.Data.Models;
using ZHT.Repository;

namespace ZHT.Service
{
    public class BaseTypesService : IBaseTypesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseTypesRepository _baseTypeRepository;

        public BaseTypesService(IUnitOfWork unitOfWork, IBaseTypesRepository baseTypeReository)
        {
            _unitOfWork = unitOfWork;
            _baseTypeRepository = baseTypeReository;
        }

        public List<BaseTypes> GetBaseTypesList()
        {
            var query = _baseTypeRepository.Table.ToList();
            return query;
        }

        public void InsertBaseTypes(BaseTypes baseType)
        {
            _baseTypeRepository.Add(baseType);
            _unitOfWork.Commint();
        }

        public void Update(BaseTypes baseType)
        {
            _baseTypeRepository.Update(baseType);
            _unitOfWork.Commint();
        }

        public void Delete(BaseTypes baseType)
        {
            _baseTypeRepository.Delete(baseType);
            _unitOfWork.Commint();
        }

        public BaseTypes GetModelById(string id)
        {
            return _baseTypeRepository.GetById(id);
        }
    }
}
