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

        //this action for entry user
        public IActionResult Entry(string txt)
        {
            var code = Convert.ToInt32(txt);
            Traffic traffic1 = new Traffic();
            if (code == 0)
            {
                return NotFound();
            }
            foreach(WebApp_Traffic.Models.User u in _db.Users.ToList())
            {
                
                if (u.Id == code)
                {
                    foreach(WebApp_Traffic.Models.Traffic traffic in _db.Traffics.ToList())
                    {
                        if(traffic.user == u)
                        {                            
                            traffic1.user = u;
                            traffic1.Type_Traffic = 1;
                            traffic1.EntryOrOut_Time=DateTime.Now;
                            _db.Traffics.Add(traffic1);
                            _db.SaveChanges();
                            
                            break;
                        }
                        else
                        {                          
                            traffic1.user = u;
                            traffic1.Type_Traffic = 1;
                            traffic1.EntryOrOut_Time = DateTime.Now;
                            _db.Traffics.Add(traffic1);
                            _db.SaveChanges();

                            break;
                        }
                    }
                    break;
                }
                else
                {
                    ViewData["Message_2"] = "!کاربر ثبت نام نکرده است یا ایدی اشتباه است";
                    break;
                }
            }

            return View(traffic1);
        }
    }
}
