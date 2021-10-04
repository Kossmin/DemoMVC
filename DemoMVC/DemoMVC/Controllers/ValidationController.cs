using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace DemoMVC.Controllers
{
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class ValidationController : Controller
    {
        MovieDBContext _repository;
//#if  InMemDB
//          public ValidationController() : this(InMemoryDB.Instance) { }
//#else
        public ValidationController() : this(new MovieDBContext()) { }
        //#endif


        public ValidationController(MovieDBContext repository)
        {
            _repository = repository;
        }

        public JsonResult IsUID_Available(string Title)
        {

            var movies = _repository.Movies.SingleOrDefault(m => m.Title ==Title);

            if (movies == null)
                return Json(true, JsonRequestBehavior.AllowGet);

            string suggestedUID = String.Format(CultureInfo.InvariantCulture,
                "{0} is not available.", Title);

            for (int i = 1; i < 100; i++)
            {
                string altCandidate = Title + i.ToString();
                var movies2 = _repository.Movies.SingleOrDefault(m => m.Title == altCandidate);
                if (movies2 == null)
                {
                    suggestedUID = String.Format(CultureInfo.InvariantCulture,
                   "{0} is not available. Try {1}.", Title, altCandidate);
                    break;
                }
            }
            return Json(suggestedUID, JsonRequestBehavior.AllowGet);
        }

    }
}