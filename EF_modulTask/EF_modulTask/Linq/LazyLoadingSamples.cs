using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_modulTask.Linq
{
    public class LazyLoadingSamples
    {
        private readonly ApplicationContext _context;

        public LazyLoadingSamples(ApplicationContext context)
        {
            _context = context;
        }

        public async void Task1()
        {
            var songs = await _context.Songs.Include(x => x.Artists).Include(x => x.Genre).ToListAsync();
            var result = songs
                .Where(x => x.Genre != null)
                .Where(x => x.Artists.Any())
                .Select(x => new { Title = x.Title, Artist = x.Artists.FirstOrDefault().Name, Genre = x.Genre.Title });


            foreach (var song in result)
            {
                Console.WriteLine($"{song.Title}, {song.Artist}, {song.Genre}");
            }
        }

        public async void Task2()
        {
            var genres = await _context.Genres.Include(x => x.Songs).ToListAsync();
            var result = genres.Select(x => new { Genre = x.Title, x.Songs.Count });
        }

        public async void Task3()
        {
            var songs = await _context.Songs.Include(x => x.Artists).Include(x => x.Genre).ToListAsync();
            var artists = await _context.Artists.Include(x => x.Songs).ToListAsync();
            var result = songs.Where(x => x.ReleasedDate < artists.Max(x => x.DateOfBirth));
        }
    }
}
