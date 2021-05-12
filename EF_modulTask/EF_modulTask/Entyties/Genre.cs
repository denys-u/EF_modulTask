namespace EF_modulTask.Entyties
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Genre
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual List<Song> Songs { get; set; } = new List<Song>();
    }
}
