using KimShop.Data.Infrastructure;
using KimShop.Data.Repositories;
using KimShop.Model.Models;
using System;
using System.Collections.Generic;

namespace KimShop.Service
{
    public interface IPostCategoryService
    {
        void Add(PostCategory postCategory);

        void Update(PostCategory postCategory);

        void Delete(int id);

        IEnumerable<PostCategory> GetAll();

        IEnumerable<PostCategory> GetAllByParentId(int parentID);

        PostCategory GetById(int id);
    }

    public class PostCategoryService : IPostCategoryService
    {
        private IPostCategoryRepository _iPostCategoryRepository;
        private IUnitOfWork _iUnitOfWork;

        public PostCategoryService(IPostCategoryRepository iPostCategoryRepository, IUnitOfWork iUnitOfWork)
        {
            this._iPostCategoryRepository = iPostCategoryRepository;
            this._iUnitOfWork = iUnitOfWork;
        }

        public void Add(PostCategory postCategory)
        {
            _iPostCategoryRepository.Add(postCategory);
        }

        public void Delete(int id)
        {
            _iPostCategoryRepository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _iPostCategoryRepository.GetAll();
        }

        public IEnumerable<PostCategory> GetAllByParentId(int parentID)
        {
             return _iPostCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentID);
        }

        public PostCategory GetById(int id)
        {
            return _iPostCategoryRepository.GetSingleById(id);
        }

        public void Update(PostCategory postCategory)
        {
            _iPostCategoryRepository.Update(postCategory);
        }
    }
}