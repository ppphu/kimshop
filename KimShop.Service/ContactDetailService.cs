using KimShop.Data.Infrastructure;
using KimShop.Data.Repositories;
using KimShop.Model.Models;

namespace KimShop.Service
{
    public interface IContactDetailService
    {
        ContactDetail GetDefaultContact();

        //void Add(ContactDetail contact);

        //void Save();

        //void Update(ContactDetail contact);

        //void Delete(int id);

        //IEnumerable<ContactDetail> GetAll();

        //Post GetById(int id);

        //IEnumerable<ContactDetail> GetAllPaging(int page, int pageSize, out int totalRow);

        //IEnumerable<ContactDetail> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);

        //IEnumerable<ContactDetail> GetAllByCategoryPaging(int categoryId, int page, int pageSize, out int totalRow);
    }

    public class ContactDetailService : IContactDetailService
    {
        private IContactDetailRepository _contactDetailRepository;
        private IUnitOfWork _unitOfWork;

        public ContactDetailService(IContactDetailRepository contactDetailRepository, IUnitOfWork unitOfWork)
        {
            this._contactDetailRepository = contactDetailRepository;
            this._unitOfWork = unitOfWork;
        }

        public ContactDetail GetDefaultContact()
        {
            return _contactDetailRepository.GetSingleByCondition(x => x.Status == true);
        }
    }
}