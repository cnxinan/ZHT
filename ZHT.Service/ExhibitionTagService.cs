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
    public class ExhibitionTagService : IExhibitionTagService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExhibitionTagRepository _exhibitionTagRepository;
        public ExhibitionTagService(IUnitOfWork unitOfWork, IExhibitionTagRepository exhitionTagRepository)
        {
            _unitOfWork = unitOfWork;
            _exhibitionTagRepository = exhitionTagRepository;
        }

        public List<ExhibitionTag> GetExhibitionTagList()
        {
            var query = _exhibitionTagRepository.Table;
            return query.ToList();
        }

        public void InsertExhitionTag(ExhibitionTag exhitionTag)
        {
            _exhibitionTagRepository.Add(exhitionTag);
            _unitOfWork.Commint();
        }

        public void Delete(ExhibitionTag exhitionTag)
        {
            _exhibitionTagRepository.Delete(exhitionTag);
            _unitOfWork.Commint();
        }

        public void Update(ExhibitionTag exhitionTag)
        {
            _exhibitionTagRepository.Update(exhitionTag);
            _unitOfWork.Commint();
        }

        public ExhibitionTag GetModelById(string id)
        {
            return _exhibitionTagRepository.GetById(id);
        }
    }
}
