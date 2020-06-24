using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class Album
    {
        public int AlbumID { get; set; }
        public string AlbumName { get; set; }
        public string ArtistName { get; set; }
        public string Type { get; set; }
        public int Stock { get; set; }
    }
}