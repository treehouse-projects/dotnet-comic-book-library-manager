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

        public ComicBook Execute(int id)
        {
            return _context.ComicBooks
                .Include(cb => cb.Series)
                .Include(cb => cb.Artists.Select(a => a.Artist))
                .Include(cb => cb.Artists.Select(a => a.Role))
                .Where(cb => cb.Id == id)
                .SingleOrDefault();
        }
    }
}
