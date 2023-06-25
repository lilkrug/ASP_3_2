using Phonebook.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phonebook.Controllers
{
    public class DictController : Controller
    {
        readonly IRepository<HandbookRecord> _handbookRecordRepository;
        // GET: Dict
        public DictController(IRepository<HandbookRecord> repository)
        {
            _handbookRecordRepository = repository;
        }
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.getall = _handbookRecordRepository.GetRecords();
            return View();
        }
        [HttpGet]
        public ActionResult Add() // для получения view
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSave(HandbookRecord handbookRecord)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _handbookRecordRepository.Create(handbookRecord);
                    _handbookRecordRepository.Save();
                    return Redirect("~/Dict/Index");
                }
                catch (Exception ex)
                {
                    ViewBag.SqlException = ex.Message;
                    return View("Add", handbookRecord);
                }
            }
            return View("Add", handbookRecord);
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var handbookRecord = _handbookRecordRepository.GetRecord(id);
            if (handbookRecord != null)
            {
                return View(handbookRecord);
            }
            else
            {
                return Redirect("~/Dict/Index");
            }
        }
        [HttpPost]
        public ActionResult UpdateSave(HandbookRecord handbookRecord)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _handbookRecordRepository.Update(handbookRecord);
                    _handbookRecordRepository.Save();
                    return Redirect("~/Dict/Index");
                }
                catch (Exception ex)
                {
                    ViewBag.SqlException = ex.Message;
                    return View("Update", handbookRecord);
                }
            }
            return View("Update", handbookRecord);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var handbookRecord = _handbookRecordRepository.GetRecord(id);
            if (handbookRecord != null)
            {
                ViewBag.Id = handbookRecord.Id;
                return View();
            }
            else
            {
                return Redirect("~/Dict/Index");
            }
        }
        [HttpPost]
        public ActionResult DeleteSave(int id)
        {
            _handbookRecordRepository.Delete(id);
            _handbookRecordRepository.Save();
            return Redirect("~/Dict/Index");
        }
    }
}