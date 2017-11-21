using KimShop.Data.Infrastructure;
using KimShop.Data.Repositories;
using KimShop.Model.Models;
using System.Collections.Generic;

namespace KimShop.Service
{
    public interface IMenuGroupService
    {
        MenuGroup Add(MenuGroup menuGroup);

        void Update(MenuGroup menuGroup);

        void Delete(int id);

        void Save();

        IEnumerable<MenuGroup> GetAll();

        MenuGroup GetById(int id);
    }

    public class MenuGroupService : IMenuGroupService
    {
        private IMenuGroupRepository _iMenuGroupRepository;
        private IUnitOfWork _iUnitOfWork;

        public MenuGroupService(IMenuGroupRepository menuGroupRepository, IUnitOfWork iUnitOfWork)
        {
            this._iMenuGroupRepository = menuGroupRepository;
            this._iUnitOfWork = iUnitOfWork;
        }

        public MenuGroup Add(MenuGroup menuGroup)
        {
            return _iMenuGroupRepository.Add(menuGroup);
        }

        public void Delete(int id)
        {
            _iMenuGroupRepository.Delete(id);
        }

        public IEnumerable<MenuGroup> GetAll()
        {
            return _iMenuGroupRepository.GetAll();
        }

        public MenuGroup GetById(int id)
        {
            return _iMenuGroupRepository.GetSingleById(id);
        }

        public void Save()
        {
            _iUnitOfWork.Commit();
        }

        public void Update(MenuGroup menuGroup)
        {
            _iMenuGroupRepository.Update(menuGroup);
        }
    }
}