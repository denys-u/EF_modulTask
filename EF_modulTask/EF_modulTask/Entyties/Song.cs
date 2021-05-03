using System;
using System.Collections.Generic;
using System.Text;

namespace EF_modulTask.Entyties
{
    public class Song
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime ReleasedDate { get; set; }

        public int GenreID { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual List<Artist> Artists { get; set; } = new List<Artist>();
    }
}
