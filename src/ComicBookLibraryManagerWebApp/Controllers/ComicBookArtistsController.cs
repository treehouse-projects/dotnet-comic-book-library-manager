using ComicBookLibraryManagerWebApp.ViewModels;
using ComicBookShared.Data;
using ComicBookShared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ComicBookLibraryManagerWebApp.Controllers
{
    /// <summary>
    /// Controller for adding/deleting comic book artists.
    /// </summary>
    public class ComicBookArtistsController : BaseController
    {
        private ComicBooksRepository _comicBooksRepository = null;
        private ComicBookArtistsRepository _comicBookArtistsRepository = null;

        public ComicBookArtistsController()
        {
            _comicBooksRepository = new ComicBooksRepository(Context);
            _comicBookArtistsRepository = new ComicBookArtistsRepository(Context);
        }

        public ActionResult Add(int comicBookId)
        {
            var comicBook = _comicBooksRepository.Get(comicBookId);

            if (comicBook == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ComicBookArtistsAddViewModel()
            {
                ComicBook = comicBook
            };

            viewModel.Init(Repository);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(ComicBookArtistsAddViewModel viewModel)
        {
            ValidateComicBookArtist(viewModel);

            if (ModelState.IsValid)
            {
                var comicBookArtist = new ComicBookArtist()
                {
                    ComicBookId = viewModel.ComicBookId,
                    ArtistId = viewModel.ArtistId,
                    RoleId = viewModel.RoleId
                };
                _comicBookArtistsRepository.Add(comicBookArtist);

                TempData["Message"] = "Your artist was successfully added!";

                return RedirectToAction("Detail", "ComicBooks", new { id = viewModel.ComicBookId });
            }

            viewModel.ComicBook = _comicBooksRepository.Get(viewModel.ComicBookId);
            viewModel.Init(Repository);

            return View(viewModel);
        }

        public ActionResult Delete(int comicBookId, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var comicBookArtist = _comicBookArtistsRepository.Get((int)id);

            if (comicBookArtist == null)
            {
                return HttpNotFound();
            }

            return View(comicBookArtist);
        }

        [HttpPost]
        public ActionResult Delete(int comicBookId, int id)
        {
            _comicBookArtistsRepository.Delete(id);

            TempData["Message"] = "Your artist was successfully deleted!";

            return RedirectToAction("Detail", "ComicBooks", new { id = comicBookId });
        }

        /// <summary>
        /// Validates a comic book artist on the server
        /// before adding a new record.
        /// </summary>
        /// <param name="viewModel">The view model containing the values to validate.</param>
        private void ValidateComicBookArtist(ComicBookArtistsAddViewModel viewModel)
        {
            // If there aren't any "ArtistId" and "RoleId" field validation errors...
            if (ModelState.IsValidField("ArtistId") &&
                ModelState.IsValidField("RoleId"))
            {
                // Then make sure that this artist and role combination 
                // doesn't already exist for this comic book.
                if (_comicBooksRepository.ComicBookHasArtistRoleCombination(
                        viewModel.ComicBookId, viewModel.ArtistId, viewModel.RoleId))
                {
                    ModelState.AddModelError("ArtistId",
                        "This artist and role combination already exists for this comic book.");
                }
            }
        }
    }
}