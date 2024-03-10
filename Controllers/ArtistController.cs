/*using LoopAudioDigital.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using LoopAudioDigital.Entity;
using System.Security.Policy;
using System.IO;
using LoopAudioDigital.Models;

namespace LoopAudioDigital.Controllers
{
    public class ArtistController : Controller
    {
        private IArtistService _artistService;
        private IWebHostEnvironment _hostingEnvironment;
        public ArtistController(IArtistService artistService, IWebHostEnvironment hostingEnvironment)
        {
            _artistService = artistService;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var model = _artistService.GetAll().Select(artist => new ARTISTIndexViewModel
            {
                Id = artist.artistid,
                ArtistName = artist.artistname,
                ImageUrl = artist.artistimgURL,
                DateParticipate = artist.date_participate,
                Email = artist.email
            }).ToList();

            return View(model);
        }
        //Create
        [HttpGet]
        public IActionResult Create()
        {

            var model = new ARTISTCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ARTISTCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var artist = new Artists
                {
                    artistid = model.Id,
                    artistname = model.ArtistName,
                    email = model.Email,
                    password = model.Password,
                    date_participate = model.DateParticipate,
                    description = model.Description,
                };
                if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var uploadDir = @"artists/images";
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                    var extension = Path.GetExtension(model.ImageUrl.FileName);
                    var webrootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
                    var path = Path.Combine(webrootPath, uploadDir, fileName);
                    await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    artist.artistimgURL = "/" + uploadDir + "/" + fileName;
                };
                await _artistService.UpdateAsSync(artist);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    //Edit
    [HttpGet]
        public IActionResult Edit(int id)
        {
            var artist = _artistService.GetById(id);
            if (artist == null)
            {
                return NotFound();
            }
            var model = new ARTISTEditViewModel
            {
                Id = artist.artistid,
                ArtistName = artist.artistname,
                ImageUrl = artist.artistimgURL,
                Email = artist.email,
                Password = artist.password,
                DateParticipate = artist.date_participate,
                Description = artist.description,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ARTISTEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var artist = _artistService.GetById(model.Id);

                artist.artistid = model.Id;
                artist.artistname = model.ArtistName;
                artist.email = model.Email;
                artist.password = model.Password;
                artist.date_participate = model.DateParticipate;
                artist.description = model.Description;
                if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var uploadDir = @"images/songs";
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl);
                    var extension = Path.GetExtension(model.ImageUrl);
                    var webrootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
                    var path = Path.Combine(webrootPath, uploadDir, fileName);
                    using (var source = ToStream(model.ImageUrl)) { await source.CopyToAsync(new FileStream(path, FileMode.Create)); }

                    artist.artistimgURL = "/" + uploadDir + "/" + fileName;
                };
                await _artistService.UpdateAsSync(artist);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var artist = _artistService.GetById(id);
            if (artist == null)
            {
                return NotFound();
            }
            var model = new ARTISTDetailViewModel
            {
                Id = artist.artistid,
                ArtistName = artist.artistname,
                ImageUrl = artist.artistimgURL,
                DateParticipate = artist.date_participate,
                Email = artist.email,
                Password = artist.password,
                //PaymentMethod = artist.PaymentMethod,
                Description = artist.description
            };
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var artist = _artistService.GetById(id);
            if (artist == null)
            {
                return NotFound();
            }
            var model = new ARTISTDeleteViewModel
            {
                Id = artist.artistid,
                ArtistName = artist.artistname,
                Email = artist.email,
                Password = artist.password,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ARTISTDeleteViewModel model)
        {
            var artist = _artistService.GetById(model.Id);
            if (artist == null)
            {
                return NotFound();
            }
            _artistService.DeleteById(model.Id);

            return RedirectToAction("Index");
        }
        public static Stream ToStream(string str)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}*/
