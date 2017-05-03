using ComicBookLibraryManager.Models;
using System;
using System.Data.Entity;

namespace ComicBookLibraryManager.Data
{
    /// <summary>
    /// Custom database initializer class used to populate
    /// the database with seed data.
    /// </summary>
    internal class DatabaseInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            // This is our database's seed data...
            // 3 series, 6 artists, 2 roles, and 9 comic books.

            var seriesSpiderMan = new Series()
            {
                Title = "The Amazing Spider-Man",
                Description = "The Amazing Spider-Man (abbreviated as ASM) is an American comic book series published by Marvel Comics, featuring the adventures of the fictional superhero Spider-Man. Being the mainstream continuity of the franchise, it began publication in 1963 as a monthly periodical and was published continuously, with a brief interruption in 1995, until its relaunch with a new numbering order in 1999. In 2003 the series reverted to the numbering order of the first volume. The title has occasionally been published biweekly, and was published three times a month from 2008 to 2010. A film named after the comic was released July 3, 2012."
            };
            var seriesIronMan = new Series()
            {
                Title = "The Invincible Iron Man",
                Description = "Iron Man (Tony Stark) is a fictional superhero appearing in American comic books published by Marvel Comics, as well as its associated media. The character was created by writer and editor Stan Lee, developed by scripter Larry Lieber, and designed by artists Don Heck and Jack Kirby. He made his first appearance in Tales of Suspense #39 (cover dated March 1963)."
            };
            var seriesBone = new Series()
            {
                Title = "Bone",
                Description = "Bone is an independently published comic book series, written and illustrated by Jeff Smith, originally serialized in 55 irregularly released issues from 1991 to 2004."
            };

            var artistStanLee = new Artist()
            {
                Name = "Stan Lee"
            };
            var artistSteveDitko = new Artist()
            {
                Name = "Steve Ditko"
            };
            var artistArchieGoodwin = new Artist()
            {
                Name = "Archie Goodwin"
            };
            var artistGeneColan = new Artist()
            {
                Name = "Gene Colan"
            };
            var artistJohnnyCraig = new Artist()
            {
                Name = "Johnny Craig"
            };
            var artistJeffSmith = new Artist()
            {
                Name = "Jeff Smith"
            };

            var roleScript = new Role()
            {
                Name = "Script"
            };
            var rolePencils = new Role()
            {
                Name = "Pencils"
            };

            var comicBook1 = new ComicBook()
            {
                Series = seriesSpiderMan,
                IssueNumber = 1,
                Description = "As Peter Parker and Aunt May struggle to pay the bills after Uncle Bens death, Spider-Man must try to save a doomed John Jameson from his out of control spacecraft. / Spideys still trying to make ends meet so he decides to try and join the Fantastic Four. When that becomes public knowledge the Chameleon decides to frame Spider-Man and steals missile defense plans disguised as Spidey.",
                PublishedOn = new DateTime(1963, 3, 1),
                AverageRating = 7.1m
            };
            comicBook1.AddArtist(artistStanLee, roleScript);
            comicBook1.AddArtist(artistSteveDitko, rolePencils);
            context.ComicBooks.Add(comicBook1);

            var comicBook2 = new ComicBook()
            {
                Series = seriesSpiderMan,
                IssueNumber = 2,
                Description = "The Vulture becomes the city's most feared thief. Spider-Man must find a way to figure out his secrets and defeat this winged menace. / Spider-Man is up against The Tinkerer and a race of aliens who are trying to invade Earth.",
                PublishedOn = new DateTime(1963, 5, 1),
                AverageRating = 6.8m
            };
            comicBook2.AddArtist(artistStanLee, roleScript);
            comicBook2.AddArtist(artistSteveDitko, rolePencils);
            context.ComicBooks.Add(comicBook2);

            var comicBook3 = new ComicBook()
            {
                Series = seriesSpiderMan,
                IssueNumber = 3,
                Description = "Spider-Man battles Doctor Octopus and is defeated, he considers himself a failure until the Human Torch gives a speech to his class which inspires him to go in prepared and win the day, leaving Doctor Octopus under arrest. Spider-Man visits the Torch with words of thanks.",
                PublishedOn = new DateTime(1963, 7, 1),
                AverageRating = 6.9m
            };
            comicBook3.AddArtist(artistStanLee, roleScript);
            comicBook3.AddArtist(artistSteveDitko, rolePencils);
            context.ComicBooks.Add(comicBook3);

            var comicBook4 = new ComicBook()
            {
                Series = seriesIronMan,
                IssueNumber = 1,
                Description = "A.I.M. manages to make three duplicates of the Iron Man armor.",
                PublishedOn = new DateTime(1968, 5, 1),
                AverageRating = 7.6m
            };
            comicBook4.AddArtist(artistArchieGoodwin, roleScript);
            comicBook4.AddArtist(artistGeneColan, rolePencils);
            context.ComicBooks.Add(comicBook4);

            var comicBook5 = new ComicBook()
            {
                Series = seriesIronMan,
                IssueNumber = 2,
                Description = "Stark competitor Drexel Cord builds a robot to destroy Iron Man.",
                PublishedOn = new DateTime(1968, 6, 1),
                AverageRating = 6.7m
            };
            comicBook5.AddArtist(artistArchieGoodwin, roleScript);
            comicBook5.AddArtist(artistJohnnyCraig, rolePencils);
            context.ComicBooks.Add(comicBook5);

            var comicBook6 = new ComicBook()
            {
                Series = seriesIronMan,
                IssueNumber = 3,
                Description = "While helping Stark, Happy once again turns into the Freak.",
                PublishedOn = new DateTime(1968, 7, 1),
                AverageRating = 6.8m
            };
            comicBook6.AddArtist(artistArchieGoodwin, roleScript);
            comicBook6.AddArtist(artistJohnnyCraig, rolePencils);
            context.ComicBooks.Add(comicBook6);

            var comicBook7 = new ComicBook()
            {
                Series = seriesBone,
                IssueNumber = 1,
                Description = "Fone Bone, Smiley Bone and Phoney Bone are run out of Boneville and get separated in the desert. Fone Bone finds his way to the valley.",
                PublishedOn = new DateTime(1991, 7, 1),
                AverageRating = 7.1m
            };
            comicBook7.AddArtist(artistJeffSmith, roleScript);
            comicBook7.AddArtist(artistJeffSmith, rolePencils);
            context.ComicBooks.Add(comicBook7);

            var comicBook8 = new ComicBook()
            {
                Series = seriesBone,
                IssueNumber = 2,
                Description = "While babysitting Miz Possum's children, Bone is chased by Rat Creatures, is saved by the Dragon and finally finds Thorn.",
                PublishedOn = new DateTime(1991, 9, 1),
                AverageRating = 6.9m
            };
            comicBook8.AddArtist(artistJeffSmith, roleScript);
            comicBook8.AddArtist(artistJeffSmith, rolePencils);
            context.ComicBooks.Add(comicBook8);

            var comicBook9 = new ComicBook()
            {
                Series = seriesBone,
                IssueNumber = 3,
                Description = "Grandma Ben returns from Barrelhaven and Phoney Bone and Bone reunite.",
                PublishedOn = new DateTime(1991, 12, 1),
                AverageRating = 6.9m
            };
            comicBook9.AddArtist(artistJeffSmith, roleScript);
            comicBook9.AddArtist(artistJeffSmith, rolePencils);
            context.ComicBooks.Add(comicBook9);

            context.SaveChanges();
        }
    }
}
