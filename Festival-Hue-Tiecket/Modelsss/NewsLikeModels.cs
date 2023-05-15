using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Festival_Hue_Tiecket.Modelsss
{
    public class NewsLikeModels
    {
        [Required]
        public int UserID { get; set; }
        public int NewsID { get; set; }
    }
}
