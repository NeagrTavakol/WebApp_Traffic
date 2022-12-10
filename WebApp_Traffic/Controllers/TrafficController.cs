using Microsoft.AspNetCore.Mvc;
using WebApp_Traffic.Data;
using WebApp_Traffic.Models;

namespace WebApp_Traffic.Controllers
{
    public class TrafficController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TrafficController(ApplicationDbContext db)
        {
            _db = db;
        }

        //this action for show to List Of Traffic
        public IActionResult Index()
        {
            IEnumerable<Traffic> TrafficList = _db.Traffics;
            return View(TrafficList);
        }

        //filter of Traffic User
        public IActionResult Filter(string txt)
        {
            var txt_int = Convert.ToInt32(txt);
            Traffic traffic = new Traffic();
            traffic.user = _db.Users.Find(txt_int);
            IEnumerable<Traffic> TrafficList = _db.Traffics;
            //Traffic F_Traffic = new Traffic();
            foreach (var i in TrafficList)
            {
                if (i.user == traffic.user)
                {
                    traffic.userid = txt_int;
                    traffic.Type_Traffic = i.Type_Traffic;
                    traffic.EntryOrOut_Time = i.EntryOrOut_Time;
                    break;
                }
            }
                return View(traffic);
            }

        //Get
        //this action for Edit detail of traffic-user
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var TrafficFromDb = _db.Traffics.Find(id);

            if (TrafficFromDb == null)
            {
                return NotFound();
            }

            return View(TrafficFromDb);
        }

        //Post
        // this action for record editing
        [HttpPost]
        public IActionResult Edit(Traffic obj)
        {
            Traffic traffic = obj;
            traffic.user = _db.Users.Find(obj.userid);
            _db.Traffics.Update(traffic);
            _db.SaveChanges();
            TempData["Success"] = "تردد مورد نظر با موفقیت ویرایش شد";

            return RedirectToAction("Index");
        }

        //Get
        // this action for delete selected record 
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var TrafficFromDb = _db.Traffics.Find(id);
            if (TrafficFromDb == null)
            {
                return NotFound();
            }

            return View(TrafficFromDb);
        }

        //post
        // this action for delete selected record
        [HttpPost]
        public IActionResult DeletePost(Traffic obj)
        {
            Traffic traffic = obj;
            traffic.user = _db.Users.Find(obj.userid);
            _db.Traffics.Remove(traffic);
            _db.SaveChanges();
            TempData["Success"] = "تردد مورد نظر با موفقیت حذف شد";
            return RedirectToAction("Index");
        }

        //this action for entry user
        public IActionResult Entry(string txt)
        {
            var code = Convert.ToInt32(txt);
            Traffic traffic1 = new Traffic();
            IEnumerable<Traffic> TrafficList = _db.Traffics;
            if (code == 0)
            {
                return NotFound();
            }
            traffic1.user = _db.Users.Find(code);
            if(traffic1.user == null)
            {
                return NotFound();
            }
            else
            {
                traffic1.EntryOrOut_Time = DateTime.Now;
                traffic1.userid = code;
            }
            /*foreach (WebApp_Traffic.Models.User u in _db.Users.ToList())
            {
                if (u.Id == code)
                {
                    traffic1.userid = u.Id;
                    traffic1.user = _db.Users.Find(u.Id);
                    traffic1.EntryOrOut_Time = DateTime.Now;
                    break;
                }

                else
                {
                    ViewData["Message_2"] = "!کاربر ثبت نام نکرده است یا ایدی اشتباه است";
                    break;
                }
            }*/
            foreach(var i in TrafficList)
            {
                if(i.userid==traffic1.userid)
                {
                    traffic1.Type_Traffic = 1;
                    break;
                }
                
            }

            _db.Traffics.Add(traffic1);
            _db.SaveChanges();

            return View(traffic1);
        }
    }
}
