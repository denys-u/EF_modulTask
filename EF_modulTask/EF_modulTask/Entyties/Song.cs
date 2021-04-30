using System;
using System.Collections.Generic;
using System.Text;

namespace EF_modulTask.Entyties
{
    public class Song
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Duration { get; set; }

        public DateTime ReleasedDate { get; set; }
    }
}
