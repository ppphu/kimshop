using KimShop.Data.Infrastructure;
using KimShop.Data.Repositories;
using KimShop.Model.Models;
using System.Collections.Generic;

namespace KimShop.Service
{
    public interface IMenuService
    {
        Menu Add(Menu menu);

        void Update(Menu menu);

        void Delete(int id);

        void Save();

        IEnumerable<Menu> GetAll();

        Menu GetById(int id);
    }

    public class MenuService : IMenuService
    {
        private IMenuRepository _iMenuRepository;
        private IUnitOfWork _iUnitOfWork;

        public MenuService(IMenuRepository menuRepository, IUnitOfWork iUnitOfWork)
        {
            this._iMenuRepository = menuRepository;
            this._iUnitOfWork = iUnitOfWork;
        }

        public Menu Add(Menu menu)
        {
            return _iMenuRepository.Add(menu);
        }

        public void Delete(int id)
        {
            _iMenuRepository.Delete(id);
        }

        public IEnumerable<Menu> GetAll()
        {
            return _iMenuRepository.GetAll(new string[] { "MenuGroup" });
        }

        public Menu GetById(int id)
        {
            return _iMenuRepository.GetSingleById(id);
        }

        public void Save()
        {
            _iUnitOfWork.Commit();
        }

        public void Update(Menu menu)
        {
            _iMenuRepository.Update(menu);
        }
    }
}