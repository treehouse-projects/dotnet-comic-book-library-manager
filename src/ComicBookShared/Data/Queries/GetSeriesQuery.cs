using ComicBookShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ComicBookShared.Data.Queries
{
    public class GetSeriesQuery
    {
        private Context _context = null;

        public GetSeriesQuery(Context context)
        {
            _context = context;
        }

        public Series Execute(int id, bool includeRelatedEntities = true)
        {
            var series = _context.Series.AsQueryable();

            if (includeRelatedEntities)
            {
                series = series
                    .Include(s => s.ComicBooks);
            }

            return series
                .Where(cb => cb.Id == id)
                .SingleOrDefault();
        }
    }
}
