using ComicBookShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookShared.Data.Queries
{
    public class GetArtistListQuery
    {
        private Context _context = null;

        public GetArtistListQuery(Context context)
        {
            _context = context;
        }

        public IList<Artist> Execute()
        {
            return _context.Artists
                .OrderBy(a => a.Name)
                .ToList();
        }
    }
}
