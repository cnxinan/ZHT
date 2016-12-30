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
    public class MyFavoritesService : IMyFavoritesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMyFavoritesRepository _myFavoritesRepository;
        public MyFavoritesService(IUnitOfWork unitOfWork, IMyFavoritesRepository myFavoritesRepository)
        {
            _unitOfWork = unitOfWork;
            _myFavoritesRepository = myFavoritesRepository;
        }
        public void Delete(MyFavorites myFavorites)
        {
            _myFavoritesRepository.Delete(myFavorites);
            _unitOfWork.Commint();
        }

        public List<MyFavorites> GetAllList()
        {
            return _myFavoritesRepository.Table.ToList();
        }

        public MyFavorites GetModelById(string id)
        {
            return _myFavoritesRepository.GetById(id);
        }

        public void Insert(MyFavorites myFavorites)
        {
            _myFavoritesRepository.Add(myFavorites);
            _unitOfWork.Commint();
        }

        public void Update(MyFavorites myFavorites)
        {
            _myFavoritesRepository.Update(myFavorites);
            _unitOfWork.Commint();
        }

        public MyFavorites GetModelByTargetIdAndUserId(string targetId, string userId)
        {
            return _myFavoritesRepository.Table.Where(t => t.favoritescode == targetId && t.usercode == userId).FirstOrDefault();
        }
    }
}
