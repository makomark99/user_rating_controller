using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SentimentBusinessLogic.Managers;
using SentimentCore.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SentimentMVCPrezentation.Controllers
{
    public class SentenceController : Controller
    {
        #region laz loaded objects

        private SentenceManager _sentenceManager;
        private SentenceManager SentenceManager()
        {
            if (_sentenceManager == null)
            {
                _sentenceManager = SDI.Resolve<SentenceManager>();  
            }
            return _sentenceManager;
        }

        #endregion
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SaveNewSentence(string text)
        {
            try
            {
                SentenceManager().SaveNewSentence(text);
            }
            catch (System.Exception)
            {
                return Json(new { IsSuccess = false });
            }
            return Json(new { IsSuccess = true });

        }

        [HttpPost]
        public RedirectToActionResult UploadFile(IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    var sentences = new List<string>();
                    var _FileName = Path.GetFileName(file.FileName);
                    using (var reader = new StreamReader(file.OpenReadStream()))
                    {
                        while (reader.Peek() >= 0)
                            sentences.Add(reader.ReadLine());
                    }
                    SentenceManager().SaveNewSentences(sentences);

                }
                //ViewBag.Message = "File Uploaded Successfully!!";
                //return View();
            }
            catch
            {
                //ViewBag.Message = "File upload failed!!";
                ///return View();
            }

            return RedirectToAction("Index");
        }

        public IActionResult ListRatings()
        {
            var model = SentenceManager().GetListRatingsViewModel();
            return View(model);
        }
        public FileContentResult DownloadCsv()
        {
            var result = SentenceManager().GetSentencesCsv();
            new System.Text.UTF8Encoding();
            return File(Encoding.UTF8.GetBytes(result), "text/csv", "SentencesWithRatings" + DateTime.Now.ToString("yyyyMMdd") + ".csv");
            
        }
    }
}
