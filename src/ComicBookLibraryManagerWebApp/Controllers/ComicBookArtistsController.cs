using ComicBookLibraryManagerWebApp.ViewModels;
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
    public class ComicBookArtistsController : Controller
    {
        public ActionResult Add(int comicBookId)
        {
            // TODO Get the comic book.
            // Include the "Series" navigation property.
            var comicBook = new ComicBook();

            if (comicBook == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ComicBookArtistsAddViewModel()
            {
                ComicBook = comicBook
            };

            // TODO Pass the Context class to the view model "Init" method.
            viewModel.Init();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(ComicBookArtistsAddViewModel viewModel)
        {
            ValidateComicBookArtist(viewModel);

            if (ModelState.IsValid)
            {
                // TODO Add the comic book artist.

                TempData["Message"] = "Your artist was successfully added!";

                return RedirectToAction("Detail", "ComicBooks", new { id = viewModel.ComicBookId });
            }

            // TODO Prepare the view model for the view.
            // TODO Get the comic book.
            // Include the "Series" navigation property.
            viewModel.ComicBook = new ComicBook();
            // TODO Pass the Context class to the view model "Init" method.
            viewModel.Init();

            return View(viewModel);
        }

        public ActionResult Delete(int comicBookId, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // TODO Get the comic book artist.
            // Include the "ComicBook.Series", "Artist", and "Role" navigation properties.
            var comicBookArtist = new ComicBookArtist();

            if (comicBookArtist == null)
            {
                return HttpNotFound();
            }

            return View(comicBookArtist);
        }

        [HttpPost]
        public ActionResult Delete(int comicBookId, int id)
        {
            // TODO Delete the comic book artist.

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
            //// If there aren't any "ArtistId" and "RoleId" field validation errors...
            //if (ModelState.IsValidField("ArtistId") &&
            //    ModelState.IsValidField("RoleId"))
            //{
            //    // Then make sure that this artist and role combination 
            //    // doesn't already exist for this comic book.
            //    // TODO Call method to check if this artist and role combination
            //    // already exists for this comic book.
            //    if (false)
            //    {
            //        ModelState.AddModelError("ArtistId",
            //            "This artist and role combination already exists for this comic book.");
            //    }
            //}
        }
    }
}