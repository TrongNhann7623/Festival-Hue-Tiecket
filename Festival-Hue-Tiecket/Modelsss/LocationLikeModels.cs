﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Festival_Hue_Tiecket.Modelsss
{
    public class LocationLikeModels
    {
        [Required]
        public int LocationID { get; set; }
        public int UserID { get; set; }
    }
}
