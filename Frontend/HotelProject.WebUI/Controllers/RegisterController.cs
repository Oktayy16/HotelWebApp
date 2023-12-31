﻿using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.DTOs.RegisterDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateNewUserDto createNewUserDto)
        {
            if (!ModelState.IsValid) // tuşa basıldığında gerekli model uygun değilse direk dönecek(böylece gerekli verisiz ilerlese patlaması engellenir)
            {
                return View();
            }
            var appUser = new AppUser()
            {
                Name = createNewUserDto.Name,
                Email = createNewUserDto.Mail,
                SureName = createNewUserDto.SurnameName,
                UserName = createNewUserDto.UserName
            };
            var result = await _userManager.CreateAsync(appUser,createNewUserDto.Password);
            if(result.Succeeded)
            {
                return RedirectToAction("Index","Login"); // Eğer geçerliyse Login içerisindeki Index'e yönlendir
            }
            return View();
        }
    }
}
