using ComicBookShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookShared.Data.Queries
{
    public class GetRoleListQuery
    {
        private Context _context = null;

        public GetRoleListQuery(Context context)
        {
            _context = context;
        }

        public IList<Role> Execute()
        {
            return _context.Roles
                .OrderBy(r => r.Name)
                .ToList();
        }
    }
}
