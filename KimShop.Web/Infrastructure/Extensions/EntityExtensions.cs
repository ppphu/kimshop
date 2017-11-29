using KimShop.Model.Models;
using KimShop.Web.Models;

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
            product.Price = productVm.Price;
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

            product.CreatedDate = productVm.CreatedDate;
            product.CreatedBy = productVm.CreatedBy;
            product.UpdatedDate = productVm.UpdatedDate;
            product.UpdatedBy = productVm.UpdatedBy;
            product.MetaKeyword = productVm.MetaKeyword;
            product.MetaDescription = productVm.MetaDescription;
            product.Status = productVm.Status;
        }
    }
}