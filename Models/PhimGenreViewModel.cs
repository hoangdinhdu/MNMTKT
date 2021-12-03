using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Demo.Models
{
    public class PhimGenreViewModel
    {
        public List<Phim> Phims { get; set; }
        public SelectList Genres { get; set; }
        public string MovieGenre { get; set; }
        public string SearchString { get; set; }
    }
}