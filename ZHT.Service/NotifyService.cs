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
    public class NotifyService : INotifyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotifyRepository _notifyRepository;
        public NotifyService(IUnitOfWork unitOfWork, INotifyRepository notifyRepository)
        {
            _unitOfWork = unitOfWork;
            _notifyRepository = notifyRepository;
        }
        public void Delete(Notify notify)
        {
            _notifyRepository.Delete(notify);
            _unitOfWork.Commint();
        }

        public List<Notify> GetAllList()
        {
            return _notifyRepository.Table.ToList();
        }

        public Notify GetModelById(string id)
        {
            return _notifyRepository.GetById(id);
        }

        public void Insert(Notify notify)
        {
            _notifyRepository.Add(notify);
            _unitOfWork.Commint();
        }

        public void Update(Notify notify)
        {
            _notifyRepository.Update(notify);
            _unitOfWork.Commint();
        }
    }
}
