using ComicBookLibraryManagerWebApp.ViewModels;
using ComicBookShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ComicBookShared.Data.Queries;
using ComicBookShared.Data.Commands;
using ComicBookShared.Data;

namespace ComicBookLibraryManagerWebApp.Controllers
{
    public class ComicBookArtistsController : BaseController
    {
        private ArtistsRepository _artistsRepository = null;

        public ComicBookArtistsController()
        {
            _artistsRepository = new ArtistsRepository(Context);
        }

        public ActionResult Add(int comicBookId)
        {
            var comicBook = new GetComicBookQuery(Context).Execute(comicBookId);

            if (comicBook == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ComicBookArtistsAddViewModel()
            {
                ComicBook = comicBook
            };

            viewModel.Init(Repository, _artistsRepository);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(ComicBookArtistsAddViewModel viewModel)
        {
            ValidateComicBookArtist(viewModel);

            if (ModelState.IsValid)
            {
                new AddComicBookArtistCommand(Context)
                    .Execute(viewModel.ComicBookId, viewModel.ArtistId, viewModel.RoleId);

                TempData["Message"] = "Your artist was successfully added!";

                return RedirectToAction("Detail", "ComicBooks", new { id = viewModel.ComicBookId });
            }

            viewModel.ComicBook = new GetComicBookQuery(Context)
                .Execute(viewModel.ComicBookId);
            viewModel.Init(Repository, _artistsRepository);

            return View(viewModel);
        }

        public ActionResult Delete(int comicBookId, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var comicBookArtist = Context.ComicBookArtists
                .Include(cba => cba.Artist)
                .Include(cba => cba.Role)
                .Include(cba => cba.ComicBook.Series)
                .Where(cba => cba.Id == id)
                .SingleOrDefault();

            if (comicBookArtist == null)
            {
                return HttpNotFound();
            }

            return View(comicBookArtist);
        }

        [HttpPost]
        public ActionResult Delete(int comicBookId, int id)
        {
            var comicBookArtist = new ComicBookArtist() { Id = id };
            Context.Entry(comicBookArtist).State = EntityState.Deleted;
            Context.SaveChanges();

            TempData["Message"] = "Your artist was successfully deleted!";

            return RedirectToAction("Detail", "ComicBooks", new { id = comicBookId });
        }

        private void ValidateComicBookArtist(ComicBookArtistsAddViewModel viewModel)
        {
            // If there aren't any "ArtistId" and "RoleId" field validation errors...
            if (ModelState.IsValidField("ArtistId") &&
                ModelState.IsValidField("RoleId"))
            {
                // Then make sure that this artist and role combination 
                // doesn't already exist for this comic book.
                if (Context.ComicBookArtists
                        .Any(cba => cba.ComicBookId == viewModel.ComicBookId &&
                            cba.ArtistId == viewModel.ArtistId &&
                            cba.RoleId == viewModel.RoleId))
                {
                    ModelState.AddModelError("ArtistId",
                        "This artist and role combination already exists for this comic book.");
                }
            }
        }
    }
}
