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
    public class TicketsSetService : ITicketsSetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITicketsSetRepository _ticketsSetRepository;
        public TicketsSetService(IUnitOfWork unitOfWork, ITicketsSetRepository ticketsSetRepository)
        {
            _unitOfWork = unitOfWork;
            _ticketsSetRepository = ticketsSetRepository;
        }
        public List<TicketsSet> GetAllList()
        {
            return _ticketsSetRepository.Table.ToList();
        }

        public TicketsSet GetMoelById(string id)
        {
            return _ticketsSetRepository.GetById(id);
        }

        public void InsertTicketsSet(TicketsSet _ticketsSet)
        {
            _ticketsSetRepository.Add(_ticketsSet);
            _unitOfWork.Commint();
        }

        public void Delete(TicketsSet _ticketsSet)
        {
            _ticketsSetRepository.Delete(_ticketsSet);
            _unitOfWork.Commint();
        }

        public void Update(TicketsSet _ticketsSet)
        {
            _ticketsSetRepository.Update(_ticketsSet);
            _unitOfWork.Commint();
        }
    }
}
