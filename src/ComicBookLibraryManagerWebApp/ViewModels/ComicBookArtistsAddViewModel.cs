using ComicBookShared.Data;
using ComicBookShared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicBookLibraryManagerWebApp.ViewModels
{
    /// <summary>
    /// The view model for the "Add Comic Book Artist" view.
    /// </summary>
    public class ComicBookArtistsAddViewModel
    {
        /// <summary>
        /// This property enables model binding to be able to bind the "comicbookid"
        /// route parameter value to the "ComicBook.Id" model property.
        /// </summary>
        public int ComicBookId
        {
            get { return ComicBook.Id; }
            set { ComicBook.Id = value; }
        }
        public ComicBook ComicBook { get; set; } = new ComicBook();
        [Display(Name = "Artist")]
        public int ArtistId { get; set; }
        [Display(Name = "Role")]
        public int RoleId { get; set; }

        public SelectList ArtistSelectListItems { get; set; }
        public SelectList RoleSelectListItems { get; set; }

        /// <summary>
        /// Initializes the view model.
        /// </summary>
        public void Init(Repository repository)
        {
            ArtistSelectListItems = new SelectList(
                repository.GetArtists(),
                "Id", "Name");
            RoleSelectListItems = new SelectList(
                repository.GetRoles(),
                "Id", "Name");
        }
    }
}