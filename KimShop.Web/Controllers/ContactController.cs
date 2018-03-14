using AutoMapper;
using BotDetect.Web.Mvc;
using KimShop.Common;
using KimShop.Model.Models;
using KimShop.Service;
using KimShop.Web.Infrastructure.Extensions;
using KimShop.Web.Models;
using System.Web.Mvc;

namespace KimShop.Web.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        private IFeedbackService _feedbackService;

        private IContactDetailService _contactDetailService;

        public ContactController(IContactDetailService contactDetailService, IFeedbackService feedbackService)
        {
            this._feedbackService = feedbackService;
            this._contactDetailService = contactDetailService;
        }

        public ActionResult Index()
        {
            FeedbackViewModel viewModel = new FeedbackViewModel();
            viewModel.ContactDetail = GetDetail();
            return View(viewModel);
        }

        [HttpPost]
        [CaptchaValidation("CaptchaCode", "contactCaptcha", "Mã xác nhận không đúng!")]
        public ActionResult SendFeedback(FeedbackViewModel feedbackVm)
        {
            if (ModelState.IsValid)
            {
                Feedback feedback = new Feedback();
                feedback.UpdateFeedback(feedbackVm);
                this._feedbackService.Create(feedback);
                this._feedbackService.Save();

                ViewData["SuccessMsg"] = "Gửi phản hồi thành công";

                string content = System.IO.File.ReadAllText(Server.MapPath("/Assets/client/template/contact_template.html"));
                content = content.Replace("{{Name}}", feedbackVm.Name);
                content = content.Replace("{{Email}}", feedbackVm.Email);
                content = content.Replace("{{Message}}", feedbackVm.Message);

                // Chưa gửi mail cho admin mail được
                var adminEmail = ConfigHelper.GetByKey("AdminEmail");
                MailHelper.SendMail(adminEmail, "Thông tin liên hệ từ website", content);

                feedbackVm.Name = "";
                feedbackVm.Email = "";
                feedbackVm.Message = "";
            }
            feedbackVm.ContactDetail = GetDetail();
            return View("Index", feedbackVm);
        }

        private ContactDetailViewModel GetDetail()
        {
            var model = _contactDetailService.GetDefaultContact();
            var contactViewModel = Mapper.Map<ContactDetail, ContactDetailViewModel>(model);
            return contactViewModel;
        }
    }
}