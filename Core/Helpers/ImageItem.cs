using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheCore.Helpers
{
    public class ImageItem
    {
        //These fields are added to the JSON in ImageJSONifier
        public string Image { get; set; }
        public string Thumb { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }

        //These fields are not added to the JSON in ImageJSONifier
        //  these were added for sorting or computation capabilities
        public DateTime ShowDate { get; set; }
    }
}
