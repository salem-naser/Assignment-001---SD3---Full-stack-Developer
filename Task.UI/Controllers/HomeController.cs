using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Task.Domain;
using Task.Service;
using Task.UI.Models;
using Task.UI.ViewModel;
using Task.Domain;

namespace Task.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly IUserAdressService _userAdressService;


        List<City> citiesList = new List<City>()
        {
            new City(){Id = 1,Name = "Cairo"},
            new City(){Id = 2,Name = "Alex"},
            new City(){Id = 3,Name = "Mansoura"},
            new City(){Id = 4,Name = "Giza"},
        };
        List<City> RegionssList = new List<City>()
        {
            new City(){Id = 1,Name = "Abbas"},
            new City(){Id = 2,Name = "Makram"},
            new City(){Id = 3,Name = "Doki"},
            new City(){Id = 4,Name = "Giza"},
        };
       

        public HomeController(ILogger<HomeController> logger, IUserService userService, IUserAdressService userAdressService)
        {
            _logger = logger;
            _userService = userService;
            _userAdressService = userAdressService;
        }

        public IActionResult Index()
        
        {
            List<UserShowViewModel> model = new List<UserShowViewModel>();
            var users = _userService.GetUsers().ToList();
            users.ForEach(u =>
            {
                Adress Adress  = _userAdressService.GetUserProfile(u.Id);
                UserShowViewModel user = new UserShowViewModel
                {
                    Id = u.Id,
                    FirstName= u.FirstName,
                    LastName = u.LasTName,
                    MiddleName = u.MiddleName,
                    Email = u.Email,
                    BirthDate = u.BirthDate,
                    MobileNumber = u.MoblieNumber,
                    City = RegionssList.FirstOrDefault(x => x.Id == Adress.City).Name,
                    FlatNumber = Adress.FlatNumber,
                    Governrate = citiesList.FirstOrDefault(x => x.Id == Adress.City).Name,
                    Street = Adress.Street,
                    BulDingNumber = Adress.BuildingNumber,
                   
                };
                model.Add(user);
            });

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public ActionResult AddUser()
        {
            ViewBag.Cityies = new SelectList(citiesList, "Id", "Name", "Cairo");
            ViewBag.RegionssList = new SelectList(RegionssList, "Id", "Name", "Abbas");

            return View();
        }
        [HttpPost]
        public ActionResult AddUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User userEntity = new User
                {
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LasTName = model.LastName,
                    Email = model.Email,
                    BirthDate = model.BirthDate,
                    MoblieNumber = model.MobileNumber,

                    Adress = new Adress()
                    {
                        City = model.City,
                        Street = model.Street,
                        FlatNumber = model.FlatNumber,
                        BuildingNumber = model.BulDingNumber,
                        Id = model.Id,
                        Governrate = model.Governrate,
                    }
                };
                _userService.InsertUser(userEntity);
                if (userEntity.Id > 0)
                {
                    return RedirectToAction("index");
                }
            }
            ViewBag.Cityies = new SelectList(citiesList, "Id", "Name", "Cairo");
            ViewBag.RegionssList = new SelectList(RegionssList, "Id", "Name", "Abbas");
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet]
        public IActionResult DeleteUser(int id)
        {
            if (id == null)
            {
                return Error();
            }

            var User = _userService.GetUser(id);
            if (User==null)
            {
                return Error();
               
            }
            _userService.DeleteUser(id);
            return RedirectToAction("Index");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

      
    }
}
