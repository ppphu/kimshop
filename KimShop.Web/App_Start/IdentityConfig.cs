﻿using KimShop.Data;
using KimShop.Model.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KimShop.Web.App_Start
{
    public class AppUserStore : UserStore<AppUser>
    {
        public AppUserStore(KimShopDbContext context)
            : base(context)
        {
        }
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store)
            : base(store)
        {
        }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            var manager = new AppUserManager(new UserStore<AppUser>(context.Get<KimShopDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<AppUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<AppUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class AppSignInManager : SignInManager<AppUser, string>
    {
        public AppSignInManager(AppUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(AppUser user)
        {
            return user.GenerateUserIdentityAsync((AppUserManager)UserManager);
        }

        public static AppSignInManager Create(IdentityFactoryOptions<AppSignInManager> options, IOwinContext context)
        {
            return new AppSignInManager(context.GetUserManager<AppUserManager>(), context.Authentication);
        }
    }
}