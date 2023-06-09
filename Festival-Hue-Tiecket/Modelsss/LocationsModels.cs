﻿using Festival_Hue_Tiecket.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Festival_Hue_Tiecket.Modelsss
{
    public class LocationsModels
    {       
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public string PathImage { get; set; }
        public string Longtitude { get; set; }
        public string Latitude { get; set; }
        public virtual ICollection<LocationLiked> LocationLikeds { get; set; }
    }
}
