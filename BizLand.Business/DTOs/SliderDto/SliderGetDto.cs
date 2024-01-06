using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.DTOs.SliderDto
{
    public class SliderGetDto
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public string ButtonText { get; set; }
        public string ImageUrl { get; set; }
        public string ButtonUrl { get; set; }
        public string VideoUrl { get; set; }
    }
}
