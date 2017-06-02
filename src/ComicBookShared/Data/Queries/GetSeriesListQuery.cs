using ComicBookShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookShared.Data.Queries
{
    public class GetSeriesListQuery
    {
        private Context _context = null;

        public GetSeriesListQuery(Context context)
        {
            _context = context;
        }

        public IList<Series> Execute()
        {
            return _context.Series
                .OrderBy(s => s.Title)
                .ToList();
        }
    }
}
