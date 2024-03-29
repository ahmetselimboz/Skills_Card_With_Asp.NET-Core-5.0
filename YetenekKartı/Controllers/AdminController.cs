﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using YetenekKart.Models.Siniflar;

namespace YetenekKart.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        public ActionResult Index()
        {
            
            var degerler = c.Yeteneklers.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(Yetenekler y)
        {
            c.Yeteneklers.Add(y);
            c.SaveChanges();
            return View();
        }
        public ActionResult YetenekSil(int id)
        {
            var deger = c.Yeteneklers.Find(id);
            c.Yeteneklers.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekGetir(int id)
        {
            var deger = c.Yeteneklers.Find(id);
            
            return View("YetenekGetir", deger);
        }
        [HttpPost]
        public ActionResult YetenekGetir(Yetenekler y)
        {
            var x = c.Yeteneklers.Find(y.ID);
            x.Aciklama = y.Aciklama;
            x.Deger = y.Deger;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}