using System;
using System.Collections.Generic;

namespace DAL.MySqlDbContext
{
    public partial class Slider
    {
        public int Id { get; set; }
        public string Title1 { get; set; } = null!;
        public string Title2 { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Url { get; set; } = null!;
        public string Image { get; set; } = null!;
    }
}
