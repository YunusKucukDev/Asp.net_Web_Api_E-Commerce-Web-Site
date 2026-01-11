using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.DtoLayer.CatalogDtos.DailySpecialOfferDto
{
    public class GetByIdDailySpecialOfferDto
    {
        public string DailyspecialOfferId { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string ImageUrl { get; set; }
    }
}
