using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TasteFood.Entites
{
    public class PartialSlider
    {
        [Key]
        public int SliderId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }


    }
}