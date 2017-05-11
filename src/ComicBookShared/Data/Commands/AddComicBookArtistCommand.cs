using ComicBookShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookShared.Data.Commands
{
    public class AddComicBookArtistCommand
    {
        private Context _context = null;

        public AddComicBookArtistCommand(Context context)
        {
            _context = context;
        }

        public void Execute(int comicBookId, int artistId, int roleId)
        {
            var comicBookArtist = new ComicBookArtist()
            {
                ComicBookId = comicBookId,
                ArtistId = artistId,
                RoleId = roleId
            };
            _context.ComicBookArtists.Add(comicBookArtist);
            _context.SaveChanges();
        }
    }
}
