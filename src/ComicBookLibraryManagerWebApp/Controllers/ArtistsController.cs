using ComicBookShared.Data;
using ComicBookShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ComicBookLibraryManagerWebApp.Controllers
{
    /// <summary>
    /// Controller for the "Artists" section of the website.
    /// </summary>
    public class ArtistsController : BaseController
    {
        private ArtistsRepository _artistsRepository = null;

        public ArtistsController()
        {
            _artistsRepository = new ArtistsRepository(Context);
        }

        public ActionResult Index()
        {
            var artists = _artistsRepository.GetList();

            return View(artists);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var artist = _artistsRepository.Get((int)id);

            if (artist == null)
            {
                return HttpNotFound();
            }

            // Sort the comic books.
            artist.ComicBooks = artist.ComicBooks
                .OrderBy(cb => cb.ComicBook.Series.Title)
                .OrderByDescending(cb => cb.ComicBook.IssueNumber)
                .ToList();

            return View(artist);
        }

        public ActionResult Add()
        {
            var artist = new Artist();

            return View(artist);
        }

        [HttpPost]
        public ActionResult Add(Artist artist)
        {
            ValidateArtist(artist);

            if (ModelState.IsValid)
            {
                _artistsRepository.Add(artist);

                TempData["Message"] = "Your artist was successfully added!";

                return RedirectToAction("Detail", new { id = artist.Id });
            }

            return View(artist);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var artist = _artistsRepository.Get((int)id,
                includeRelatedEntities: false);

            if (artist == null)
            {
                return HttpNotFound();
            }

            return View(artist);
        }

        [HttpPost]
        public ActionResult Edit(Artist artist)
        {
            ValidateArtist(artist);

            if (ModelState.IsValid)
            {
                _artistsRepository.Update(artist);

                TempData["Message"] = "Your artist was successfully updated!";

                return RedirectToAction("Detail", new { id = artist.Id });
            }

            return View(artist);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var artist = _artistsRepository.Get((int)id);

            if (artist == null)
            {
                return HttpNotFound();
            }

            return View(artist);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _artistsRepository.Delete(id);

            TempData["Message"] = "Your artist was successfully deleted!";

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Validates an artist on the server 
        /// before adding a new record or updating an existing record.
        /// </summary>
        /// <param name="artist">The artist to validate.</param>
        private void ValidateArtist(Artist artist)
        {
            // If there aren't any "Name" field validation errors...
            if (ModelState.IsValidField("Name"))
            {
                // Then make sure that the provided name is unique.
                if (_artistsRepository.ArtistHasName(
                        artist.Id, artist.Name))
                {
                    ModelState.AddModelError("Name",
                        "The provided Name is in use by another artist.");
                }
            }
        }
    }
}
