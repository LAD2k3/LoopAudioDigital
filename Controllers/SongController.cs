
using LoopAudioDigital.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System.Diagnostics;
using LoopAudioDigital.Entity;
using LoopAudioDigital.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using LoopAudioDigital.DataAccess;
using System.IO;
namespace LoopAudioDigital.Controllers
{
    public class SongController : Controller
    {
        private readonly ISongService _songService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IArtistService _artistService;
        public SongController(ISongService songService, IWebHostEnvironment hostingEnvironment, IArtistService artistService)
        {
            _songService = songService;
            _hostingEnvironment = hostingEnvironment;
            _artistService = artistService;
        }
        [HttpGet]
        public IActionResult IndexSong()
        {
            var model = _songService.GetAll().Select(song => new SONGIndexViewModel
            {
                Id = song.songid,
                SongName = song.songname,
                ArtistName = song.artistname,
                SongUrl = song.songURL,
                ImageUrl = song.imageURL,
                DateUpload = song.date_upload,
                count = song.listen_count
            }).ToList();

            return View(model);
        }
        //Create
        [HttpGet]
        public IActionResult CreateSong()
        {
            var model = new SONGCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSong(SONGCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var song = new Songs
                {
                    songid = model.Id,
                    songname = model.SongName,
                    //artistid = model.ArtistId,
                    //User = model.User,
                    artistname =model.ArtistName,
                    date_upload = model.DateUpload,
                };

                if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var uploadDir = @"songs/images";
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                    var extension = Path.GetExtension(model.ImageUrl.FileName);
                    var webrootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
                    var path = Path.Combine(webrootPath, uploadDir, fileName);
                    await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    song.imageURL = "/" + uploadDir + "/" + fileName;
                }
                if (model.SongUrl != null && model.SongUrl.Length > 0)
                {
                    var uploadDir1 = @"songs/songs";
                    var fileName1 = Path.GetFileNameWithoutExtension(model.SongUrl.FileName);
                    var extension1 = Path.GetExtension(model.SongUrl.FileName);
                    var webrootPath1 = _hostingEnvironment.WebRootPath;
                    fileName1 = DateTime.UtcNow.ToString("yymmssfff") + fileName1 + extension1;
                    var path1 = Path.Combine(webrootPath1, uploadDir1, fileName1);
                    await model.SongUrl.CopyToAsync(new FileStream(path1, FileMode.Create));
                    song.songURL = "/" + uploadDir1 + "/" + fileName1;
                };
                await _songService.CreateAsSync(song);
                return RedirectToAction("IndexSong");
            }
            return View();
        }
        //Edit
        [HttpGet]
        public IActionResult EditSong(int id)
        {
            var song = _songService.GetById(id);
            if (song == null)
            {
                return NotFound();
            }
            var model = new SONGEditViewModel
            {
                Id = song.songid,
                SongName = song.songname,

                DateUpload = song.date_upload
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSong(SONGEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var song = _songService.GetById(model.Id);
                {
                song.songid = model.Id;
                song.songname = model.SongName;
                song.artistname = model.ArtistName;
                song.date_upload = model.DateUpload;
                };
                if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var uploadDir = @"images/songs";
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                    var extension = Path.GetExtension(model.ImageUrl.FileName);
                    var webrootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
                    var path = Path.Combine(webrootPath, uploadDir, fileName);
                    await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));

                    song.imageURL = "/" + uploadDir + "/" + fileName;
                };
                if (model.SongUrl != null && model.SongUrl.Length > 0)
                {
                    var uploadDir = @"songs/songs";
                    var fileName = Path.GetFileNameWithoutExtension(model.SongUrl.FileName);
                    var extension = Path.GetExtension(model.SongUrl.FileName);
                    var webrootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
                    var path = Path.Combine(webrootPath, uploadDir, fileName);
                    await model.SongUrl.CopyToAsync(new FileStream(path, FileMode.Create));

                    song.songURL = "/" + uploadDir + "/" + fileName;
                };
                await _songService.UpdateAsSync(song);
                return RedirectToAction("IndexSong");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult DetailSong(int id)
        {
            var song = _songService.GetById(id);
            if (song == null)
            {
                return NotFound();
            }
            _songService.Detail(id);
            var model = new SONGDetailViewModel
            {
                Id = song.songid,
                SongName = song.songname,
                ArtistName = song.artistname,
                SongUrl = song.songURL,
                ImageUrl = song.imageURL,
                ListenCount = song.listen_count,
                DateUpload = song.date_upload,
                Status = song.status
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSong(int id)
        {
            var song = _songService.GetById(id);
            if (song == null)
            {
                return NotFound();
            }
            var model = new SONGDeleteViewModel
            {
                Id = song.songid,
                SongName = song.songname,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSong(SONGDeleteViewModel model)
        {
            var song = _songService.GetById(model.Id);
            if (song == null)
            {
                return NotFound();
            }
            _songService.DeleteById(model.Id);

            return RedirectToAction("IndexSong");
        }
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }
        /*public static Stream ToStream(string str)
        {
            MemoryStream stream = new();
            StreamWriter writer = new(stream);
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }*/
    }

}
