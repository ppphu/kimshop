using KimShop.Model.Models;
using KimShop.Web.Models;
using System;

namespace KimShop.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryVm)
        {
            postCategory.ID = postCategoryVm.ID;
            postCategory.Name = postCategoryVm.Name;
            postCategory.Alias = postCategoryVm.Alias;
            postCategory.Image = postCategoryVm.Image;
            postCategory.Description = postCategoryVm.Description;
            postCategory.ParentID = postCategoryVm.ParentID;
            postCategory.DisplayOrder = postCategoryVm.DisplayOrder;
            postCategory.HomeFlag = postCategoryVm.HomeFlag;

            postCategory.CreatedDate = postCategoryVm.CreatedDate;
            postCategory.CreatedBy = postCategoryVm.CreatedBy;
            postCategory.UpdatedDate = postCategoryVm.UpdatedDate;
            postCategory.UpdatedBy = postCategoryVm.UpdatedBy;
            postCategory.MetaDescription = postCategoryVm.MetaDescription;
            postCategory.MetaKeyword = postCategoryVm.MetaKeyword;
            postCategory.Status = postCategoryVm.Status;
        }

        public static void UpdatePost(this Post post, PostViewModel postVm)
        {
            post.ID = postVm.ID;
            post.Name = postVm.Name;
            post.Alias = postVm.Alias;
            post.Image = postVm.Image;
            post.Description = postVm.Description;
            post.Content = postVm.Content;
            post.CategoryID = postVm.CategoryID;
            post.HomeFlag = postVm.HomeFlag;
            post.HotFlag = postVm.HotFlag;
            post.ViewCount = postVm.ViewCount;

            post.CreatedDate = postVm.CreatedDate;
            post.CreatedBy = postVm.CreatedBy;
            post.UpdatedDate = postVm.UpdatedDate;
            post.UpdatedBy = postVm.UpdatedBy;
            post.MetaDescription = postVm.MetaDescription;
            post.MetaKeyword = postVm.MetaKeyword;
            post.Status = postVm.Status;
        }

        public static void UpdateProductCategory(this ProductCategory category, ProductCategoryViewModel categoryVm)
        {
            category.ID = categoryVm.ID;
            category.Name = categoryVm.Name;
            category.Alias = categoryVm.Alias;
            category.Image = categoryVm.Image;
            category.Description = categoryVm.Description;
            category.ParentID = categoryVm.ParentID;
            category.DisplayOrder = categoryVm.DisplayOrder;
            category.HomeFlag = categoryVm.HomeFlag;

            category.CreatedDate = categoryVm.CreatedDate;
            category.CreatedBy = categoryVm.CreatedBy;
            category.UpdatedDate = categoryVm.UpdatedDate;
            category.UpdatedBy = categoryVm.UpdatedBy;
            category.MetaDescription = categoryVm.MetaDescription;
            category.MetaKeyword = categoryVm.MetaKeyword;
            category.Status = categoryVm.Status;
        }

        public static void UpdateProduct(this Product product, ProductViewModel productVm)
        {
            product.ID = productVm.ID;
            product.Name = productVm.Name;
            product.Quantity = productVm.Quantity;
            product.Price = productVm.Price;
            product.OriginalPrice = productVm.OriginalPrice;
            product.PromotionPrice = productVm.PromotionPrice;
            product.Warranty = productVm.Warranty;
            product.Alias = productVm.Alias;
            product.Image = productVm.Image;
            product.MoreImages = productVm.MoreImages;
            product.Description = productVm.Description;
            product.Content = productVm.Content;
            product.CategoryID = productVm.CategoryID;
            product.HomeFlag = productVm.HomeFlag;
            product.HotFlag = productVm.HotFlag;
            product.ViewCount = productVm.ViewCount;
            product.Tags = productVm.Tags;

            product.CreatedDate = productVm.CreatedDate;
            product.CreatedBy = productVm.CreatedBy;
            product.UpdatedDate = productVm.UpdatedDate;
            product.UpdatedBy = productVm.UpdatedBy;
            product.MetaKeyword = productVm.MetaKeyword;
            product.MetaDescription = productVm.MetaDescription;
            product.Status = productVm.Status;
        }

        public static void UpdateFeedback(this Feedback feedback, FeedbackViewModel feedbackVm)
        {
            feedback.Name = feedbackVm.Name;
            feedback.Email = feedbackVm.Email;
            feedback.Message = feedbackVm.Message;
            feedback.CreatedDate = DateTime.Now;
            feedback.Status = feedbackVm.Status;
        }

        public static void UpdateOrder(this Order order, OrderViewModel orderVm)
        {
            order.CustomerName = orderVm.CustomerName;
            order.CustomerAddress = orderVm.CustomerAddress;
            order.CustomerMobile = orderVm.CustomerMobile;
            order.CustomerEmail = orderVm.CustomerEmail;
            order.CustomerMessage = orderVm.CustomerMessage;
            order.CreatedDate = DateTime.Now;

            order.Status = orderVm.Status;
            order.CreatedBy = orderVm.CreatedBy;
            order.CustomerId = orderVm.CustomerId;
            order.PaymentMethod = orderVm.PaymentMethod;
            order.PaymentStatus = orderVm.PaymentStatus;
        }

        public static void UpdateAppGroup(this AppGroup appGroup, AppGroupViewModel appGroupViewModel)
        {
            appGroup.ID = appGroupViewModel.ID;
            appGroup.Name = appGroupViewModel.Name;
            appGroup.Description = appGroupViewModel.Description;
        }

        public static void UpdateAppRole(this AppRole appRole, AppRoleViewModel appRoleViewModel, string action = "add")
        {
            if (action == "update")
                appRole.Id = appRoleViewModel.Id;
            else
                appRole.Id = Guid.NewGuid().ToString();
            appRole.Name = appRoleViewModel.Name;
            appRole.Description = appRoleViewModel.Description;
        }

        public static void UpdateUser(this AppUser appUser, AppUserViewModel appUserViewModel, string action = "add")
        {
            appUser.Id = appUserViewModel.Id;
            appUser.FullName = appUserViewModel.FullName;
            appUser.Birthday = appUserViewModel.Birthday;
            appUser.Address = appUserViewModel.Address;
            appUser.Email = appUserViewModel.Email;
            appUser.UserName = appUserViewModel.UserName;
            appUser.PhoneNumber = appUserViewModel.PhoneNumber;
        }
    }
}