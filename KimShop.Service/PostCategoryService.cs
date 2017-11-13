using KimShop.Data.Infrastructure;
using KimShop.Data.Repositories;
using KimShop.Model.Models;
using System;
using System.Collections.Generic;

namespace KimShop.Service
{
    public interface IPostCategoryService
    {
        PostCategory Add(PostCategory postCategory);

        void Update(PostCategory postCategory);

        void Delete(int id);

        void Save();

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

        public PostCategory Add(PostCategory postCategory)
        {
            return _iPostCategoryRepository.Add(postCategory);
        }

        public void Delete(int id)
        {
            _iPostCategoryRepository.Delete(id);
        }

        public void Save()
        {
            _iUnitOfWork.Commit();
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