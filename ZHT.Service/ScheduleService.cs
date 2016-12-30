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
    public class ScheduleService : IScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IScheduleRepository _scheduleRepository;
        public ScheduleService(IUnitOfWork unitOfWork, IScheduleRepository scheduleRepository)
        {
            _unitOfWork = unitOfWork;
            _scheduleRepository = scheduleRepository;
        }
        public List<Schedule> GetAllList()
        {
            return _scheduleRepository.Table.ToList();
        }

        public Schedule GetModelById(string id)
        {
            return _scheduleRepository.GetById(id);
        }

        public void InsertSchedule(Schedule _schedule)
        {
            _scheduleRepository.Add(_schedule);
            _unitOfWork.Commint();
        }

        public void Delete(Schedule _schedule)
        {
            _scheduleRepository.Delete(_schedule);
            _unitOfWork.Commint();
        }

        public void Update(Schedule _schedule)
        {
            _scheduleRepository.Update(_schedule);
            _unitOfWork.Commint();
        }
    }
}
