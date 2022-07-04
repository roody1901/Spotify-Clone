using Microsoft.AspNetCore.Mvc;
using Spotify1.Models;
using System.Diagnostics;

namespace Spotify1.Controllers
{
    public class HomeController : Controller
    {
        private IHomeRepository _homeRepository;
        public HomeController(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public ViewResult AddNewArtist()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewArtist(Home artists)
        {
            try
            {
                if (artists != null)
                {
                    if (_homeRepository.AddNewArtist(artists))
                    {
                        ViewBag.Message = "Added Succesfully";
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }

        public ViewResult AddNewSong()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewSong(Home songs)
        {
            try
            {
                if (songs != null)
                {
                    if (_homeRepository.AddNewSong(songs))
                    {
                        ViewBag.Message = "Added Succesfully";
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public ActionResult GetArtist()
        {
            try
            {
                return View(_homeRepository.GetArtist());
            }
            catch (Exception ex)
            {
                return ViewBag.Message = ex.Message;
            }

        }





    }

}