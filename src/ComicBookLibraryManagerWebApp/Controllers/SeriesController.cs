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
    /// Controller for the "Series" section of the website.
    /// </summary>
    public class SeriesController : Controller
    {
        public ActionResult Index()
        {
            // TODO Get the series list.
            var series = new List<Series>();

            return View(series);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // TODO Get the series.
            var series = new Series();

            if (series == null)
            {
                return HttpNotFound();
            }

            // Sort the comic books.
            series.ComicBooks = series.ComicBooks
                .OrderByDescending(cb => cb.IssueNumber)
                .ToList();

            return View(series);
        }

        public ActionResult Add()
        {
            var series = new Series();

            return View(series);
        }

        [HttpPost]
        public ActionResult Add(Series series)
        {
            ValidateSeries(series);

            if (ModelState.IsValid)
            {
                // TODO Add the series.

                TempData["Message"] = "Your series was successfully added!";

                return RedirectToAction("Detail", new { id = series.Id });
            }

            return View(series);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // TODO Get the series.
            var series = new Series();

            if (series == null)
            {
                return HttpNotFound();
            }

            return View(series);
        }

        [HttpPost]
        public ActionResult Edit(Series series)
        {
            ValidateSeries(series);

            if (ModelState.IsValid)
            {
                // TODO Update the series.

                TempData["Message"] = "Your series was successfully updated!";

                return RedirectToAction("Detail", new { id = series.Id });
            }

            return View(series);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // TODO Get the series.
            var series = new Series();

            if (series == null)
            {
                return HttpNotFound();
            }

            return View(series);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            // TODO Delete the series.

            TempData["Message"] = "Your series was successfully deleted!";

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Validates a series on the server
        /// before adding a new record or updating an existing record.
        /// </summary>
        /// <param name="series">The series to validate.</param>
        private void ValidateSeries(Series series)
        {
            //// If there aren't any "Title" field validation errors...
            //if (ModelState.IsValidField("Title"))
            //{
            //    // Then make sure that the provided title is unique.
            //    // TODO Call method to check if the title is available.
            //    if (false)
            //    {
            //        ModelState.AddModelError("Title",
            //            "The provided Title is in use by another series.");
            //    }
            //}
        }
    }
}