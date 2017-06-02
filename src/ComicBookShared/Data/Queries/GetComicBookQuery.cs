using ComicBookShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ComicBookShared.Data.Queries
{
    public class GetComicBookQuery
    {
        private Context _context = null;

        public GetComicBookQuery(Context context)
        {
            _context = context;
        }

        public ComicBook Execute(int id, bool includeRelatedEntities = true)
        {
            var comicBooks = _context.ComicBooks.AsQueryable();

            if (includeRelatedEntities)
            {
                comicBooks = comicBooks
                    .Include(cb => cb.Series)
                    .Include(cb => cb.Artists.Select(a => a.Artist))
                    .Include(cb => cb.Artists.Select(a => a.Role));
            }

            return comicBooks
                .Where(cb => cb.Id == id)
                .SingleOrDefault();
        }
    }
}
