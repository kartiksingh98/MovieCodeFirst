using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCodeFirst.Models
{
    public class Discs
    {
        int id;
        string moviename;
        bool isavailable;
        int quantity;

        public int Id { get; set; }
        public string Moviename { get; set; }
        public bool Isavailable { get; set; }
        public int Quantity { get; set; }
        public virtual Movie Movie { get; set; }
    }
}