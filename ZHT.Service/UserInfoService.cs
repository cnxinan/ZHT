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
    public class UserInfoService : IUserInfoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserInfoRepository _userInfoRepository;
        public UserInfoService(IUnitOfWork unitOfWork,IUserInfoRepository userInfoRepository)
        {
            _unitOfWork = unitOfWork;
            _userInfoRepository = userInfoRepository;
        }
        public List<UserInfo> GetAllList()
        {
            return _userInfoRepository.Table.ToList();
        }

        public UserInfo GetModelById(string id)
        {
           return _userInfoRepository.GetById(id);
        }

        public void InsertUserInfo(UserInfo _userInfo)
        {
            _userInfoRepository.Add(_userInfo);
            _unitOfWork.Commint();
        }

        public void Delete(UserInfo _userInfo)
        {
            _userInfoRepository.Delete(_userInfo);
            _unitOfWork.Commint();
        }

        public void Update(UserInfo _userInfo)
        {
            _userInfoRepository.Update(_userInfo);
            _unitOfWork.Commint();
        }
    }
}
