using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Task.API.ViewModel;
using Task.Domain;
using Task.Service;
using Task.UI.ViewModel;

namespace Task.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
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


        public UserController(ILogger<UserController> logger, IUserService userService, IUserAdressService userAdressService)
        {
            _logger = logger;
            _userService = userService;
            _userAdressService = userAdressService;
        }
        [HttpGet]
        public IActionResult GetAll()

        {
            List<UserShowViewModel> model = new List<UserShowViewModel>();
            var users = _userService.GetUsers().ToList();
            users.ForEach(u =>
            {
                Adress Adress = _userAdressService.GetUserProfile(u.Id);
                UserShowViewModel user = new UserShowViewModel
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
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
            return Ok(model);
        }
        public async Task<IActionResult> CreatePost([FromBody] UserViewModel model)
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
                    return Ok();
                }
            }
           
            return NotFound();
        }
    }
}
