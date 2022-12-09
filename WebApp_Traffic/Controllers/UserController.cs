using Microsoft.AspNetCore.Mvc;
using WebApp_Traffic.Data;
using WebApp_Traffic.Models;
/*using IronBarCode;*/
using System.Diagnostics;
using Aspose.BarCode.Generation;
using Aspose.BarCode.BarCodeRecognition;


namespace WebApp_Traffic.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        //this action for show to List Of User
        public IActionResult Index()
        {
            IEnumerable<User> UserList = _db.Users;
            return View(UserList);
        }

        //Get
        //this action for make the form for user
        public IActionResult Create()
        {
            return View();
        }


        //Post
        //this Action for make the unique code & Save in Db
        [HttpPost]
        public IActionResult Create(User obj)
        {
            _db.Users.Add(obj);
            _db.SaveChanges();
            //// نمونه ای از کلاس BarcodeGenerator را راه اندازی کنید
            //BarcodeGenerator gen = new BarcodeGenerator(EncodeTypes.Code39Standard, obj.Id.ToString());

            //// اندازه را بر حسب پیکسل تنظیم کنید
            //gen.Parameters.Barcode.XDimension.Pixels = 2;

            //// ذخیره خروجی EAN 13 بارکد
            //gen.Save(obj.Id.ToString() + ".png", BarCodeImageFormat.Png);
//////////////////////////////////////////////////////////////////////////////////////////
            /*using (BarCodeReader reader = new BarCodeReader(obj.Id.ToString() + ".png", DecodeType.Code39Standard))
            {
                foreach (BarCodeResult result in reader.ReadBarCodes())
                {
                    // نمایش متن کد و نوع نماد
                    Console.WriteLine("CodeText: " + result.CodeText);
                    Console.Write("Symbology Type: " + result.CodeType);
                    Console.Write("Symbology Type: " + result.ToString());

                }
            }*/


            TempData["Success"] = "کاربر جدید با موفقیت اضافه شد";

            return RedirectToAction("Index");
        }

        //Get
        //this action for Edit detail of user
        public IActionResult EditUser(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var UserFromDb = _db.Users.Find(id);

            if (UserFromDb == null)
            {
                return NotFound();
            }

            return View(UserFromDb);
        }

        //Post
        // this action for record editing
        [HttpPost]
        public IActionResult EditUser(User obj)
        {

            _db.Users.Update(obj);
            _db.SaveChanges();
            TempData["Success"] = "کاربر مورد نظر با موفقیت ویرایش شد";

            return RedirectToAction("Index");
        }

        //Get
        //this action for delete user
        public IActionResult DeleteUser(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var UserFromDb = _db.Users.Find(id);

            if (UserFromDb == null)
            {
                return NotFound();
            }

            return View(UserFromDb);
        }

        //Post
        //this action for remove user from Db
        [HttpPost]
        public IActionResult DeleteUserPost(int? id)
        {
            var obj = _db.Users.Find(id);
            _db.Users.Remove(obj);
            _db.SaveChanges();
            TempData["Success"] = "کاربر مورد نظر با موفقیت حذف شد";
            return RedirectToAction("Index");
        }

    }
}
