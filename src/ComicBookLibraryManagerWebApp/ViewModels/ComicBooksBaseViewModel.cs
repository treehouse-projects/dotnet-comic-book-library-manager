using ComicBookShared.Data;
using ComicBookShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicBookLibraryManagerWebApp.ViewModels
{
    /// <summary>
    /// Base view model class for the "Add Comic Book" 
    /// and "Edit Comic Book" views.
    /// </summary>
    public abstract class ComicBooksBaseViewModel
    {
        public ComicBook ComicBook { get; set; } = new ComicBook();

        public SelectList SeriesSelectListItems { get; set; }

        /// <summary>
        /// Initializes the view model.
        /// </summary>
        public virtual void Init()
        {
            SeriesSelectListItems = new SelectList(
                new List<Series>(), // TODO Get the series list.
                "Id", "Title");
        }
    }
}