using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;
using ZHT.Core.UnitOfWork;
using ZHT.Data.Models;
using ZHT.Repository;

namespace ZHT.Service
{
    public class ExhibitionService : IExhibitionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExhibitionRepository _exhibitionRepository;
        public ExhibitionService(IUnitOfWork unitOfWork, IExhibitionRepository exhibitionRepository)
        {
            _unitOfWork = unitOfWork;
            _exhibitionRepository = exhibitionRepository;
        }
        public List<Exhibition> GetAllList()
        {
            return _exhibitionRepository.Table.ToList();
        }

        public void InsertExhibition(Exhibition exhibition)
        {

            _exhibitionRepository.Add(exhibition);
            _unitOfWork.Commint();
        }

        public Exhibition GetModelById(string id)
        {
            return _exhibitionRepository.GetById(id);
        }

        public void Update(Exhibition exhibition)
        {
            _exhibitionRepository.Update(exhibition);
            _unitOfWork.Commint();
        }

        public void Delete(Exhibition exhibition)
        {
            _exhibitionRepository.Delete(exhibition);
            _unitOfWork.Commint();
        }

        /// <summary>
        /// 获取展会列表 0-未结束 1-已结束
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<Exhibition> GetExhibitionListByStatus(int status)
        {
            var query = _exhibitionRepository.Table;
            if (status == 0)
            {
                query = query.Where(t => t.endtime > DateTime.Now);
            }
            else if (status == 1)
            {
                query = query.Where(t => t.endtime < DateTime.Now);
            }
            return query.ToList();
        }

        /// <summary>
        /// 分页获取所有展会列表
        /// </summary>
        /// <param name="status">展会状态</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchKey"></param>
        /// <returns></returns>
        public PagedList<Exhibition> GetExhibitionListByStatusPage(int status, int pageIndex, int pageSize, string searchKey = null)
        {
            var query = _exhibitionRepository.Table;

            if (status == 0)
            {
                query = query.Where(t => t.endtime > DateTime.Now);
            }
            else if( status == 1)
            {
                query = query.Where(t => t.endtime < DateTime.Now);
            }

            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                query = query.Where(t => t.exhibitionname.Contains(searchKey));
            }

            query = query.OrderByDescending(t => t.creattime);
            PagedList<Exhibition> exhibitionList = query.ToPagedList(pageIndex, pageSize);

            return exhibitionList;
        }

    }
}
