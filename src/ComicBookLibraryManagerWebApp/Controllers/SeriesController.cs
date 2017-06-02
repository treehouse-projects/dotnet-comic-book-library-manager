using ComicBookShared.Data;
using ComicBookShared.Data.Queries;
using ComicBookShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ComicBookLibraryManagerWebApp.Controllers
{
    /// <summary>
    /// Controller for the "Series" section of the website.
    /// </summary>
    public class SeriesController : BaseController
    {
        public ActionResult Index()
        {
            var series = new GetSeriesListQuery(Context)
                .Execute();

            return View(series);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var series = new GetSeriesQuery(Context)
                .Execute((int)id);

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
                Context.Series.Add(series);
                Context.SaveChanges();

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

            var series = new GetSeriesQuery(Context)
                .Execute((int)id, includeRelatedEntities: false);

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
                Context.Entry(series).State = EntityState.Modified;
                Context.SaveChanges();

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

            var series = new GetSeriesQuery(Context).Execute((int)id);

            if (series == null)
            {
                return HttpNotFound();
            }

            return View(series);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var series = new Series() { Id = id };
            Context.Entry(series).State = EntityState.Deleted;
            Context.SaveChanges();

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
            // If there aren't any "Title" field validation errors...
            if (ModelState.IsValidField("Title"))
            {
                // Then make sure that the provided title is unique.
                if (Context.Series
                        .Any(s => s.Id != series.Id && s.Title == series.Title))
                {
                    ModelState.AddModelError("Title",
                        "The provided Title is in use by another series.");
                }
            }
        }
    }
}