using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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
        public async Task Task1()
        {
            var song = await _context.Songs
                            .Select(x => new
                            {
                                Title = x.Title,
                                Name =x.Artists,
                                Genre = x.Genre.Title
                            }).ToListAsync();

            foreach (var item in song)
            {
                Console.WriteLine($"Song:{item.Title} - Genre:{item.Genre} - Artist:{item.Name}");
            }
        }

        public async Task Task2()
        {
            var genre = await _context.Genres
                    .GroupBy(u => u.Title)
                    .Select(g => new
                    {
                        g.Key,
                        Count = g.Count()
                    }).ToListAsync();
            foreach (var group in genre)
            {
                Console.WriteLine($"Genre:{group.Key} - {group.Count} songs");
            }
        }

        public async Task Task3()
        {
            var songs = await _context.Songs
                .Where(w => w.ReleasedDate < _context.Artists.Max(m => m.DateOfBirth))
                .ToListAsync();
            foreach (var song in songs)
            {
                Console.WriteLine($"{song.Title}");
            }
        }
    }
}
