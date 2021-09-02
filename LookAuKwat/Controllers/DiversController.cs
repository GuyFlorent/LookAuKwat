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
    public class DiversController : Controller
    {
        private IDal dal;
        public DiversController() : this(new Dal())
        {

        }

        public DiversController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        // GET: Divers
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 3600, VaryByParam = "id")]
        public async Task<ActionResult> DiversDetail(int id)
        {
            DiversModel model =  await dal.GetListDiversWithNoInclude().FirstOrDefaultAsync(e => e.id == id);
            model.Coordinate.Lat = model.Coordinate.Lat.Replace(",", ".");
            model.Coordinate.Lon = model.Coordinate.Lon.Replace(",", ".");
            model.ViewNumber++;
            dal.UpdateNumberView(model);

            return View(model);
        }
    }
}