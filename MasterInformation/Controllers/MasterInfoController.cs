using MasterInformation.DAL;
using MasterInformation.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterInformation.Controllers
{
    public class MasterInfoController : Controller
    {
        DataAccessLayer DAL = new DataAccessLayer();    
        // GET: MasterInfo
        public ActionResult Index()
        {
            List<tblUserDetail> list = new List<tblUserDetail>();
            list = DAL.GetAllData().ToList();
            return View(list);
        }

        // GET: MasterInfo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterInfo/Create
        public ActionResult Create()
        {
            ViewBag.CountryList = DAL.GetAllCountry();
            ViewBag.StateList = DAL.GetAllState();
            ViewBag.CityList = DAL.GetAllCity();
            return View();
        }

        // POST: MasterInfo/Create
        [HttpPost]
        public ActionResult Create(tblUserDetail userDetail,HttpPostedFileBase Image)
        {
            if(Image == null)
            {
                userDetail.Image = "~/Images/Default.jpg";
            }
            else
            {
                string fileName = Path.GetFileName(Image.FileName);
                string ImagePath = Path.Combine(Server.MapPath("~/Images/"), fileName);
                Image.SaveAs(ImagePath);
                userDetail.Image = "~/Images/" + fileName;
            }
            DAL.InsertData(userDetail);
            return RedirectToAction("Index");
        }

        // GET: MasterInfo/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CountryList = DAL.GetAllCountry();
            ViewBag.StateList = DAL.GetAllState();
            ViewBag.CityList = DAL.GetAllCity();
            tblUserDetail userDetail = DAL.GetDataById(id);

            if (userDetail == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // POST: MasterInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(tblUserDetail userDetail)
        {

                // TODO: Add update logic here
                DAL.UpdateData(userDetail);
                return RedirectToAction("Index");
 
        }

        // GET: MasterInfo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterInfo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
