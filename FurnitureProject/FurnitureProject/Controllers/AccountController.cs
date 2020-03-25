using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FurnitureProject.Data;
using FurnitureProject.Data.Entities;
using FurnitureProject.Infarstructure.Extensions;
using FurnitureProject.Infrastructure.Attributes;
using FurnitureProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInNS = Microsoft.AspNetCore.Identity;


namespace FurnitureProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly FurnitureDbContext context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IPasswordValidator<AppUser> _password;
        public AccountController(FurnitureDbContext _context
                                   , UserManager<AppUser> userManager
                                     , IMapper mapper
                                        , SignInManager<AppUser> signInManager
                                            , IPasswordValidator<AppUser> password)
        {
            context= _context;
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _password = password;
        }

        [HttpGet]
        [ImportModelState]
        public IActionResult Regiter()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ExportModelState]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {

            //ilk once bele bir emailli adam varmi deye yoxlamaq lazimdir
            AppUser appUser = await _userManager.FindByEmailAsync(registerModel.Email);
            if (appUser != null)
            {
                ModelState.AddModelError("", "Given email aready exists.Please use another one!!");
                return this.RedirectToSameAction();
            }
            else
            {
                var newAppUser = _mapper.Map<AppUser>(registerModel);
                var identityResult = await _userManager.CreateAsync(newAppUser, registerModel.Password);

                if (identityResult.Succeeded)
                {
                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    foreach (var item in identityResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return this.RedirectToSameAction();
                }
            }
        }

        [HttpGet]
        [ImportModelState]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ExportModelState]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                AppUser currentUser = await _userManager.FindByEmailAsync(loginModel.Email);
                var checkPass = _password.ValidateAsync(_userManager, currentUser, loginModel.Password);
                if (currentUser != null && checkPass.Result.Succeeded)
                {
                    SignInNS.SignInResult sgManager = await _signInManager.PasswordSignInAsync(currentUser, loginModel.Password, true, false);

                    if (sgManager.Succeeded)
                    {
                        return RedirectToAction("Index", "DashBoard", new { Area = "Admin" });
                    }
                    else
                    {
                        ModelState.AddModelError("", "sign in failed!!");
                        return this.RedirectToSameAction();
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Email or Password is not correct");
                    return this.RedirectToSameAction();
                }
            }
            else
            {
                return this.RedirectToSameAction();
            }
        }

    }
}