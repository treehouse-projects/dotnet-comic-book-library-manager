using ComicBookShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ComicBookShared.Data.Queries
{
    public class GetArtistQuery
    {
        private Context _context = null;

        public GetArtistQuery(Context context)
        {
            _context = context;
        }

        public Artist Execute(int id, bool includeRelatedEntities = true)
        {
            var artist = _context.Artists.AsQueryable();

            if (includeRelatedEntities)
            {
                artist = artist
                    .Include(s => s.ComicBooks.Select(a => a.ComicBook.Series))
                    .Include(s => s.ComicBooks.Select(a => a.Role));
            }

            return artist
                .Where(cb => cb.Id == id)
                .SingleOrDefault();
        }
    }
}
