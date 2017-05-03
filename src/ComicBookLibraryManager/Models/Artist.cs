using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookLibraryManager.Models
{
    /// <summary>
    /// Represents a comic book artist.
    /// </summary>
    public class Artist
    {
        public Artist()
        {
            ComicBooks = new List<ComicBookArtist>();
        }

        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        
        public ICollection<ComicBookArtist> ComicBooks { get; set; }
    }
}
