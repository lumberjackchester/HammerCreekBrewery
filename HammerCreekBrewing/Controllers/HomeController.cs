using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HammerCreekBrewing.Services;
using HammerCreekBrewing.Data.ViewModels;
using HammerCreekBrewing.Data.Models;
using System.Linq.Expressions;
using AutoMapper;
using System.Threading.Tasks;

namespace HammerCreekBrewing.Controllers
{
    public class HomeController : Controller
    { 
        
        //
        // GET: /Home/
        public HomeController()
        { 
        }

        public ActionResult Index()
        { 

            return View();
        }

    }
}
