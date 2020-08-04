using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCodeFirst.Models
{
    public class Movie
    {
        int id;
        string moviename;
        float duration;

        public int Id { get; set; }
        public string Moviename { get; set; }
        public float Duration { get; set; }
        public virtual ICollection<Discs> Discs { get; set; }
    }
}