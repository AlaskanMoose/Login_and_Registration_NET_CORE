using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using login_registration.Models;
using login_registration.Factories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;


namespace login_registration.Controllers
{
    public class UsersController : Controller
    {
        private readonly UsersFactory _usersFactory;
        public UsersController(UsersFactory userFactory){
            _usersFactory = userFactory;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            return View("Index");
        }
        [HttpGet]
        [Route("dash")]
        public IActionResult Dash(){
            return View("Dash");
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(User model){
            if(ModelState.IsValid){
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                model.Password = Hasher.HashPassword(model, model.Password);
                _usersFactory.Add(model);
                var CurrentUser = _usersFactory.GetLatestUser();
                return RedirectToAction("Dash");

            }
            ViewBag.Errors = ModelState.Values;
            return View("Index");
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(){
            return RedirectToAction("Dash");
        }
    }
}
