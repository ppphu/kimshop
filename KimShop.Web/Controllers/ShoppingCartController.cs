using AutoMapper;
using KimShop.Model.Models;
using KimShop.Service;
using KimShop.Web.App_Start;
using KimShop.Web.Infrastructure.Extensions;
using KimShop.Web.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace KimShop.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private IOrderService _orderService;
        private IProductService _productService;
        private AppUserManager _userManager;

        public ShoppingCartController(IProductService productService, IOrderService orderService, AppUserManager userManager)
        {
            this._userManager = userManager;
            this._orderService = orderService;
            this._productService = productService;
        }

        // GET: ShoppingCart
        public ActionResult Index()
        {
            if (Session[Common.Constants.SessionCart] == null)
                Session[Common.Constants.SessionCart] = new List<ShoppingCartViewModel>();
            return View();
        }

        public ActionResult Checkout()
        {
            if (Session[Common.Constants.SessionCart] == null)
            {
                return Redirect("/gio-hang.html");
            }
            return View();
        }

        public JsonResult GetAllCart()
        {
            if (Session[Common.Constants.SessionCart] == null)
                Session[Common.Constants.SessionCart] = new List<ShoppingCartViewModel>();
            var cart = (List<ShoppingCartViewModel>)Session[Common.Constants.SessionCart];
            return Json(new
            {
                data = cart,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetUser()
        {
            if (Request.IsAuthenticated)
            {
                var user = _userManager.FindById(User.Identity.GetUserId());
                return Json(new
                {
                    data = user,
                    status = true
                });
            }
            return Json(new
            {
                status = false
            });
        }

        [HttpPost]
        public JsonResult CreateOrder(string orderViewModel)
        {
            var orderVm = new JavaScriptSerializer().Deserialize<OrderViewModel>(orderViewModel);
            var order = new Order();
            order.UpdateOrder(orderVm);
            if (Request.IsAuthenticated)
            {
                order.CustomerId = User.Identity.GetUserId();
                order.CreatedBy = User.Identity.GetUserName();
            }

            var cart = (List<ShoppingCartViewModel>)Session[Common.Constants.SessionCart];
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (var item in cart)
            {
                var detail = new OrderDetail();
                detail.ProductID = item.ProductId;
                detail.Quantity = item.Quantity;
                orderDetails.Add(detail);
            }
            _orderService.Create(ref order, orderDetails);
            return Json(new
            {
                status = true
            });
        }

        [HttpPost]
        public JsonResult Add(int productId)
        {
            var cart = (List<ShoppingCartViewModel>)Session[Common.Constants.SessionCart];
            if (cart == null)
            {
                cart = new List<ShoppingCartViewModel>();
            }
            if (cart.Any(x => x.ProductId == productId))
            {
                foreach (var item in cart)
                {
                    if (item.ProductId == productId)
                    {
                        item.Quantity += 1;
                    }
                }
            }
            else
            {
                ShoppingCartViewModel newItem = new ShoppingCartViewModel();
                newItem.ProductId = productId;
                var product = _productService.GetById(productId);
                newItem.Product = Mapper.Map<Product, ProductViewModel>(product);
                newItem.Quantity = 1;
                cart.Add(newItem);
            }
            Session[Common.Constants.SessionCart] = cart;

            return Json(new { status = true });
        }

        [HttpPost]
        public JsonResult Update(string cartData)
        {
            var cartViewModel = new JavaScriptSerializer().Deserialize<List<ShoppingCartViewModel>>(cartData);
            var cartSession = (List<ShoppingCartViewModel>)Session[Common.Constants.SessionCart];
            foreach (var item in cartSession)
            {
                foreach (var jItem in cartViewModel)
                {
                    if (item.ProductId == jItem.ProductId)
                    {
                        item.Quantity = jItem.Quantity;
                    }
                }
            }
            Session[Common.Constants.SessionCart] = cartSession;
            return Json(new
            {
                status = true
            });
        }

        [HttpPost]
        public JsonResult DeleteItem(int productId)
        {
            var cartSession = (List<ShoppingCartViewModel>)Session[Common.Constants.SessionCart];
            if (cartSession != null)
            {
                cartSession.RemoveAll(x => x.ProductId == productId);
                Session[Common.Constants.SessionCart] = cartSession;
                return Json(new
                {
                    status = true
                });
            }
            return Json(new
            {
                status = false
            });
        }

        [HttpPost]
        public JsonResult DeleteAllCart()
        {
            Session[Common.Constants.SessionCart] = new List<ShoppingCartViewModel>();
            return Json(new
            {
                status = true
            });
        }
    }
}