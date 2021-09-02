using LookAuKwat.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LookAuKwat.Controllers
{
    public class EventController : Controller
    {
        private IDal dal;
        public EventController() : this(new Dal())
        {

        }

        public EventController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        // GET: Event
        public ActionResult Index()
        {
            return View();
        }

      //  [OutputCache(Duration = 3600, VaryByParam = "id")]
        public async Task<ActionResult> EventDetail(int id)
        {
            EventModel model = await dal.GetListEventWithNoInclude().FirstOrDefaultAsync(e => e.id == id);
            model.Coordinate.Lat = model.Coordinate.Lat.Replace(",", ".");
            model.Coordinate.Lon = model.Coordinate.Lon.Replace(",", ".");
            model.ViewNumber++;
            dal.UpdateNumberView(model);

            return View(model);
        }
    }
}