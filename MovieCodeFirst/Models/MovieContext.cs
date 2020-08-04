using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MovieCodeFirst.Models
{
    public class MovieContext:DbContext
    {
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Discs> tblDiscs { get; set; }
    }
}